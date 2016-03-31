using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Reflection;

namespace invsys.Mobile.Embarques
{
    public partial class FrmAddEmbarqueN : Form
    {
        public int idusario { get; set; }
        public int IdConexion { get; set; }
        private string dir = Assembly.GetExecutingAssembly().GetName().CodeBase;
        private SqlCeConnection cnn;

        public FrmAddEmbarqueN()
        {
            InitializeComponent();
        }
        public FrmAddEmbarqueN(int Idu, int IdCon)
        {
            this.IdConexion = IdCon;
            this.idusario = Idu;
            this.InitializeComponent();
            this.dir = this.dir.Substring(0, this.dir.LastIndexOf("\\"));
            this.cnn = new SqlCeConnection("Data Source=" + (this.dir + "\\EmbInv.sdf"));
        }
        private void Cancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAgregar_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlCeCommand sqlCeCommand = new SqlCeCommand("INSERT INTO Embarque(IdCon,Descripcion,FechaAlta,idusuario)VALUES(@IdCon,@Desc,@Fecha,@idUsuario)", this.cnn);
                sqlCeCommand.Parameters.AddWithValue("@Desc", txtEmbarque.Text);
                sqlCeCommand.Parameters.AddWithValue("@IdCon", this.IdConexion);
                sqlCeCommand.Parameters.AddWithValue("@idUsuario", idusario);
                sqlCeCommand.Parameters.AddWithValue("@Fecha", DateTime.Now);
                this.cnn.Open();
                sqlCeCommand.ExecuteReader();
                int num = (int)MessageBox.Show("Se ha grabado el embarque exitosamente");

            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
            finally
            {
                this.cnn.Close();
                this.Close();
            }
        }
    }
}