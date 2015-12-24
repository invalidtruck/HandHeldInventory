using System.Reflection;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System;
namespace invsys.Mobile.Embarques
{
    partial class frmEmbarques
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private string dir = Assembly.GetExecutingAssembly().GetName().CodeBase;
        private string dirApp = Assembly.GetExecutingAssembly().GetName().CodeBase;
        private float peso = 0.0f;
        private float pesoMaterial = 0.0f;
        private bool refrescar = false;
        private string cnnstr = "";
        private IContainer components = (IContainer)null;
       
        private TabControl tabControl1;
        private TabPage tabCaptura;
        private TabPage tabLista;
        private TextBox txtCB;
        private Label lblTubo;
        private DataGrid dgvCatalogo;
        private Button BtnAgregar;
        private Button BtnLimpiar;
        private Label label3;
        private Label lblArt;
        private Button BtnBuscar;
        private Panel pnlDesc;
        private Label lblUbicacion;
        private Label label14;
        private Label lblEspesor;
        private Label label12;
        private Label lblNorma;
        private Label label10;
        private Label lblLongitud;
        private Label label8;
        private Label lblLote;
        private Label label6;
        private Label lblMedida;
        private Label label4;
        private Label label17;
        private ComboBox cmbEmbarque;
        private Label lblDesc;
        private Label label15;
        private Label lblAlmacen;
        private Label label7;
        private MainMenu mainMenu1;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private Label lblId;
        private MenuItem menuItem4;
        private MenuItem menuNuevoEmbarque;
        private MenuItem MenuCargarDatos;
        private Button BtnGrabar;
        private Label lblPesoTeorico;
        private Label label11;
        private MenuItem menuItem5;
        private Label lblIdSalida;
        private MenuItem menuItem3;
        private Label label1;
        private ComboBox cmbFiltro;
        private MenuItem menuItem6;

        public int idusuario { get; set; }

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
           
            this.tabControl1 = new TabControl();
            this.tabCaptura = new TabPage();
            this.label1 = new Label();
            this.cmbFiltro = new ComboBox();
            this.BtnGrabar = new Button();
            this.lblId = new Label();
            this.label17 = new Label();
            this.cmbEmbarque = new ComboBox();
            this.pnlDesc = new Panel();
            this.lblIdSalida = new Label();
            this.lblPesoTeorico = new Label();
            this.label11 = new Label();
            this.lblAlmacen = new Label();
            this.label7 = new Label();
            this.lblDesc = new Label();
            this.label15 = new Label();
            this.lblUbicacion = new Label();
            this.label14 = new Label();
            this.lblEspesor = new Label();
            this.label12 = new Label();
            this.lblNorma = new Label();
            this.label10 = new Label();
            this.lblLongitud = new Label();
            this.label8 = new Label();
            this.lblLote = new Label();
            this.label6 = new Label();
            this.lblMedida = new Label();
            this.label4 = new Label();
            this.BtnBuscar = new Button();
            this.BtnLimpiar = new Button();
            this.BtnAgregar = new Button();
            this.txtCB = new TextBox();
            this.lblTubo = new Label();
            this.tabLista = new TabPage();
            this.label3 = new Label();
            this.lblArt = new Label();
            this.dgvCatalogo = new DataGrid();
            this.mainMenu1 = new MainMenu();
            this.menuItem1 = new MenuItem();
            this.menuItem2 = new MenuItem();
            this.menuItem4 = new MenuItem();
            this.menuNuevoEmbarque = new MenuItem();
            this.MenuCargarDatos = new MenuItem();
            this.menuItem5 = new MenuItem();
            this.menuItem3 = new MenuItem();
            this.menuItem6 = new MenuItem();
            this.tabControl1.SuspendLayout();
            this.tabCaptura.SuspendLayout();
            this.pnlDesc.SuspendLayout();
            this.tabLista.SuspendLayout();
            this.SuspendLayout();
            this.tabControl1.Controls.Add((Control)this.tabCaptura);
            this.tabControl1.Controls.Add((Control)this.tabLista);
            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.Location = new Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(240, 268);
            this.tabControl1.TabIndex = 0;
            this.tabCaptura.AutoScroll = true;
            this.tabCaptura.Controls.Add((Control)this.label1);
            this.tabCaptura.Controls.Add((Control)this.cmbFiltro);
            this.tabCaptura.Controls.Add((Control)this.BtnGrabar);
            this.tabCaptura.Controls.Add((Control)this.lblId);
            this.tabCaptura.Controls.Add((Control)this.label17);
            this.tabCaptura.Controls.Add((Control)this.cmbEmbarque);
            this.tabCaptura.Controls.Add((Control)this.pnlDesc);
            this.tabCaptura.Controls.Add((Control)this.BtnBuscar);
            this.tabCaptura.Controls.Add((Control)this.BtnLimpiar);
            this.tabCaptura.Controls.Add((Control)this.BtnAgregar);
            this.tabCaptura.Controls.Add((Control)this.txtCB);
            this.tabCaptura.Controls.Add((Control)this.lblTubo);
            this.tabCaptura.Location = new Point(0, 0);
            this.tabCaptura.Name = "tabCaptura";
            this.tabCaptura.Size = new Size(240, 245);
            this.tabCaptura.Text = "Captura";
            this.tabCaptura.Click += new EventHandler(this.tabCaptura_Click);
            this.label1.Location = new Point(9, 59);
            this.label1.Name = "label1";
            this.label1.Size = new Size(78, 20);
            this.label1.Text = "Filtro carga";
            this.cmbFiltro.Location = new Point(94, 57);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new Size(126, 22);
            this.cmbFiltro.TabIndex = 18;
            this.BtnGrabar.Font = new Font("Tahoma", 6.5f, FontStyle.Regular);
            this.BtnGrabar.Location = new Point(144, 307);
            this.BtnGrabar.Name = "BtnGrabar";
            this.BtnGrabar.Size = new Size(75, 40);
            this.BtnGrabar.TabIndex = 12;
            this.BtnGrabar.Text = "Enviar Embarques";
            this.BtnGrabar.Click += new EventHandler(this.BtnGrabar_Click);
            this.lblId.Location = new Point(23, 381);
            this.lblId.Name = "lblId";
            this.lblId.Size = new Size(100, 20);
            this.lblId.Text = " ";
            this.label17.Location = new Point(9, 6);
            this.label17.Name = "label17";
            this.label17.Size = new Size(64, 20);
            this.label17.Text = "Embarque:";
            this.cmbEmbarque.Location = new Point(75, 6);
            this.cmbEmbarque.Name = "cmbEmbarque";
            this.cmbEmbarque.Size = new Size(144, 22);
            this.cmbEmbarque.TabIndex = 8;
            this.cmbEmbarque.SelectedIndexChanged += new EventHandler(this.cmbEmbarque_SelectedIndexChanged_1);
            this.pnlDesc.Controls.Add((Control)this.lblIdSalida);
            this.pnlDesc.Controls.Add((Control)this.lblPesoTeorico);
            this.pnlDesc.Controls.Add((Control)this.label11);
            this.pnlDesc.Controls.Add((Control)this.lblAlmacen);
            this.pnlDesc.Controls.Add((Control)this.label7);
            this.pnlDesc.Controls.Add((Control)this.lblDesc);
            this.pnlDesc.Controls.Add((Control)this.label15);
            this.pnlDesc.Controls.Add((Control)this.lblUbicacion);
            this.pnlDesc.Controls.Add((Control)this.label14);
            this.pnlDesc.Controls.Add((Control)this.lblEspesor);
            this.pnlDesc.Controls.Add((Control)this.label12);
            this.pnlDesc.Controls.Add((Control)this.lblNorma);
            this.pnlDesc.Controls.Add((Control)this.label10);
            this.pnlDesc.Controls.Add((Control)this.lblLongitud);
            this.pnlDesc.Controls.Add((Control)this.label8);
            this.pnlDesc.Controls.Add((Control)this.lblLote);
            this.pnlDesc.Controls.Add((Control)this.label6);
            this.pnlDesc.Controls.Add((Control)this.lblMedida);
            this.pnlDesc.Controls.Add((Control)this.label4);
            this.pnlDesc.Enabled = false;
            this.pnlDesc.Location = new Point(7, 85);
            this.pnlDesc.Name = "pnlDesc";
            this.pnlDesc.Size = new Size(212, 216);
            this.lblIdSalida.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.lblIdSalida.Location = new Point(10, 194);
            this.lblIdSalida.Name = "lblIdSalida";
            this.lblIdSalida.Size = new Size(31, 15);
            this.lblIdSalida.Visible = false;
            this.lblPesoTeorico.Location = new Point(113, 174);
            this.lblPesoTeorico.Name = "lblPesoTeorico";
            this.lblPesoTeorico.Size = new Size(99, 20);
            this.label11.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label11.Location = new Point(10, 174);
            this.label11.Name = "label11";
            this.label11.Size = new Size(97, 20);
            this.label11.Text = "Peso Teorico:";
            this.lblAlmacen.Location = new Point(113, 154);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new Size(99, 20);
            this.label7.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label7.Location = new Point(10, 154);
            this.label7.Name = "label7";
            this.label7.Size = new Size(70, 20);
            this.label7.Text = "Almacen:";
            this.lblDesc.Location = new Point(91, 1);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new Size(151, 33);
            this.label15.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label15.Location = new Point(10, 3);
            this.label15.Name = "label15";
            this.label15.Size = new Size(83, 20);
            this.label15.Text = "Descripción:";
            this.lblUbicacion.Location = new Point(113, 134);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new Size(99, 20);
            this.label14.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label14.Location = new Point(10, 134);
            this.label14.Name = "label14";
            this.label14.Size = new Size(70, 20);
            this.label14.Text = "Ubicación:";
            this.lblEspesor.Location = new Point(113, 114);
            this.lblEspesor.Name = "lblEspesor";
            this.lblEspesor.Size = new Size(99, 20);
            this.label12.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label12.Location = new Point(10, 114);
            this.label12.Name = "label12";
            this.label12.Size = new Size(65, 20);
            this.label12.Text = "Espesor:";
            this.lblNorma.Location = new Point(113, 94);
            this.lblNorma.Name = "lblNorma";
            this.lblNorma.Size = new Size(99, 20);
            this.label10.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label10.Location = new Point(10, 94);
            this.label10.Name = "label10";
            this.label10.Size = new Size(54, 20);
            this.label10.Text = "Norma:";
            this.lblLongitud.Location = new Point(113, 74);
            this.lblLongitud.Name = "lblLongitud";
            this.lblLongitud.Size = new Size(99, 20);
            this.label8.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label8.Location = new Point(10, 74);
            this.label8.Name = "label8";
            this.label8.Size = new Size(65, 20);
            this.label8.Text = "Longitud:";
            this.lblLote.Location = new Point(113, 54);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new Size(99, 20);
            this.label6.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label6.Location = new Point(10, 54);
            this.label6.Name = "label6";
            this.label6.Size = new Size(54, 20);
            this.label6.Text = "Lote:";
            this.lblMedida.Location = new Point(113, 34);
            this.lblMedida.Name = "lblMedida";
            this.lblMedida.Size = new Size(99, 20);
            this.label4.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.label4.Location = new Point(10, 34);
            this.label4.Name = "label4";
            this.label4.Size = new Size(54, 20);
            this.label4.Text = "Medida:";
            this.BtnBuscar.Enabled = false;
            this.BtnBuscar.Location = new Point(192, 31);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new Size(27, 20);
            this.BtnBuscar.TabIndex = 5;
            this.BtnBuscar.Text = "...";
            this.BtnBuscar.Click += new EventHandler(this.BtnBuscar_Click);
            this.BtnLimpiar.Location = new Point(77, 307);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new Size(61, 40);
            this.BtnLimpiar.TabIndex = 3;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.Click += new EventHandler(this.BtnLimpiar_Click);
            this.BtnAgregar.Location = new Point(8, 307);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new Size(63, 40);
            this.BtnAgregar.TabIndex = 2;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.Click += new EventHandler(this.BtnAdd_Click);
            this.txtCB.Enabled = false;
            this.txtCB.Location = new Point(75, 30);
            this.txtCB.MaxLength = 25;
            this.txtCB.Name = "txtCB";
            this.txtCB.Size = new Size(111, 21);
            this.txtCB.TabIndex = 0;
            this.txtCB.Validated += new EventHandler(this.txtCB_Validated);
            this.lblTubo.Location = new Point(7, 31);
            this.lblTubo.Name = "lblTubo";
            this.lblTubo.Size = new Size(65, 20);
            this.lblTubo.Text = "Tubo Lote:";
            this.tabLista.AutoScroll = true;
            this.tabLista.Controls.Add((Control)this.label3);
            this.tabLista.Controls.Add((Control)this.lblArt);
            this.tabLista.Controls.Add((Control)this.dgvCatalogo);
            this.tabLista.Location = new Point(0, 0);
            this.tabLista.Name = "tabLista";
            this.tabLista.Size = new Size(240, 245);
            this.tabLista.Text = "Lista";
            this.label3.BackColor = Color.Silver;
            this.label3.Dock = DockStyle.Right;
            this.label3.Location = new Point(128, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(112, 102);
            this.label3.TextAlign = ContentAlignment.TopCenter;
            this.lblArt.BackColor = Color.Silver;
            this.lblArt.Dock = DockStyle.Left;
            this.lblArt.Location = new Point(0, 0);
            this.lblArt.Name = "lblArt";
            this.lblArt.Size = new Size(113, 102);
            this.lblArt.Text = "Art: 0";
            this.lblArt.TextAlign = ContentAlignment.TopCenter;
            this.dgvCatalogo.BackgroundColor = Color.White;
            this.dgvCatalogo.Dock = DockStyle.Bottom;
            this.dgvCatalogo.Location = new Point(0, 102);
            this.dgvCatalogo.Name = "dgvCatalogo";
            this.dgvCatalogo.Size = new Size(240, 143);
            this.dgvCatalogo.TabIndex = 1;
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem4);
            this.menuItem1.MenuItems.Add(this.menuItem2);
            this.menuItem1.Text = "Modulos";
            this.menuItem2.Text = "Inventario";
            this.menuItem2.Click += new EventHandler(this.menuItem2_Click);
            this.menuItem4.MenuItems.Add(this.menuNuevoEmbarque);
            this.menuItem4.MenuItems.Add(this.MenuCargarDatos);
            this.menuItem4.MenuItems.Add(this.menuItem5);
            this.menuItem4.MenuItems.Add(this.menuItem3);
            this.menuItem4.MenuItems.Add(this.menuItem6);
            this.menuItem4.Text = "Acciones";
            this.menuNuevoEmbarque.Text = "Nuevo Embarque";
            this.menuNuevoEmbarque.Click += new EventHandler(this.menuNuevoEmbarque_Click);
            this.MenuCargarDatos.Text = "Cargar Datos ( WI-FI Activado)";
            this.MenuCargarDatos.Click += new EventHandler(this.MenuCargarDatos_Click);
            this.menuItem5.Text = "Enviar Embarques (WI-FI Activado)";
            this.menuItem5.Click += new EventHandler(this.menuItem5_Click);
            this.menuItem3.Text = "Eliminar Embarques";
            this.menuItem3.Click += new EventHandler(this.menuItem3_Click);
            this.menuItem6.Enabled = false;
            this.menuItem6.Text = "TEST";
            this.menuItem6.Click += new EventHandler(this.menuItem6_Click); 
            this.AutoScroll = true;
            this.ClientSize = new Size(240, 268);
            this.Controls.Add((Control)this.tabControl1);
            this.Menu = this.mainMenu1;
            this.Name = "FrmEmbarque";
            this.Text = "Embarques";
            this.Load += new EventHandler(this.Form1_Load);
            this.Activated += new EventHandler(this.Main_Activated);
            this.tabControl1.ResumeLayout(false);
            this.tabCaptura.ResumeLayout(false);
            this.pnlDesc.ResumeLayout(false);
            this.tabLista.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion


    }
}

