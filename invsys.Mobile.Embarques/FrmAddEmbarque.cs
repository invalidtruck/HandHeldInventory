using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace invsys.Mobile.Embarques
{
    public partial class FrmAddEmbarque : Form
    {
        public FrmAddEmbarque()
        {
            InitializeComponent();
        }
        public FrmAddEmbarque(int Idu)
        {
            this.idusario = Idu;
            this.InitializeComponent();
            this.dir = this.dir.Substring(0, this.dir.LastIndexOf("\\"));
            this.cnn = new SqlCeConnection("Data Source=" + (this.dir + "\\EmbInv.sdf"));
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCeCommand sqlCeCommand = new SqlCeCommand("INSERT INTO Embarque(Descripcion,FechaAlta,idusuario)VALUES(@Desc,@Fecha,@idUsuario)", this.cnn);
                sqlCeCommand.Parameters.AddWithValue("@Desc", (object)this.txtEmbarque.Text);
                sqlCeCommand.Parameters.AddWithValue("@idUsuario", (object)this.idusario);
                sqlCeCommand.Parameters.AddWithValue("@Fecha", (object)DateTime.Now);
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

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}