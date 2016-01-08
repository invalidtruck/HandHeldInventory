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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.BtnGrabar = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbEmbarque = new System.Windows.Forms.ComboBox();
            this.pnlDesc = new System.Windows.Forms.Panel();
            this.lblPesoTeorico = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblEspesor = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblNorma = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblLongitud = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblLote = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMedida = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.MenuSalir = new System.Windows.Forms.MenuItem();
            this.tabControl1.SuspendLayout();
            this.tabCaptura.SuspendLayout();
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
            // 
            // BtnGrabar
            // 
            this.BtnGrabar.Font = new System.Drawing.Font("Tahoma", 6.5F, System.Drawing.FontStyle.Regular);
            this.BtnGrabar.Location = new System.Drawing.Point(144, 307);
            this.BtnGrabar.Name = "BtnGrabar";
            this.BtnGrabar.Size = new System.Drawing.Size(75, 40);
            this.BtnGrabar.TabIndex = 12;
            this.BtnGrabar.Text = "Enviar Embarques";
            this.BtnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(23, 381);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(100, 20);
            this.lblId.Text = " ";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(9, 6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 20);
            this.label17.Text = "Embarque:";
            // 
            // cmbEmbarque
            // 
            this.cmbEmbarque.Location = new System.Drawing.Point(75, 6);
            this.cmbEmbarque.Name = "cmbEmbarque";
            this.cmbEmbarque.Size = new System.Drawing.Size(144, 22);
            this.cmbEmbarque.TabIndex = 8;
            // 
            // pnlDesc
            // 
            this.pnlDesc.Controls.Add(this.lblIdSalida);
            this.pnlDesc.Controls.Add(this.lblPesoTeorico);
            this.pnlDesc.Controls.Add(this.label11);
            this.pnlDesc.Controls.Add(this.lblAlmacen);
            this.pnlDesc.Controls.Add(this.label7);
            this.pnlDesc.Controls.Add(this.lblDesc);
            this.pnlDesc.Controls.Add(this.label15);
            this.pnlDesc.Controls.Add(this.lblUbicacion);
            this.pnlDesc.Controls.Add(this.label14);
            this.pnlDesc.Controls.Add(this.lblEspesor);
            this.pnlDesc.Controls.Add(this.label12);
            this.pnlDesc.Controls.Add(this.lblNorma);
            this.pnlDesc.Controls.Add(this.label10);
            this.pnlDesc.Controls.Add(this.lblLongitud);
            this.pnlDesc.Controls.Add(this.label8);
            this.pnlDesc.Controls.Add(this.lblLote);
            this.pnlDesc.Controls.Add(this.label6);
            this.pnlDesc.Controls.Add(this.lblMedida);
            this.pnlDesc.Controls.Add(this.label4);
            this.pnlDesc.Location = new System.Drawing.Point(7, 85);
            this.pnlDesc.Name = "pnlDesc";
            this.pnlDesc.Size = new System.Drawing.Size(212, 216);
            // 
            // lblPesoTeorico
            // 
            this.lblPesoTeorico.Location = new System.Drawing.Point(113, 174);
            this.lblPesoTeorico.Name = "lblPesoTeorico";
            this.lblPesoTeorico.Size = new System.Drawing.Size(99, 20);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(10, 174);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 20);
            this.label11.Text = "Peso Teorico:";
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.Location = new System.Drawing.Point(113, 154);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(99, 20);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(10, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 20);
            this.label7.Text = "Almacen:";
            // 
            // lblDesc
            // 
            this.lblDesc.Location = new System.Drawing.Point(91, 1);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(151, 33);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(10, 3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 20);
            this.label15.Text = "Descripción:";
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.Location = new System.Drawing.Point(113, 134);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(99, 20);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(10, 134);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 20);
            this.label14.Text = "Ubicación:";
            // 
            // lblEspesor
            // 
            this.lblEspesor.Location = new System.Drawing.Point(113, 114);
            this.lblEspesor.Name = "lblEspesor";
            this.lblEspesor.Size = new System.Drawing.Size(99, 20);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(10, 114);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 20);
            this.label12.Text = "Espesor:";
            // 
            // lblNorma
            // 
            this.lblNorma.Location = new System.Drawing.Point(113, 94);
            this.lblNorma.Name = "lblNorma";
            this.lblNorma.Size = new System.Drawing.Size(99, 20);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(10, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 20);
            this.label10.Text = "Norma:";
            // 
            // lblLongitud
            // 
            this.lblLongitud.Location = new System.Drawing.Point(113, 74);
            this.lblLongitud.Name = "lblLongitud";
            this.lblLongitud.Size = new System.Drawing.Size(99, 20);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(10, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.Text = "Longitud:";
            // 
            // lblLote
            // 
            this.lblLote.Location = new System.Drawing.Point(113, 54);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(99, 20);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(10, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.Text = "Lote:";
            // 
            // lblMedida
            // 
            this.lblMedida.Location = new System.Drawing.Point(113, 34);
            this.lblMedida.Name = "lblMedida";
            this.lblMedida.Size = new System.Drawing.Size(99, 20);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(10, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.Text = "Medida:";
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
            this.BtnLimpiar.Location = new System.Drawing.Point(77, 307);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(61, 40);
            this.BtnLimpiar.TabIndex = 3;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(8, 307);
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
            this.label3.Size = new System.Drawing.Size(112, 102);
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblArt
            // 
            this.lblArt.BackColor = System.Drawing.Color.Silver;
            this.lblArt.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblArt.Location = new System.Drawing.Point(0, 0);
            this.lblArt.Name = "lblArt";
            this.lblArt.Size = new System.Drawing.Size(113, 102);
            this.lblArt.Text = "Art: 0";
            this.lblArt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvCatalogo
            // 
            this.dgvCatalogo.BackgroundColor = System.Drawing.Color.White;
            this.dgvCatalogo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvCatalogo.Location = new System.Drawing.Point(0, 102);
            this.dgvCatalogo.Name = "dgvCatalogo";
            this.dgvCatalogo.Size = new System.Drawing.Size(240, 143);
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
            this.menuItem4.MenuItems.Add(this.menuItem6);
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
            // menuItem6
            // 
            this.menuItem6.Enabled = false;
            this.menuItem6.Text = "TEST";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
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
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tabControl1);
            this.Menu = this.mainMenu1;
            this.Name = "FrmEmbarquesNew";
            this.Text = "Embarques";
            this.Load += new System.EventHandler(this.FrmEmbarquesNew_Load_1);
            this.Activated += new System.EventHandler(this.Main_Activated);
            this.tabControl1.ResumeLayout(false);
            this.tabCaptura.ResumeLayout(false);
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
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblEspesor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblNorma;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblLongitud;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblLote;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMedida;
        private System.Windows.Forms.Label label4;
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
        private System.Windows.Forms.MenuItem menuItem6;
        private MenuItem MenuSalir;

    }
}