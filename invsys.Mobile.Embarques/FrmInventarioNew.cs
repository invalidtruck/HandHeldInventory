﻿using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Net;
using System.Windows.Forms;
using ErikEJ.SqlCe;
//using invsys.Mobile.Embarques.wspedidos; // testing porpuses
using invsys.Mobile.Embarques.embarques; // real One

namespace invsys.Mobile.Embarques
{
    public partial class FrmInventarioNew : Form
    {
        #region Propiedades
        public string cnnstr { get; set; }
        #endregion

        #region Contructor
        public FrmInventarioNew(int idusuario, int idCon)
        {
            this.IdConexion = idCon;
            this.idusuario = idusuario;
            this.InitializeComponent();
            this.dir = this.dir.Substring(0, this.dir.LastIndexOf("\\"));
            this.cnnstr = "Data Source=" + (this.dir + "\\EmbInv.sdf") + ";Max Database Size=4091";

            this.cnn = new SqlCeConnection(this.cnnstr);
        }
        public FrmInventarioNew()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos


        private void BULK(DataTable dt)
        {
            var options = new SqlCeBulkCopyOptions();
            options = options |= SqlCeBulkCopyOptions.KeepNulls;
            using (SqlCeBulkCopy bc = new SqlCeBulkCopy(this.cnn, options))
            {
                bc.DestinationTableName = "CatInventario";
                bc.WriteToServer(dt);
            }
        }
        private void EliminaInventario(bool traerws)
        {
            try
            {
                var cmd = new SqlCeCommand("delete Inventario", this.cnn);
                if (this.cnn.State == ConnectionState.Closed)
                    this.cnn.Open();
                cmd.ExecuteNonQuery();

                cmd = new SqlCeCommand("delete inventarioComentarios", this.cnn);
                cmd.ExecuteNonQuery();
                if (traerws)
                    this.CargaWS();

            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("Func: EliminaInventario Err: " + ex.Message);
            }
            finally
            {
                this.cnn.Close();
            }
        }
        private void EliminaLote(string cb)
        {
            try
            {
                SqlCeCommand sqlCeCommand = new SqlCeCommand("DELETE FROM Inventario where cb =@cb", this.cnn);
                sqlCeCommand.Parameters.AddWithValue("@cb", cb);
                if (this.cnn.State == ConnectionState.Closed)
                    this.cnn.Open();
                sqlCeCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("Fallo al eliminar la información Err: " + ex.Message);
            }
            finally
            {
                this.cnn.Close();
            }
        }
        private void Clean()
        {
            this.txtAlmacen.Text = "";
            this.txtDesc.Text = "";
            this.txtEspesor.Text = "";
            this.txtLongitud.Text = "";
            this.txtLote.Text = "";
            this.txtMedida.Text = "";
            this.txtNorma.Text = "";
            this.txtUbicacion.Text = "";
            this.txtCB.Text = "";
            this.txtCB.Focus();
            this.lblIdArt.Text = "";
            this.EnableDisable(false, false);
            this.lboxComentarios.DataSource = null;
        }
        private void EnableDisable(bool en, bool no)
        {
            this.txtNorma.Enabled = en;
            this.txtUbicacion.Enabled = en;
            this.txtAlmacen.Enabled = no;
            this.txtDesc.Enabled = no;
            this.txtEspesor.Enabled = no;
            this.txtLote.Enabled = no;
            this.txtMedida.Enabled = no;

        }
        private void CargarInventario()
        {
            try
            {
                var sqlCeCommand = new SqlCeCommand("SELECT * FROM Inventario", this.cnn);
                if (this.cnn.State != ConnectionState.Open)
                    this.cnn.Open();
                var sqlCeDataReader = sqlCeCommand.ExecuteReader();
                var dataTable = new DataTable();
                dataTable.Load((IDataReader)sqlCeDataReader);
                this.cnn.Close();
                this.dgvInventario.DataSource = (object)dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Func:CargarInventario \n Err: " + ex.Message);
            }
            finally
            {
                this.cnn.Close();
            }
        }
        private void CargarInfoLote()
        {
            try
            {
                if (this.txtCB.Text.Trim() == "")
                    return;
                var sqlCeCommand = new SqlCeCommand("select * from CatInventario where Lote = @lote", this.cnn);
                if (this.cnn.State == ConnectionState.Closed)
                    this.cnn.Open();
                sqlCeCommand.Parameters.AddWithValue("@lote", txtCB.Text);
                var sqlCeDataReader = sqlCeCommand.ExecuteReader();
                var dataTable = new DataTable();
                dataTable.Load((IDataReader)sqlCeDataReader);
                if (dataTable.Rows.Count > 0)
                {
                    this.txtCB.Text = dataTable.Rows[0]["CB"].ToString();
                    this.txtMedida.Text = dataTable.Rows[0]["medida"].ToString();
                    this.txtAlmacen.Text = dataTable.Rows[0]["Almacen"].ToString();
                    this.txtLote.Text = dataTable.Rows[0]["Lote"].ToString();
                    this.txtLongitud.Text = dataTable.Rows[0]["Longitud"].ToString();
                    this.txtNorma.Text = dataTable.Rows[0]["Norma"].ToString();
                    this.txtEspesor.Text = dataTable.Rows[0]["Espesor"].ToString();
                    this.txtDesc.Text = dataTable.Rows[0]["Descripcion"].ToString();
                    this.txtUbicacion.Text = dataTable.Rows[0]["Ubicacion"].ToString();
                    this.lblIdArt.Text = dataTable.Rows[0]["IdInventarioServer"].ToString();
                    this.EnableDisable(true, false);
                }
                else if (MessageBox.Show("No existe articulo con ese codigo de barras \n Desea agregarlo?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    this.EnableDisable(true, true);
                }
                else
                {
                    this.Clean();
                    this.EnableDisable(false, false);
                }
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
        private void addComment()
        {
            try
            {
                if (lblIdArt.Text == "")
                    if (txtCB.Text == "")
                    {
                        MessageBox.Show("Favor de seleccionar un registro");
                        return;
                    }


                var comentario = "";
                if (cmbComentario.Text.ToLower().Contains("Agregar comentario"))
                    comentario = Microsoft.VisualBasic.Interaction.InputBox("Agregar Comentario", "Seleccione", "", -1, -1);
                else if (cmbComentario.Text.ToLower().Contains("tiene doble número"))
                    comentario = "Tiene doble numero: " + Microsoft.VisualBasic.Interaction.InputBox("Agregar Comentario", "Seleccione", "1", -1, -1);
                else if (cmbComentario.Text.ToLower().Contains("otro"))
                    comentario = "Otro: " + Microsoft.VisualBasic.Interaction.InputBox("Agregar Comentario", "Seleccione", "", -1, -1);                
                else
                    comentario = cmbComentario.Text;

                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
                var cmd = new SqlCeCommand("insert into inventarioComentarios(Comentario,Fecha,Lote) values(@Comentario,@Fecha,@lote)", cnn);
                cmd.Parameters.AddWithValue("@Comentario", comentario);
                cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                cmd.Parameters.AddWithValue("@lote", txtCB.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Err: " + ex.Message);
            }
            finally
            {
                CargarComentariosList();
                cnn.Close();
            }
        }

        private void CargarComentariosList()
        {
            try
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
                var cmd = new SqlCeCommand("Select * from InventarioComentarios where Lote = @lote ORDER BY Fecha DESC", cnn);
                cmd.Parameters.AddWithValue("@lote", txtCB.Text);
                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                lboxComentarios.DataSource = dt;
                lboxComentarios.DisplayMember = "Comentario";
                lboxComentarios.ValueMember = "IdComentario";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Func:CargarComentariosList \n Err:" + ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
        private void CargarComentarios()
        {
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();

            var cmd = new SqlCeCommand("select * from ComentariosDefault", cnn);
            var dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            this.cmbComentario.DataSource = dt;
            this.cmbComentario.DisplayMember = "Comentario";
            this.cmbComentario.ValueMember = "IdComentario";
        }

        private void CargarComentariosWS()
        {
            try
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
                // borramos los comentarios existentes
                var cmd = new SqlCeCommand("DELETE ComentariosDefault", cnn);
                cmd.ExecuteNonQuery();

                var ws = new WSPedidos();
                var DTComentarios = ws.GetComentarios(this.IdConexion).Tables[0];

                foreach (DataRow dr in DTComentarios.Rows)
                {
                    cmd = new SqlCeCommand("INSERT INTO ComentariosDefault values (@idComentario, @Comentario)", cnn);
                    cmd.Parameters.AddWithValue("@idComentario", Convert.ToInt32(dr[0]));
                    cmd.Parameters.AddWithValue("@Comentario", dr[1].ToString());
                    cmd.ExecuteNonQuery();
                }
                CargarComentarios();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Func: CargarFiltro \n Err: " + ex.Message);
            }
        }

        private void CargarFiltro()
        {
            try
            {
                var wsPedidos = new WSPedidos();

                ServicePointManager.Expect100Continue = false;

                //this.cmbFiltro.DataSource = wsPedidos.GetFiltro(this.IdConexion).Tables[0];
                //this.cmbFiltro.ValueMember = "idfiltro";
                //this.cmbFiltro.DisplayMember = "descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Func: CargarFiltro \n Valores :idcon" + this.IdConexion);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion


        private void CargaWS()
        {
            ServicePointManager.Expect100Continue = false;

            var dts = new WSPedidos().GetInventoryParameters(this.IdConexion).Tables[0];
            int MinValue = (int)dts.Rows[0][1];
            int MaxValue = (int)dts.Rows[0][0];


            var cmd = new SqlCeCommand("delete  CatInventario", cnn);
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();

            cmd.ExecuteNonQuery();

            cmd = new SqlCeCommand("ALTER TABLE [CatInventario] ALTER COLUMN idcat IDENTITY (1,1)");
            cmd.ExecuteNonQuery();


            cnn.Close();

            var wsPedidos = new WSPedidos();
            var datos = new DataTable();
            try
            {
                var Start = MinValue;
                while (Start < MaxValue)
                {
                    if (MaxValue - Start >= 3000)
                    {
                        var inv = wsPedidos.GetInventory(Start, Start + 3000, this.IdConexion);
                        datos = inv.Tables[0];
                    }
                    else
                        datos = wsPedidos.GetInventory(Start, MaxValue, this.IdConexion).Tables[0];

                    this.BULK(datos);
                    Start = Start + 3000;
                }
                MessageBox.Show("Carga Completa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Func: CargarDatosWS Proc:wsPedidos Web  \n Err:" + ex.Message);

            }
            finally
            {
                this.cnn.Close();
            }

        }
        #region Eventos


        private void FrmInventario_Load(object sender, EventArgs e)
        {
            this.CargarInventario();
            //this.CargarFiltro();
            this.CargarComentarios();
        }


        private void txtCB_Validated(object sender, EventArgs e)
        {
            CargarInfoLote();

        }


        private void menuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // cargar WS
        private void menuItem4_Click_1(object sender, EventArgs e)
        {
            this.CargaWS();
        }

        //Enviar a WS Inventario
        private void menuItem5_Click_1(object sender, EventArgs e)
        {
            try
            {
                ServicePointManager.Expect100Continue = false;
                var wsPedidos = new WSPedidos();
                var sqlCeCommand = new SqlCeCommand("select * FROM Inventario", this.cnn);
                if (this.cnn.State == ConnectionState.Closed)
                    this.cnn.Open();

                var sqlCeDataReader = sqlCeCommand.ExecuteReader();
                var dataTable = new DataTable();
                dataTable.Load(sqlCeDataReader);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var sqlCecom = new SqlCeCommand("select comentario FROM InventarioComentarios where lote = @lote", this.cnn);
                    sqlCecom.Parameters.AddWithValue("@lote", dataRow[0]);
                    if (this.cnn.State == ConnectionState.Closed)
                        this.cnn.Open();
                    var comentarios = "";

                    var dr = sqlCecom.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(dr);

                    foreach (DataRow dtr in dt.Rows)
                        comentarios += dtr["Comentario"].ToString() + "|";

                    InventarioEntity parametro = new InventarioEntity()
                    {
                        Almacen = dataRow["Almacen"].ToString(),
                        CodigoArticulo = dataRow["CodigoBarras"].ToString(),
                        Descripcion = dataRow["Descripcion"].ToString(),
                        Espesor = dataRow["Espesor"].ToString(),
                        IdUsuario = Convert.ToInt32(dataRow["idusuario"]),
                        Longitud = dataRow["Longitud"].ToString(),
                        Lote = dataRow["Lote"].ToString(),
                        Medida = dataRow["Medida"].ToString(),
                        Norma = dataRow["Norma"].ToString(),
                        Ubicacion = dataRow["ubicacion"].ToString(),
                        IdInventarioServer = Convert.ToInt32(dataRow["idArticulo"]),
                        Cantidad = Convert.ToInt32(dataRow["cantidad"]),
                        Comentarios = comentarios
                    };
                    ServicePointManager.Expect100Continue = false;
                    wsPedidos.InsertInventory(parametro, this.IdConexion);
                }
                this.EliminaInventario(true);
                this.dgvInventario.DataSource = null;
                MessageBox.Show("Se ha enviado el inventario al servidor");
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("ha ocurrdio un error al insertar los datos " + ex.Message);
            }
            finally
            {
                if (this.cnn.State == ConnectionState.Open)
                    this.cnn.Close();
            }
        }
        private void menuItem6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea eliminar el inventario?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                this.EliminaInventario(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarInfoLote();
        }
        private void dgvInventario_DoubleClick(object sender, EventArgs e)
        {
            var manager = (CurrencyManager)this.BindingContext[dgvInventario.DataSource];
            var row2Del = ((System.Data.DataRowView)(manager.Current)).Row[1].ToString();
            if (MessageBox.Show("Desea eliminar del inventario el lote :" + row2Del, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                //int iRow = dgvCatalogo.CurrentCell.RowNumber();
                var currentIndex = manager.Position;
                manager.RemoveAt(currentIndex);
                manager.Refresh();
                // borrar en BD
                try
                {
                    if (this.cnn.State == ConnectionState.Closed)
                        this.cnn.Open();
                    var cmd = new SqlCeCommand("DELETE FROM Inventario where CodigoBarras = @cb", this.cnn);
                    cmd.Parameters.AddWithValue("@cb", row2Del);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
            }
        }

        private void BtnAñadir_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();

                var cmd = new SqlCeCommand("select count(1) from inventario where lote= @lote", cnn);
                cmd.Parameters.AddWithValue("@lote", txtCB.Text);
                if ((int)cmd.ExecuteScalar() > 0)
                    if (MessageBox.Show("Ya existe un registro con ese codigo de lote \n ¿Desea agregar uno nuevo?", "Alerta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    {
                        this.Clean();
                        return;
                    }

                var idInventarioServer = "0";
                if (lblIdArt.Text != "")
                    idInventarioServer = lblIdArt.Text;

                var sqlCeCommand = new SqlCeCommand("INSERT INTO Inventario VALUES(@CB,@Cantidad,@Medida,@Almacen,@Lote,@Longitud,@Norma,@Espesor,@Desc,@ubicacion,@idUsuario,@idArticulo,@IdCon)", this.cnn);
                sqlCeCommand.Parameters.AddWithValue("@IdCon", this.IdConexion);
                sqlCeCommand.Parameters.AddWithValue("@CB", txtCB.Text);
                sqlCeCommand.Parameters.AddWithValue("@Cantidad", 1);
                sqlCeCommand.Parameters.AddWithValue("@Medida", txtMedida.Text);
                sqlCeCommand.Parameters.AddWithValue("@Lote", txtLote.Text);
                sqlCeCommand.Parameters.AddWithValue("@Longitud", txtLongitud.Text);
                sqlCeCommand.Parameters.AddWithValue("@Norma", txtNorma.Text);
                sqlCeCommand.Parameters.AddWithValue("@Espesor", txtEspesor.Text);
                sqlCeCommand.Parameters.AddWithValue("@Desc", txtDesc.Text);
                sqlCeCommand.Parameters.AddWithValue("@Almacen", txtAlmacen.Text);
                sqlCeCommand.Parameters.AddWithValue("@ubicacion", txtUbicacion.Text);
                sqlCeCommand.Parameters.AddWithValue("@idArticulo", idInventarioServer);
                sqlCeCommand.Parameters.AddWithValue("@idUsuario", idusuario);
                sqlCeCommand.ExecuteReader();

                this.CargarInventario();
                this.Clean();
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

        private void txtCB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.CargarInfoLote();
            }
        }


        private void btnComentarios_Click(object sender, EventArgs e)
        {
            addComment();
        }
        private void mnuComentarios_Click(object sender, EventArgs e)
        {
            CargarComentariosWS();
        }

        #endregion






    }
}