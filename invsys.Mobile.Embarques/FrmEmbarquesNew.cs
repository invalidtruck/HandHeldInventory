using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Net;
using System.Windows.Forms;
using ErikEJ.SqlCe;
//using invsys.Mobile.Embarques.wspedidos; // testing porpuses
using invsys.Mobile.Embarques.embarques; // real One



namespace invsys.Mobile.Embarques
{
    public partial class FrmEmbarquesNew : Form
    {
        private SqlCeConnection cnn;
        public FrmEmbarquesNew()
        {
            InitializeComponent();
            this.dir = this.dir.Substring(0, this.dir.LastIndexOf("\\"));
            this.cnnstr = "Data Source=" + (this.dir + "\\EmbInv.sdf") + ";Max Database Size=4091";
            this.cnn = new SqlCeConnection(this.cnnstr);


        }
        public FrmEmbarquesNew(int iduser, int idCon)
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

                //IPHostEntry ipEntry = Dns.GetHostByName(Dns.GetHostName());
                //IPAddress[] addr = ipEntry.AddressList;
                //foreach (var ips in addr)
                //{
                //    try
                //    {
                //        this.IdHandHeld = Convert.ToInt32(addr[0].ToString().Replace(".", ""));
                //    }
                //    catch (Exception)
                //    {
                //    }
                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void FrmEmbarquesNew_Load_1(object sender, EventArgs e)
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

                ServicePointManager.Expect100Continue = false;

                this.cmbFiltro.DataSource = wsPedidos.GetFiltro(this.idConexion).Tables[0];
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
                SqlCeCommand sqlCeCommand = new SqlCeCommand("SELECT IdEmbarque,Descripcion FROM Embarque where IdCon = @Idcon", this.cnn);
                sqlCeCommand.Parameters.AddWithValue("@Idcon", this.idConexion);
                if (this.cnn.State != ConnectionState.Open)
                    this.cnn.Open();
                SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load((IDataReader)sqlCeDataReader);
                if (dataTable.Rows.Count <= 0)
                {
                    this.cmbEmbarque.DataSource = null;
                    return;
                }
                this.cmbEmbarque.DataSource = (object)dataTable;
                this.cmbEmbarque.ValueMember = "IdEmbarque";
                this.cmbEmbarque.DisplayMember = "Descripcion";
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

        private void BtnDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCeCommand sqlCeCommand = new SqlCeCommand("SELECT * FROM CatMaterial WHERE CodigoBarras = @CB and idCon = @IdCon ", this.cnn);
                sqlCeCommand.Parameters.AddWithValue("@CB", this.txtCB.Text);
                sqlCeCommand.Parameters.AddWithValue("@IdCon", this.idConexion);
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
                var sqlCeCommand1 = new SqlCeCommand("select count(1) from EmbarqueMaterial where  CodigoBarras= @CB ", this.cnn);
                sqlCeCommand1.Parameters.AddWithValue("@CB", txtCB.Text);
                if (this.cnn.State == ConnectionState.Closed)
                    this.cnn.Open();
                if ((int)sqlCeCommand1.ExecuteScalar() > 0)
                {
                    MessageBox.Show("Ese lote ya fue utilizado ");
                    return;
                }
                this.cnn.Close();
                float num2 = (float)((double)Convert.ToSingle(this.lblLongitud.Text) * (double)Convert.ToSingle(this.lblPesoTeorico.Text) / 1000.0);
                this.peso += num2;
                if ((double)this.peso >= 30.0 & (double)this.peso <= 34.9900016784668)
                {
                    int num3 = (int)MessageBox.Show(string.Format("El contenedor/caja ya esta llegando a su capacidad maxima \n actualmente hay  {0}Kgs", (object)this.peso), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                if ((double)this.peso >= 35.0 && MessageBox.Show("A embarcado el peso maximo permitido (35tns)?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                    return;
                SqlCeCommand sqlCeCommand2 = new SqlCeCommand("INSERT INTO EmbarqueMaterial VALUES(@idE,@CB,@IdSalida,@Peso,@IdCon)", this.cnn);
                sqlCeCommand2.Parameters.AddWithValue("@IdCon", this.idConexion);
                sqlCeCommand2.Parameters.AddWithValue("@idE", this.cmbEmbarque.SelectedValue);
                sqlCeCommand2.Parameters.AddWithValue("@CB", (object)this.txtCB.Text);
                sqlCeCommand2.Parameters.AddWithValue("@IdSalida", (object)this.lblIdSalida.Text);
                sqlCeCommand2.Parameters.AddWithValue("@Peso", (object)num2);
                if (this.cnn.State == ConnectionState.Closed)
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
                SqlCeCommand sqlCeCommand = new SqlCeCommand("select * from catMaterial where lote = @CB and IdCon = @IdCon", this.cnn);
                this.cnn.Open();
                sqlCeCommand.Parameters.AddWithValue("@CB", (object)this.txtCB.Text);
                sqlCeCommand.Parameters.AddWithValue("@IdCon", this.idConexion);
                SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load((IDataReader)sqlCeDataReader);
                int sel = 0;
                if (dataTable.Rows.Count == 1)
                {
                    sel = 0;
                }
                else if (dataTable.Rows.Count > 1)
                {
                    var str = string.Format("Existen {0} de un registro con este Codigo, seleccione cual desea agregar");
                    sel = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox(str, "Seleccione", "1", -1, -1));
                }
                else
                {
                    int num = (int)MessageBox.Show("No existe articulo con ese codigo de barras");
                    this.clean();
                    return;
                }

                this.lblMedida.Text = dataTable.Rows[sel]["medida"].ToString();
                this.lblAlmacen.Text = dataTable.Rows[sel]["Almacen"].ToString();
                this.lblLote.Text = dataTable.Rows[sel]["Lote"].ToString();
                this.lblLongitud.Text = dataTable.Rows[sel]["Longitud"].ToString();
                this.lblNorma.Text = dataTable.Rows[sel]["Norma"].ToString();
                this.lblEspesor.Text = dataTable.Rows[sel]["Espesor"].ToString();
                this.lblDesc.Text = dataTable.Rows[sel]["Descripcion"].ToString();
                this.lblUbicacion.Text = dataTable.Rows[sel]["Ubicacion"].ToString();
                this.lblIdSalida.Text = dataTable.Rows[sel]["IdSalidaDatos"].ToString();
                this.lblPesoTeorico.Text = dataTable.Rows[sel]["PesoTeorico"].ToString();

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
            int num = (int)new FrmInventarioNew(this.idusuario, this.idConexion).ShowDialog();
        }

        private void tabCaptura_Click(object sender, EventArgs e)
        {
        }

        private void menuNuevoEmbarque_Click(object sender, EventArgs e)
        {
            this.refrescar = true;
            int num = (int)new FrmAddEmbarqueN(this.idusuario, this.idConexion).ShowDialog();
        }

        private void CargarDatosWS()
        {
            string str = "";
            try
            {

                this.cnn.Open();
                new SqlCeCommand("delete from CatMaterial where IdCon =" + this.idConexion.ToString(), this.cnn).ExecuteNonQuery();
                ServicePointManager.Expect100Continue = false;
                var wsPedidos = new WSPedidos();
                var dataTable1 = new DataTable();
                DataTable dataTable2;
                try
                {
                    dataTable2 = wsPedidos.GetParameter(this.cmbFiltro.Text, this.idConexion, this.IdHandHeld).Tables[0];
                }
                catch (Exception ex)
                {
                    int num = (int)MessageBox.Show("No se puede conectar al servidor, favor de verificar su conexion");
                    return;
                }
                

                int MinValue = (int)dataTable2.Rows[0][0];
                int MaxValue = (int)dataTable2.Rows[0][1];

                if (MinValue ==0 | MaxValue ==0)
                {
                    MessageBox.Show("No existen lotes con estos parametros: \n {0}", this.cmbFiltro.Text);
                    return;
                }

                str = string.Concat(str, "tengo parametros ", MaxValue, "\n");
                this.BULK(wsPedidos.GetValues(MinValue, MaxValue, this.idConexion, this.IdHandHeld).Tables[0]);
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

        private void CargarEmbarques_Detalle()
        {
            try
            {
                if (this.cmbEmbarque.Items.Count == 0)
                    return;
                int idemb = 0;
                try
                {
                    idemb = (int)((System.Data.DataRowView)(cmbEmbarque.SelectedValue)).Row[0];
                }
                catch (Exception ex)
                {
                    idemb = (int)cmbEmbarque.SelectedValue;
                }
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();

                var sqlCeCommand1 = new SqlCeCommand("select * from embarque where idembarque = @idEmbarque", this.cnn);
                sqlCeCommand1.Parameters.AddWithValue("@IdEmbarque", idemb);
                var sqlCeDataReader1 = sqlCeCommand1.ExecuteReader();
                var dataTable1 = new DataTable();
                dataTable1.Load((IDataReader)sqlCeDataReader1);
                this.peso = dataTable1.Rows.Count <= 0 ? 0.0f : (dataTable1.Rows[0].IsNull("peso") ? 0.0f : Convert.ToSingle(dataTable1.Rows[0]["peso"]));
                var sqlCeCommand2 = new SqlCeCommand("select * from EmbarqueMaterial where idEmbarque = @IdEmbarque", this.cnn);
                sqlCeCommand2.Parameters.AddWithValue("@IdEmbarque", idemb);

                var sqlCeDataReader2 = sqlCeCommand2.ExecuteReader();
                var dataTable2 = new DataTable();
                dataTable2.Load((IDataReader)sqlCeDataReader2);
                if (dataTable2.Rows.Count > 0)
                {
                    this.dgvCatalogo.DataSource = (object)dataTable2;
                    this.lblArt.Text = "Art " + dataTable2.Rows.Count.ToString();
                }
                this.dgvCatalogo.DataSource = (object)dataTable2;
            }
            catch (Exception ex)
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
                            return;
                        }
                        if (cancelar == 2)
                        {
                            MessageBox.Show("es 2");
                            return;
                        }
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
                int ide = (int)cmbEmbarque.SelectedValue;

                if (this.cnn.State == ConnectionState.Closed)
                    this.cnn.Open();
                var cmd = new SqlCeCommand("DELETE FROM EMBARQUE WHERE IdEmbarque = @IdE", this.cnn);
                cmd.Parameters.AddWithValue("@IdE", ide);
                cmd.ExecuteNonQuery();
                var cmd2 = new SqlCeCommand("DELETE FROM EmbarqueMaterial WHERE IdEmbarque = @IdE", this.cnn);
                cmd2.Parameters.AddWithValue("@IdE", ide);
                cmd2.ExecuteNonQuery();
                int num = (int)MessageBox.Show("Se ha eliminado la información de embarques");
                this.CargarEmbarques();
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
            try
            {
                SqlCeBulkCopyOptions options = new SqlCeBulkCopyOptions();

                options = options |= SqlCeBulkCopyOptions.KeepNulls;

                using (SqlCeBulkCopy bc = new SqlCeBulkCopy(this.cnnstr, options))
                {
                    bc.DestinationTableName = "CatMaterial";
                    bc.WriteToServer(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void MenuSalir_Popup(object sender, EventArgs e)
        {

        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvCatalogo_DoubleClick(object sender, EventArgs e)
        {
            var manager = (CurrencyManager)this.BindingContext[dgvCatalogo.DataSource];
            var row2Del = ((System.Data.DataRowView)(manager.Current)).Row[1].ToString();
            if (MessageBox.Show("Desea eliminar del embarque el lote :" + row2Del, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
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
                    var cmd = new SqlCeCommand("DELETE FROM EmbarqueMaterial where idembarque = @idEmbarque and CodigoBarras = @cb", this.cnn);
                    cmd.Parameters.AddWithValue("@idEmbarque", cmbEmbarque.SelectedValue);
                    cmd.Parameters.AddWithValue("@cb", row2Del);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                finally { cnn.Close(); }
            }
        }

        private void cmbEmbarque_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pnlDesc.Enabled = true;
            this.txtCB.Enabled = true;
            this.Limpiar();
            this.CargarEmbarques_Detalle();
        }

        private void txtCB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                this.validarLote();
            }
        }
        /// <summary>
        /// Transferir pedido a otro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem7_Click(object sender, EventArgs e)
        {
            try
            {
                panel1.Visible = true;
                //cargar los combos
                var cmd = new SqlCeCommand("select * from embarque where idCon = @IdCon", cnn);
                cmd.Parameters.AddWithValue("@IdCon", this.idConexion);
                if (cnn.State == ConnectionState.Closed) cnn.Open();
                var dr = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(dr);
                cmbDe.DataSource = dt;
                cmbDe.DisplayMember = "Descripcion";
                cmbDe.ValueMember = "IdEmbarque";

                var cmd2 = new SqlCeCommand("select * from embarque where idCon = @IdCon", cnn);
                cmd.Parameters.AddWithValue("@IdCon", this.idConexion);
                if (cnn.State == ConnectionState.Closed) cnn.Open();
                var dr2 = cmd.ExecuteReader();
                var dt2 = new DataTable();
                dt2.Load(dr2);

                cmbA.DataSource = dt2;
                cmbA.DisplayMember = "Descripcion";
                cmbA.ValueMember = "IdEmbarque";
            }
            catch (Exception ex)
            {
            }
            finally { cnn.Close(); }
        }

        private void BtnCanTrans_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
            // TO DO , agregar los combobox
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (cmbDe.SelectedValue != cmbA.SelectedValue)
            {
                try
                {
                    var iDEmA = (int)cmbA.SelectedValue;
                    var iDEmDe = (int)cmbDe.SelectedValue;

                    var cmd = new SqlCeCommand(
                        "UPDATE EmbarqueMaterial SET IdEmbarque=@IdEmA Where IdEmbarque = @IdEmDe",
                        cnn);
                    cmd.Parameters.AddWithValue("@IdEmA", iDEmA);
                    cmd.Parameters.AddWithValue("@IdEmDe", iDEmDe);
                    if (cnn.State == ConnectionState.Closed) cnn.Open();
                    cmd.ExecuteNonQuery();
                    this.CargarEmbarques_Detalle();
                    MessageBox.Show("Se ha transferido el Pedido");
                    panel1.Visible = false;

                }
                catch (Exception ex)
                {
                }
                finally
                {
                    cnn.Close();
                }
            }
            else
            {
                MessageBox.Show("Es el mismo pedido, favor de seleccionar otro");
            }
        }
    }
}

