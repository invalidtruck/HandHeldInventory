#define DEBUG
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Net;
//using invsys.Mobile.Embarques.embarques_srv;
//using some = invsys.Mobile.Embarques.embarques_srv;
using invsys.Mobile.Embarques.com.somee.wspedidos;
using some = invsys.Mobile.Embarques.com.somee.wspedidos;
using ErikEJ.SqlCe;

namespace invsys.Mobile.Embarques
{
    public partial class frmEmbarques : Form
    {
        private SqlCeConnection cnn;
        public frmEmbarques()
        {
            InitializeComponent();
            this.dir = this.dir.Substring(0, this.dir.LastIndexOf("\\"));
            this.cnnstr = "Data Source=" + (this.dir + "\\EmbInv.sdf") + ";Max Database Size=4091";
            this.cnn = new SqlCeConnection(this.cnnstr);
        }
        public frmEmbarques(int iduser)
        {
            this.idusuario = iduser;
            this.InitializeComponent();
            this.dir = this.dir.Substring(0, this.dir.LastIndexOf("\\"));
            this.cnnstr = "Data Source=" + (this.dir + "\\EmbInv.sdf") + ";Max Database Size=4091";
            this.cnn = new SqlCeConnection(this.cnnstr);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.CargarFiltro();
            this.CargarEmbarques();
        }

        private void CargarFiltro()
        {
            try
            {
#if !DEBUG
                var wsPedidos = new some.WSPedidos();
#else
                var wsPedidos = new WSPedidos();
#endif
                lblDesc.Text = wsPedidos.Url.ToString();
                ServicePointManager.Expect100Continue = false;
                this.cmbFiltro.DataSource = (object)wsPedidos.GetFiltro().Tables[0];
                this.cmbFiltro.ValueMember = "idfiltro";
                this.cmbFiltro.DisplayMember = "descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void CargarEmbarques()
        {
            try
            {
                SqlCeCommand sqlCeCommand = new SqlCeCommand("SELECT IdEmbarque,Descripcion FROM Embarque", this.cnn);
                sqlCeCommand.Parameters.AddWithValue("@CB", (object)this.txtCB.Text);
                if (this.cnn.State != ConnectionState.Open)
                    this.cnn.Open();
                SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load((IDataReader)sqlCeDataReader);
                if (dataTable.Rows.Count <= 0)
                    return;
                this.cmbEmbarque.DataSource = (object)dataTable;
                this.cmbEmbarque.ValueMember = "IdEmbarque";
                this.cmbEmbarque.DisplayMember = "Descripcion";
            }
            catch (Exception)
            {
            }
            finally
            {
                this.cnn.Close();
            }
        }

        private void BtnDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCeCommand sqlCeCommand = new SqlCeCommand("SELECT * FROM CatMaterial WHERE CodigoBarras = @CB ", this.cnn);
                sqlCeCommand.Parameters.AddWithValue("@CB", (object)this.txtCB.Text);
                this.cnn.Open();
                SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
                if (sqlCeDataReader.Read())
                {
                    this.txtCB.Enabled = false;
                    this.peso += (float)sqlCeDataReader["peso"];
                    this.lblAlmacen.Text = sqlCeDataReader["Almacen"].ToString();
                    this.lblDesc.Text = sqlCeDataReader["Descripcion"].ToString();
                    this.lblEspesor.Text = sqlCeDataReader["Espesor"].ToString();
                    this.lblIdSalida.Text = sqlCeDataReader["IdSalidaDatos"].ToString();
                    this.lblLongitud.Text = sqlCeDataReader["longitud"].ToString();
                    this.lblLote.Text = sqlCeDataReader["Lote"].ToString();
                    this.lblMedida.Text = sqlCeDataReader["Medida"].ToString();
                    this.lblNorma.Text = sqlCeDataReader["longitud"].ToString();
                    this.lblPesoTeorico.Text = sqlCeDataReader["PesoTeorico"].ToString();
                    this.lblUbicacion.Text = sqlCeDataReader["ubicacion"].ToString();
                    this.pesoMaterial = (float)((double)Convert.ToSingle(this.lblLongitud.Text) * (double)Convert.ToSingle(this.lblPesoTeorico.Text) / 1000.0);
                }
                else
                {
                    int num = (int)MessageBox.Show("El Codigo de Barras no Existe", "Error");
                    this.txtCB.Text = "";
                    this.txtCB.Focus();
                    this.lblAlmacen.Text = "";
                    this.lblDesc.Text = "";
                    this.lblEspesor.Text = "";
                    this.lblIdSalida.Text = "";
                    this.lblLongitud.Text = "";
                    this.lblLote.Text = "";
                    this.lblMedida.Text = "";
                    this.lblNorma.Text = "";
                    this.lblPesoTeorico.Text = "";
                    this.txtCB.Enabled = true;
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (this.txtCB.Text == "")
            {
                int num1 = (int)MessageBox.Show("Seleccione un Código valido");
            }
            try
            {
                SqlCeCommand sqlCeCommand1 = new SqlCeCommand("select count(1) from EmbarqueMaterial where  CodigoBarras= @CB ", this.cnn);
                if (this.cnn.State == ConnectionState.Closed)
                    this.cnn.Open();
                if ((int)sqlCeCommand1.ExecuteScalar() > 0)
                    return;
                this.cnn.Close();
                float num2 = (float)((double)Convert.ToSingle(this.lblLongitud.Text) * (double)Convert.ToSingle(this.lblPesoTeorico.Text) / 1000.0);
                this.peso += num2;
                if ((double)this.peso >= 30.0 & (double)this.peso <= 34.9900016784668)
                {
                    int num3 = (int)MessageBox.Show(string.Format("El contenedor/caja ya esta llegando a su capacidad maxima \n actualmente hay  {0}Kgs", (object)this.peso), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                if ((double)this.peso >= 35.0 && MessageBox.Show("A embarcado el peso maximo permitido (35tns)?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                    return;
                SqlCeCommand sqlCeCommand2 = new SqlCeCommand("INSERT INTO EmbarqueMaterial VALUES(@idE,@CB,@IdSalida,@Peso)", this.cnn);
                sqlCeCommand2.Parameters.AddWithValue("@idE", this.cmbEmbarque.SelectedValue);
                sqlCeCommand2.Parameters.AddWithValue("@CB", (object)this.txtCB.Text);
                sqlCeCommand2.Parameters.AddWithValue("@IdSalida", (object)this.lblIdSalida.Text);
                sqlCeCommand2.Parameters.AddWithValue("@Peso", (object)num2);
                this.cnn.Open();
                sqlCeCommand2.ExecuteReader();
                SqlCeCommand sqlCeCommand3 = new SqlCeCommand("update embarque set peso = @peso where idEmbarque = @IdEmbarque", this.cnn);
                sqlCeCommand3.Parameters.AddWithValue("@peso", (object)this.peso);
                sqlCeCommand3.Parameters.AddWithValue("@IdEmbarque", this.cmbEmbarque.SelectedValue);
                sqlCeCommand3.ExecuteNonQuery();
                this.CargarEmbarques_Detalle();
            }
            catch (Exception ex)
            {
                int num2 = (int)MessageBox.Show("Favor de reportar al administrador de sistemas: \n" + ex.Message);
            }
            finally
            {
                this.Limpiar();
                this.cnn.Close();
            }
        }

        private void txtCB_Validated(object sender, EventArgs e)
        {
            this.validarLote();
        }

        private void validarLote()
        {
            try
            {
                if (this.txtCB.Text.Trim() == "")
                    return;
                SqlCeCommand sqlCeCommand = new SqlCeCommand("select * from catMaterial where lote = @CB", this.cnn);
                this.cnn.Open();
                sqlCeCommand.Parameters.AddWithValue("@CB", (object)this.txtCB.Text);
                SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load((IDataReader)sqlCeDataReader);
                if (dataTable.Rows.Count > 0)
                {
                    this.lblMedida.Text = dataTable.Rows[0]["medida"].ToString();
                    this.lblAlmacen.Text = dataTable.Rows[0]["Almacen"].ToString();
                    this.lblLote.Text = dataTable.Rows[0]["Lote"].ToString();
                    this.lblLongitud.Text = dataTable.Rows[0]["Longitud"].ToString();
                    this.lblNorma.Text = dataTable.Rows[0]["Norma"].ToString();
                    this.lblEspesor.Text = dataTable.Rows[0]["Espesor"].ToString();
                    this.lblDesc.Text = dataTable.Rows[0]["Descripcion"].ToString();
                    this.lblUbicacion.Text = dataTable.Rows[0]["Ubicacion"].ToString();
                    this.lblIdSalida.Text = dataTable.Rows[0]["IdSalidaDatos"].ToString();
                    this.lblPesoTeorico.Text = dataTable.Rows[0]["PesoTeorico"].ToString();
                }
                else
                {
                    int num = (int)MessageBox.Show("No existe articulo con ese codigo de barras");
                    this.clean();
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

        private void clean()
        {
            this.lblAlmacen.Text = "";
            this.lblArt.Text = "";
            this.lblEspesor.Text = "";
            this.lblDesc.Text = "";
            this.lblLongitud.Text = "";
            this.lblLote.Text = "";
            this.lblMedida.Text = "";
            this.lblNorma.Text = "";
            this.lblUbicacion.Text = "";
            this.txtCB.Text = "";
            this.txtCB.Focus();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.validarLote();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            int num = (int)new FrmInventario(this.idusuario).ShowDialog();
        }

        private void tabCaptura_Click(object sender, EventArgs e)
        {
        }

        private void menuNuevoEmbarque_Click(object sender, EventArgs e)
        {
            this.refrescar = true;
            //int num = (int)new frmAddEmbarque(this.idusuario).ShowDialog();
        }

        private void CargarDatosWS()
        {
            string str = "";
            try
            {
                this.cnn.Open();
                new SqlCeCommand("delete from CatMaterial", this.cnn).ExecuteNonQuery();
                ServicePointManager.Expect100Continue = false;
                WSPedidos wsPedidos = new WSPedidos();
                DataTable dataTable1 = new DataTable();
                DataTable dataTable2;
                try
                {
                    dataTable2 = wsPedidos.GetParameter(this.cmbFiltro.Text).Tables[0];
                }
                catch (Exception)
                {
                    int num = (int)MessageBox.Show("No se puede conectar al servidor, favor de verificar su conexion");
                    return;
                }
                int MinValue = 0;
                int MaxValue = (int)dataTable2.Rows[0][1];
                str = string.Concat(new object[4]
        {
          (object) str,
          (object) "tengo parametros ",
          (object) MaxValue,
          (object) "\n"
        });
                this.BULK(wsPedidos.GetValues(MinValue, MaxValue).Tables[0]);
                int num1 = (int)MessageBox.Show("Termine con la carga");
            }
            catch (WebException ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(str + ex.Message);
            }
            finally
            {
                this.cnn.Close();
            }
        }

        private void MenuCargarDatos_Click(object sender, EventArgs e)
        {
            this.CargarDatosWS();
        }

        private void cmbEmbarque_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.pnlDesc.Enabled = true;
            this.txtCB.Enabled = true;
            this.Limpiar();
            this.CargarEmbarques_Detalle();
        }

        private void CargarEmbarques_Detalle()
        {
            try
            {
                if (this.cmbEmbarque.Items.Count == 0)
                    return;
                SqlCeCommand sqlCeCommand1 = new SqlCeCommand("select * from embarque where idembarque = @idEmbarque", this.cnn);
                sqlCeCommand1.Parameters.AddWithValue("@IdEmbarque", this.cmbEmbarque.SelectedValue);
                SqlCeDataReader sqlCeDataReader1 = sqlCeCommand1.ExecuteReader();
                DataTable dataTable1 = new DataTable();
                dataTable1.Load((IDataReader)sqlCeDataReader1);
                this.peso = dataTable1.Rows.Count <= 0 ? 0.0f : (dataTable1.Rows[0].IsNull("peso") ? 0.0f : Convert.ToSingle(dataTable1.Rows[0]["peso"]));
                SqlCeCommand sqlCeCommand2 = new SqlCeCommand("select * from EmbarqueMaterial where idEmbarque = @IdEmbarque", this.cnn);
                sqlCeCommand2.Parameters.AddWithValue("@IdEmbarque", this.cmbEmbarque.SelectedValue);
                if (this.cnn.State == ConnectionState.Closed)
                    this.cnn.Open();
                SqlCeDataReader sqlCeDataReader2 = sqlCeCommand2.ExecuteReader();
                DataTable dataTable2 = new DataTable();
                dataTable2.Load((IDataReader)sqlCeDataReader2);
                if (dataTable2.Rows.Count > 0)
                {
                    this.dgvCatalogo.DataSource = (object)dataTable2;
                    this.lblArt.Text = "Art " + dataTable2.Rows.Count.ToString();
                }
                this.dgvCatalogo.DataSource = (object)dataTable2;
            }
            catch (Exception)
            {
            }
            finally
            {
                this.cnn.Close();
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.clean();
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            this.GrabarEmbarquesWS();
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            this.GrabarEmbarquesWS();
        }

        private void Limpiar()
        {
            this.peso = 0.0f;
            this.pesoMaterial = 0.0f;
            this.txtCB.Text = "";
            this.lblAlmacen.Text = "";
            this.lblDesc.Text = "";
            this.lblEspesor.Text = "";
            this.lblIdSalida.Text = "";
            this.lblLongitud.Text = "";
            this.lblLote.Text = "";
            this.lblMedida.Text = "";
            this.lblNorma.Text = "";
            this.lblPesoTeorico.Text = "";
            this.lblUbicacion.Text = "";
            this.txtCB.Focus();
        }

        private void GrabarEmbarquesWS()
        {
            try
            {
                ServicePointManager.Expect100Continue = false;
                SqlCeCommand sqlCeCommand = new SqlCeCommand("select * from embarque", this.cnn);
                WSPedidos wsPedidos = new WSPedidos();
                this.cnn.Open();
                SqlCeDataReader sqlCeDataReader1 = sqlCeCommand.ExecuteReader();
                DataTable dataTable1 = new DataTable();
                dataTable1.Load((IDataReader)sqlCeDataReader1);
                foreach (DataRow dataRow1 in (InternalDataCollectionBase)dataTable1.Rows)
                {
                    EmbarqueEntity parametro1 = new EmbarqueEntity()
                    {
                        IdUsuario = Convert.ToInt32(dataRow1["idusuario"]),
                        IdEmbarque = Convert.ToInt32(dataRow1["IdEmbarque"]),
                        FechaAlta = Convert.ToDateTime(dataRow1["FechaAlta"]),
                        Peso = Convert.ToDecimal(dataRow1["Peso"]),
                        Descripcion = dataRow1["Descripcion"].ToString()
                    };
                    wsPedidos.InsertEmbarque(parametro1);
                    SqlCeDataReader sqlCeDataReader2 = new SqlCeCommand("select * from embarqueMaterial", this.cnn).ExecuteReader();
                    DataTable dataTable2 = new DataTable();
                    dataTable2.Load((IDataReader)sqlCeDataReader2);
                    foreach (DataRow dataRow2 in (InternalDataCollectionBase)dataTable2.Rows)
                    {
                        Embarque_DetalleEntity parametro2 = new Embarque_DetalleEntity()
                        {
                            FechaAlta = DateTime.Now,
                            IdEmbarque = Convert.ToInt32(dataRow2["IdEmbarque"]),
                            Peso = Convert.ToDecimal(dataRow1["peso"]),
                            IdSalidaDatosAll = Convert.ToInt32(dataRow2["idSalidaDatos"])
                        };
                        wsPedidos.InsertEmbarque_Detalle(parametro2);
                    }
                }
                this.BorrarEmbarques();
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

        private void Main_Activated(object sender, EventArgs e)
        {
            if (!this.refrescar)
                return;
            this.CargarEmbarques();
            this.refrescar = false;
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("se va a eliminar toda la información capturada de embarques esta seguro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                return;
            this.BorrarEmbarques();
        }

        private void BorrarEmbarques()
        {
            try
            {
                if (this.cnn.State == ConnectionState.Closed)
                    this.cnn.Open();
                new SqlCeCommand("DELETE FROM EMBARQUE", this.cnn).ExecuteNonQuery();
                new SqlCeCommand("DELETE FROM EmbarqueMaterial", this.cnn).ExecuteNonQuery();
                int num = (int)MessageBox.Show("Se ha eliminado la información de embarques");
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

        private void menuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                int num = (int)MessageBox.Show("Termine");
                GC.Collect();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("Error:\n" + ex.Message);
            }
        }

        private void BULK(DataTable dt)
        {
            SqlCeBulkCopyOptions options = new SqlCeBulkCopyOptions();

            options = options |= SqlCeBulkCopyOptions.KeepNulls;

            using (SqlCeBulkCopy bc = new SqlCeBulkCopy(this.cnnstr, options))
            {
                bc.DestinationTableName = "CatMaterial";
                bc.WriteToServer(dt);
            }

        }
    }
}