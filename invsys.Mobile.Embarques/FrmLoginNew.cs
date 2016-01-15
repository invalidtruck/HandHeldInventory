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
    public partial class FrmLoginNew : Form
    {
        public FrmLoginNew()
        {
            InitializeComponent();
            this.dir = this.dir.Substring(0, this.dir.LastIndexOf("\\"));
            this.cnn = new SqlCeConnection("Data Source=" + (this.dir + "\\EmbInv.sdf"));
        }

        private void BtnAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();

                var cmd = new SqlCeCommand("select count(1) from catUsuarios where Usuario = @us and contrasena =@pass", cnn);
                cmd.Parameters.AddWithValue("@us", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                if ((int)cmd.ExecuteScalar() > 0)
                {
                    new FrmEmbarquesNew(1).Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña no valida");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Focus();
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

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}