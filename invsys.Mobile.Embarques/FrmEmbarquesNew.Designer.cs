using System.Reflection;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace invsys.Mobile.Embarques
{
    partial class FrmEmbarquesNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private string dir = Assembly.GetExecutingAssembly().GetName().CodeBase;
        private int IdHandHeld = 0;
        private string cnnstr = "";
        private float peso = 0.0f;
        private float pesoMaterial = 0.0f;
        private bool refrescar = false;
        public int idusuario { get; set; }
        public int idConexion { get; set; }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblIdSalida = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCaptura = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCanTrans = new System.Windows.Forms.Button();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.cmbA = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDe = new System.Windows.Forms.ComboBox();
            this.lblPed1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.BtnGrabar = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbEmbarque = new System.Windows.Forms.ComboBox();
            this.pnlDesc = new System.Windows.Forms.Panel();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtLinea = new System.Windows.Forms.TextBox();
            this.txtCarga = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPesoTeorico = new System.Windows.Forms.Label();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.lblEspesor = new System.Windows.Forms.Label();
            this.lblNorma = new System.Windows.Forms.Label();
            this.lblLongitud = new System.Windows.Forms.Label();
            this.lblLote = new System.Windows.Forms.Label();
            this.lblMedida = new System.Windows.Forms.Label();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.txtCB = new System.Windows.Forms.TextBox();
            this.lblTubo = new System.Windows.Forms.Label();
            this.tabLista = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.lblArt = new System.Windows.Forms.Label();
            this.dgvCatalogo = new System.Windows.Forms.DataGrid();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuNuevoEmbarque = new System.Windows.Forms.MenuItem();
            this.MenuCargarDatos = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.MenuSalir = new System.Windows.Forms.MenuItem();
            this.tabControl1.SuspendLayout();
            this.tabCaptura.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlDesc.SuspendLayout();
            this.tabLista.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIdSalida
            // 
            this.lblIdSalida.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblIdSalida.Location = new System.Drawing.Point(10, 194);
            this.lblIdSalida.Name = "lblIdSalida";
            this.lblIdSalida.Size = new System.Drawing.Size(31, 15);
            this.lblIdSalida.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCaptura);
            this.tabControl1.Controls.Add(this.tabLista);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 268);
            this.tabControl1.TabIndex = 1;
            // 
            // tabCaptura
            // 
            this.tabCaptura.AutoScroll = true;
            this.tabCaptura.Controls.Add(this.panel1);
            this.tabCaptura.Controls.Add(this.label1);
            this.tabCaptura.Controls.Add(this.cmbFiltro);
            this.tabCaptura.Controls.Add(this.BtnGrabar);
            this.tabCaptura.Controls.Add(this.lblId);
            this.tabCaptura.Controls.Add(this.label17);
            this.tabCaptura.Controls.Add(this.cmbEmbarque);
            this.tabCaptura.Controls.Add(this.pnlDesc);
            this.tabCaptura.Controls.Add(this.BtnBuscar);
            this.tabCaptura.Controls.Add(this.BtnLimpiar);
            this.tabCaptura.Controls.Add(this.BtnAgregar);
            this.tabCaptura.Controls.Add(this.txtCB);
            this.tabCaptura.Controls.Add(this.lblTubo);
            this.tabCaptura.Location = new System.Drawing.Point(0, 0);
            this.tabCaptura.Name = "tabCaptura";
            this.tabCaptura.Size = new System.Drawing.Size(240, 245);
            this.tabCaptura.Text = "Captura";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnCanTrans);
            this.panel1.Controls.Add(this.btnTransfer);
            this.panel1.Controls.Add(this.cmbA);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbDe);
            this.panel1.Controls.Add(this.lblPed1);
            this.panel1.Location = new System.Drawing.Point(0, 239);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 51);
            this.panel1.Visible = false;
            // 
            // BtnCanTrans
            // 
            this.BtnCanTrans.Location = new System.Drawing.Point(144, 162);
            this.BtnCanTrans.Name = "BtnCanTrans";
            this.BtnCanTrans.Size = new System.Drawing.Size(72, 20);
            this.BtnCanTrans.TabIndex = 6;
            this.BtnCanTrans.Text = "Cancelar";
            this.BtnCanTrans.Click += new System.EventHandler(this.BtnCanTrans_Click);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(7, 162);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(72, 20);
            this.btnTransfer.TabIndex = 5;
            this.btnTransfer.Text = "Transferir";
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // cmbA
            // 
            this.cmbA.Location = new System.Drawing.Point(7, 123);
            this.cmbA.Name = "cmbA";
            this.cmbA.Size = new System.Drawing.Size(210, 22);
            this.cmbA.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 20);
            this.label2.Text = "Transferir pedido a:";
            // 
            // cmbDe
            // 
            this.cmbDe.Location = new System.Drawing.Point(9, 54);
            this.cmbDe.Name = "cmbDe";
            this.cmbDe.Size = new System.Drawing.Size(210, 22);
            this.cmbDe.TabIndex = 1;
            // 
            // lblPed1
            // 
            this.lblPed1.Location = new System.Drawing.Point(9, 30);
            this.lblPed1.Name = "lblPed1";
            this.lblPed1.Size = new System.Drawing.Size(177, 20);
            this.lblPed1.Text = "Pedido a Transferir:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.Text = "Filtro carga";
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.Location = new System.Drawing.Point(94, 57);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(126, 22);
            this.cmbFiltro.TabIndex = 18;
            this.cmbFiltro.Visible = false;
            // 
            // BtnGrabar
            // 
            this.BtnGrabar.Font = new System.Drawing.Font("Tahoma", 6.5F, System.Drawing.FontStyle.Regular);
            this.BtnGrabar.Location = new System.Drawing.Point(144, 196);
            this.BtnGrabar.Name = "BtnGrabar";
            this.BtnGrabar.Size = new System.Drawing.Size(75, 40);
            this.BtnGrabar.TabIndex = 12;
            this.BtnGrabar.Text = "Enviar Embarques";
            this.BtnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(29, 183);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(98, 10);
            this.lblId.Text = " ";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(9, 6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 20);
            this.label17.Text = "Pedido:";
            // 
            // cmbEmbarque
            // 
            this.cmbEmbarque.Location = new System.Drawing.Point(75, 6);
            this.cmbEmbarque.Name = "cmbEmbarque";
            this.cmbEmbarque.Size = new System.Drawing.Size(144, 22);
            this.cmbEmbarque.TabIndex = 8;
            this.cmbEmbarque.SelectedIndexChanged += new System.EventHandler(this.cmbEmbarque_SelectedIndexChanged);
            // 
            // pnlDesc
            // 
            this.pnlDesc.Controls.Add(this.txtValor);
            this.pnlDesc.Controls.Add(this.txtLinea);
            this.pnlDesc.Controls.Add(this.txtCarga);
            this.pnlDesc.Controls.Add(this.label6);
            this.pnlDesc.Controls.Add(this.label5);
            this.pnlDesc.Controls.Add(this.label4);
            this.pnlDesc.Controls.Add(this.lblIdSalida);
            this.pnlDesc.Controls.Add(this.lblPesoTeorico);
            this.pnlDesc.Controls.Add(this.lblAlmacen);
            this.pnlDesc.Controls.Add(this.lblDesc);
            this.pnlDesc.Controls.Add(this.lblUbicacion);
            this.pnlDesc.Controls.Add(this.lblEspesor);
            this.pnlDesc.Controls.Add(this.lblNorma);
            this.pnlDesc.Controls.Add(this.lblLongitud);
            this.pnlDesc.Controls.Add(this.lblLote);
            this.pnlDesc.Controls.Add(this.lblMedida);
            this.pnlDesc.Location = new System.Drawing.Point(7, 85);
            this.pnlDesc.Name = "pnlDesc";
            this.pnlDesc.Size = new System.Drawing.Size(212, 96);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(68, 64);
            this.txtValor.MaxLength = 25;
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(141, 21);
            this.txtValor.TabIndex = 30;
            this.txtValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValor_KeyDown);
            // 
            // txtLinea
            // 
            this.txtLinea.Location = new System.Drawing.Point(68, 37);
            this.txtLinea.MaxLength = 25;
            this.txtLinea.Name = "txtLinea";
            this.txtLinea.Size = new System.Drawing.Size(141, 21);
            this.txtLinea.TabIndex = 29;
            this.txtLinea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLinea_KeyDown);
            // 
            // txtCarga
            // 
            this.txtCarga.Location = new System.Drawing.Point(68, 10);
            this.txtCarga.MaxLength = 25;
            this.txtCarga.Name = "txtCarga";
            this.txtCarga.Size = new System.Drawing.Size(141, 21);
            this.txtCarga.TabIndex = 23;
            this.txtCarga.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCarga_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(10, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.Text = "Label";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.Text = "Linea";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.Text = "No. Carga";
            // 
            // lblPesoTeorico
            // 
            this.lblPesoTeorico.Location = new System.Drawing.Point(202, 174);
            this.lblPesoTeorico.Name = "lblPesoTeorico";
            this.lblPesoTeorico.Size = new System.Drawing.Size(10, 20);
            this.lblPesoTeorico.Visible = false;
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.Location = new System.Drawing.Point(202, 154);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(10, 20);
            this.lblAlmacen.Visible = false;
            // 
            // lblDesc
            // 
            this.lblDesc.Location = new System.Drawing.Point(204, 1);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(38, 33);
            this.lblDesc.Visible = false;
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.Location = new System.Drawing.Point(202, 134);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(10, 20);
            this.lblUbicacion.Visible = false;
            // 
            // lblEspesor
            // 
            this.lblEspesor.Location = new System.Drawing.Point(202, 114);
            this.lblEspesor.Name = "lblEspesor";
            this.lblEspesor.Size = new System.Drawing.Size(10, 20);
            this.lblEspesor.Visible = false;
            // 
            // lblNorma
            // 
            this.lblNorma.Location = new System.Drawing.Point(202, 94);
            this.lblNorma.Name = "lblNorma";
            this.lblNorma.Size = new System.Drawing.Size(10, 20);
            this.lblNorma.Visible = false;
            // 
            // lblLongitud
            // 
            this.lblLongitud.Location = new System.Drawing.Point(202, 74);
            this.lblLongitud.Name = "lblLongitud";
            this.lblLongitud.Size = new System.Drawing.Size(10, 20);
            this.lblLongitud.Visible = false;
            // 
            // lblLote
            // 
            this.lblLote.Location = new System.Drawing.Point(202, 54);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(10, 20);
            this.lblLote.Visible = false;
            // 
            // lblMedida
            // 
            this.lblMedida.Location = new System.Drawing.Point(202, 34);
            this.lblMedida.Name = "lblMedida";
            this.lblMedida.Size = new System.Drawing.Size(10, 20);
            this.lblMedida.Visible = false;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(192, 31);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(27, 20);
            this.BtnBuscar.TabIndex = 5;
            this.BtnBuscar.Text = "...";
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Location = new System.Drawing.Point(77, 196);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(61, 40);
            this.BtnLimpiar.TabIndex = 3;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(8, 196);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(63, 40);
            this.BtnAgregar.TabIndex = 2;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // txtCB
            // 
            this.txtCB.Location = new System.Drawing.Point(75, 30);
            this.txtCB.MaxLength = 25;
            this.txtCB.Name = "txtCB";
            this.txtCB.Size = new System.Drawing.Size(111, 21);
            this.txtCB.TabIndex = 0;
            this.txtCB.Validated += new System.EventHandler(this.txtCB_Validated);
            this.txtCB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCB_KeyDown);
            // 
            // lblTubo
            // 
            this.lblTubo.Location = new System.Drawing.Point(7, 31);
            this.lblTubo.Name = "lblTubo";
            this.lblTubo.Size = new System.Drawing.Size(65, 20);
            this.lblTubo.Text = "Tubo Lote:";
            // 
            // tabLista
            // 
            this.tabLista.AutoScroll = true;
            this.tabLista.Controls.Add(this.label3);
            this.tabLista.Controls.Add(this.lblArt);
            this.tabLista.Controls.Add(this.dgvCatalogo);
            this.tabLista.Location = new System.Drawing.Point(0, 0);
            this.tabLista.Name = "tabLista";
            this.tabLista.Size = new System.Drawing.Size(240, 245);
            this.tabLista.Text = "Lista";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(128, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 26);
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblArt
            // 
            this.lblArt.BackColor = System.Drawing.Color.Silver;
            this.lblArt.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblArt.Location = new System.Drawing.Point(0, 0);
            this.lblArt.Name = "lblArt";
            this.lblArt.Size = new System.Drawing.Size(113, 26);
            this.lblArt.Text = "Art: 0";
            this.lblArt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvCatalogo
            // 
            this.dgvCatalogo.BackgroundColor = System.Drawing.Color.White;
            this.dgvCatalogo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvCatalogo.Location = new System.Drawing.Point(0, 26);
            this.dgvCatalogo.Name = "dgvCatalogo";
            this.dgvCatalogo.Size = new System.Drawing.Size(240, 219);
            this.dgvCatalogo.TabIndex = 1;
            this.dgvCatalogo.DoubleClick += new System.EventHandler(this.dgvCatalogo_DoubleClick);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem4);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItem2);
            this.menuItem1.Text = "Modulos";
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Inventario";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.MenuItems.Add(this.menuNuevoEmbarque);
            this.menuItem4.MenuItems.Add(this.MenuCargarDatos);
            this.menuItem4.MenuItems.Add(this.menuItem5);
            this.menuItem4.MenuItems.Add(this.menuItem3);
            this.menuItem4.MenuItems.Add(this.MenuSalir);
            this.menuItem4.Text = "Acciones";
            // 
            // menuNuevoEmbarque
            // 
            this.menuNuevoEmbarque.Text = "Nuevo Embarque";
            this.menuNuevoEmbarque.Click += new System.EventHandler(this.menuNuevoEmbarque_Click);
            // 
            // MenuCargarDatos
            // 
            this.MenuCargarDatos.Text = "Cargar Datos ( WI-FI Activado)";
            this.MenuCargarDatos.Click += new System.EventHandler(this.MenuCargarDatos_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Text = "Enviar Embarques (WI-FI Activado)";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "Eliminar Embarques";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // MenuSalir
            // 
            this.MenuSalir.Checked = true;
            this.MenuSalir.Text = "Salir";
            this.MenuSalir.Popup += new System.EventHandler(this.MenuSalir_Popup);
            this.MenuSalir.Click += new System.EventHandler(this.MenuSalir_Click);
            // 
            // FrmEmbarquesNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tabControl1);
            this.Menu = this.mainMenu1;
            this.Name = "FrmEmbarquesNew";
            this.Text = "Pedidos";
            this.Load += new System.EventHandler(this.FrmEmbarquesNew_Load_1);
            this.Activated += new System.EventHandler(this.Main_Activated);
            this.tabControl1.ResumeLayout(false);
            this.tabCaptura.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlDesc.ResumeLayout(false);
            this.tabLista.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblIdSalida;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCaptura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.Button BtnGrabar;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbEmbarque;
        private System.Windows.Forms.Panel pnlDesc;
        private System.Windows.Forms.Label lblPesoTeorico;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.Label lblEspesor;
        private System.Windows.Forms.Label lblNorma;
        private System.Windows.Forms.Label lblLongitud;
        private System.Windows.Forms.Label lblLote;
        private System.Windows.Forms.Label lblMedida;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.TextBox txtCB;
        private System.Windows.Forms.Label lblTubo;
        private System.Windows.Forms.TabPage tabLista;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblArt;
        private System.Windows.Forms.DataGrid dgvCatalogo;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuNuevoEmbarque;
        private System.Windows.Forms.MenuItem MenuCargarDatos;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem3;
        private MenuItem MenuSalir;
        private Panel panel1;
        private Label lblPed1;
        private Button BtnCanTrans;
        private Button btnTransfer;
        private ComboBox cmbA;
        private Label label2;
        private ComboBox cmbDe;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtValor;
        private TextBox txtLinea;
        private TextBox txtCarga;

    }
}