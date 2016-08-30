using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Net;
using System.Windows.Forms;
using ErikEJ.SqlCe;
//using invsys.Mobile.Embarques.wspedidos; // testing porpuses
using invsys.Mobile.Embarques.embarques;
using System.Reflection; // real One


namespace invsys.Mobile.Embarques
{
    public partial class FrmListEmbarques : Form
    {
        private SqlCeConnection cnn;
        private string dir = Assembly.GetExecutingAssembly().GetName().CodeBase;
        private int IdHandHeld = 0;
        private string cnnstr = "";
        private float peso = 0.0f;
        private float pesoMaterial = 0.0f;
        private bool refrescar = false;
        public int idusuario { get; set; }
        public int idConexion { get; set; }

        public FrmListEmbarques(int iduser, int idCon)
        {
            this.idConexion = idCon;
            this.idusuario = iduser;
            this.InitializeComponent();
            this.dir = this.dir.Substring(0, this.dir.LastIndexOf("\\"));
            this.cnnstr = "Data Source=" + (this.dir + "\\EmbInv.sdf") + ";Max Database Size=4091";
            this.cnn = new SqlCeConnection(this.cnnstr);
            try
            {
                var x = System.IO.File.OpenText(this.dir + "\\IdHandheld.ivt");
                this.IdHandHeld = Convert.ToInt32(x.ReadLine().Trim());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void FrmListEmbarques_Load(object sender, EventArgs e)
        {
        }

        private void cargaEmbarques()
        {
            try
            {
                SqlCeCommand sqlCeCommand = new SqlCeCommand("SELECT IdEmbarque,Descripcion FROM Embarque where IdCon = @Idcon", this.cnn);
                sqlCeCommand.Parameters.AddWithValue("@Idcon", this.idConexion);
                if (this.cnn.State != ConnectionState.Open)
                    this.cnn.Open();
                SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load((IDataReader)sqlCeDataReader);
                foreach (DataRow row in dataTable.Rows)
                {
                    this.lviewEmbarques.Items.Add(new ListViewItem(row["Descripcion"].ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.cnn.Close();
            }
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                ServicePointManager.Expect100Continue = false;
                var sqlCeCommand = new SqlCeCommand("select * from embarque where IdCon =@idCon", this.cnn);
                sqlCeCommand.Parameters.AddWithValue("@IdCon", this.idConexion);

                var wsPedidos = new WSPedidos();

                this.cnn.Open();
                var sqlCeDataReader1 = sqlCeCommand.ExecuteReader();
                var dataTable1 = new DataTable();
                dataTable1.Load((IDataReader)sqlCeDataReader1);
                foreach (DataRow dataRow1 in dataTable1.Rows)
                {
                    EmbarqueEntity parametro1 = new EmbarqueEntity()
                    {
                        IdUsuario = Convert.ToInt32(dataRow1["idusuario"]),
                        IdEmbarque = Convert.ToInt32(dataRow1["IdEmbarque"]),
                        FechaAlta = Convert.ToDateTime(dataRow1["FechaAlta"]),
                        Peso = Convert.ToDecimal(dataRow1["Peso"]),
                        Descripcion = dataRow1["Descripcion"].ToString()
                        // IdConexion = Convert.ToInt32(dataRow1["IdCon"])
                    };
                    var IdEmbarqueInterno = wsPedidos.InsertEmbarque(parametro1, this.idConexion).Tables[0].Rows[0][0];
                    var sqlCeDataReader2 = new SqlCeCommand("select * from embarqueMaterial", this.cnn).ExecuteReader();
                    var dataTable2 = new DataTable();
                    dataTable2.Load(sqlCeDataReader2);
                    foreach (DataRow dataRow2 in dataTable2.Rows)
                    {
                        string lote = dataRow2["CodigoBarras"].ToString();
                        Embarque_DetalleEntity parametro2 = new Embarque_DetalleEntity()
                        {
                            FechaAlta = DateTime.Now,
                            IdEmbarque = (int)IdEmbarqueInterno,//IdEmbarqueInterno,// Convert.ToInt32(dataRow2["IdEmbarque"]),
                            Peso = Convert.ToDecimal(dataRow1["peso"]),
                            IdSalidaDatosAll = Convert.ToInt32(dataRow2["idSalidaDatos"]),
                            //id= Convert.ToInt32(dataRow2["IdCon"])
                        };
                        var cancelar = (int)wsPedidos.InsertEmbarque_Detalle(parametro2, this.idConexion).Tables[0].Rows[0][0];
                        if (cancelar == 1)
                        {
                            MessageBox.Show(string.Format("El Lote {0} ya se encuentra en el embarque", lote));
                            continue;
                        }
                        if (cancelar == 2)
                        {
                            MessageBox.Show("es 2");
                            return;
                        }
                    }
                }
                 
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("Favor de reportar al administrador de sistemas: \n" + ex.Message);
            }
            finally
            {
                this.cnn.Close();
            }
        }
    }
}