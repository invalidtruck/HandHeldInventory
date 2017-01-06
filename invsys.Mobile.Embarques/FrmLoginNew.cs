using System;
using System.Net;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using invsys.Mobile.Embarques.embarques; // real One
using invsys.Mobile.Logic.Login;
using invsys.Mobile.Logic;

namespace invsys.Mobile.Embarques
{
    public partial class FrmLoginNew : Form
    {
        #region "Events"
        public FrmLoginNew() { InitializeComponent(); }

        private void FrmLoginNew_Load(object sender, EventArgs e)
        { DDLConexionesEmpresas(); }

        private void BtnAcceder_Click(object sender, EventArgs e)
        {
            var err = "";
            var EstaLogueado = new Login().GetLogin(textBox1.Text, textBox2.Text, out err);

            if (err != null) { MessageBox.Show(err); return; }
            if (EstaLogueado) new FrmEmbarquesNew(Core.IdHandHeld, (int)ddlConexiones2.SelectedValue).Show();
            else
            {
                MessageBox.Show("Usuario y/o contraseña no valida");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
            }

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuUpdateE_Click(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = false;
            var ws = new WSPedidos();
            var err = "";
            var ds = ws.GetEmpresas();
            var dt = ds.Tables[0];
            new Login().GetConexionesWS(out err, dt);
            if (err.Length > 0)
                MessageBox.Show(err);
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region "Funciones"
        private void DDLConexionesEmpresas()
        {
            var Err = "";
            var dt = new Login().DDLConexionesEmpresas(out Err);


            if (Err != null)
                MessageBox.Show("Favor de reportar el siguiente error al area de sistemas: \n" + Err);
            else
            {
                ddlConexiones2.DataSource = dt;
                ddlConexiones2.ValueMember = "IdConexion";
                ddlConexiones2.DisplayMember = "Descripcion";
            }
        }
        #endregion
    }
}