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
//using invsys.Mobile.Embarques.wspedidos; // testing porpuses
using invsys.Mobile.Embarques.embarques; // real One

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
#if DEBUG
                    new FrmEmbarquesNew(1, 1).Show();
#else 
                    new FrmEmbarquesNew(1, (int)ddlConexiones.SelectedValue).Show();
#endif
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

        private void FrmLoginNew_Load(object sender, EventArgs e)
        {
            RefreshDDLEmpresas();
        }

        private void RefreshDDLEmpresas()
        {
            try
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();

                var cmd = new SqlCeCommand("select * from catConexiones", cnn);
                var dr = cmd.ExecuteReader();
                var dts = new DataTable();
                dts.Load(dr);
                if (dts.Rows.Count > 0)
                {
                    this.ddlConexiones2.ValueMember = "idConexion";
                    this.ddlConexiones2.DisplayMember = "Descripcion";
                    this.ddlConexiones2.DataSource = dts;
                }
                //foreach (DataRow item in dts.Rows)
                //{
                //    ddlConexiones.Items.Add(new { id = item[0].ToString(), name = item[1].ToString() });
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Favor de reportar el siguiente error al area de sistemas: \n" + ex.Message);
            }
        }

        private void mnuUpdateE_Click(object sender, EventArgs e)
        {
            try
            {
                ServicePointManager.Expect100Continue = false;
                var ws = new WSPedidos();

                var ds = ws.GetEmpresas();

                var dt = ds.Tables[0];
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();

                var cmd = new SqlCeCommand("DELETE CatConexiones", cnn);
                cmd.ExecuteNonQuery();
                foreach (DataRow item in dt.Rows)
                {

                    cmd = new SqlCeCommand("INSERT INTO CatConexiones values( @NombreEmpresa,@IdCon)", cnn);
                    cmd.Parameters.AddWithValue("@IdCon", item["IdCon"]);
                    cmd.Parameters.AddWithValue("@NombreEmpresa", item["NombreEmpresa"]);
                    cmd.ExecuteNonQuery();
                }
                RefreshDDLEmpresas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}