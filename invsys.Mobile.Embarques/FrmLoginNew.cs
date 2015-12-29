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
                new FrmEmbarquesNew(1).Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
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