using System.ComponentModel;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Data.SqlServerCe;

namespace invsys.Mobile.Embarques
{
    partial class FrmInventarioNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.BtnAñadir = new System.Windows.Forms.Button();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEspesor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNorma = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLongitud = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAlmacen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMedida = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnComentarios = new System.Windows.Forms.Button();
            this.cmbComentario = new System.Windows.Forms.ComboBox();
            this.lboxComentarios = new System.Windows.Forms.ListBox();
            this.lblCometarios = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblIdArt = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvInventario = new System.Windows.Forms.DataGrid();
            this.notification1 = new Microsoft.WindowsCE.Forms.Notification();
            this.mnuComentarios = new System.Windows.Forms.MenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem3);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItem2);
            this.menuItem1.Text = "Modulos";
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Embarque";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.MenuItems.Add(this.menuItem4);
            this.menuItem3.MenuItems.Add(this.menuItem5);
            this.menuItem3.MenuItems.Add(this.menuItem6);
            this.menuItem3.MenuItems.Add(this.mnuComentarios);
            this.menuItem3.Text = "Acciones";
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "Cargar Datos ( WiFi)";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click_1);
            // 
            // menuItem5
            // 
            this.menuItem5.Text = "Enviar Inventario (WiFi)";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click_1);
            // 
            // menuItem6
            // 
            this.menuItem6.Text = "Eliminar Inventario";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // BtnAñadir
            // 
            this.BtnAñadir.Location = new System.Drawing.Point(14, 444);
            this.BtnAñadir.Name = "BtnAñadir";
            this.BtnAñadir.Size = new System.Drawing.Size(203, 33);
            this.BtnAñadir.TabIndex = 56;
            this.BtnAñadir.Text = "Añadir";
            this.BtnAñadir.Click += new System.EventHandler(this.BtnAñadir_Click_1);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(82, 72);
            this.txtDesc.MaxLength = 255;
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(135, 46);
            this.txtDesc.TabIndex = 45;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(12, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 43);
            this.label9.Text = "Descripción:";
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Location = new System.Drawing.Point(81, 45);
            this.txtUbicacion.MaxLength = 80;
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(135, 21);
            this.txtUbicacion.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(13, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.Text = "Ubicación:";
            // 
            // txtEspesor
            // 
            this.txtEspesor.Location = new System.Drawing.Point(82, 259);
            this.txtEspesor.MaxLength = 80;
            this.txtEspesor.Name = "txtEspesor";
            this.txtEspesor.Size = new System.Drawing.Size(135, 21);
            this.txtEspesor.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(14, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.Text = "Espesor:";
            // 
            // txtNorma
            // 
            this.txtNorma.Location = new System.Drawing.Point(82, 232);
            this.txtNorma.MaxLength = 80;
            this.txtNorma.Name = "txtNorma";
            this.txtNorma.Size = new System.Drawing.Size(135, 21);
            this.txtNorma.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(14, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.Text = "Norma:";
            // 
            // txtLongitud
            // 
            this.txtLongitud.Location = new System.Drawing.Point(82, 205);
            this.txtLongitud.MaxLength = 80;
            this.txtLongitud.Name = "txtLongitud";
            this.txtLongitud.Size = new System.Drawing.Size(135, 21);
            this.txtLongitud.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(14, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.Text = "Longitud:";
            // 
            // txtLote
            // 
            this.txtLote.Location = new System.Drawing.Point(82, 178);
            this.txtLote.MaxLength = 80;
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(135, 21);
            this.txtLote.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(14, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.Text = "Lote:";
            // 
            // txtAlmacen
            // 
            this.txtAlmacen.Location = new System.Drawing.Point(82, 151);
            this.txtAlmacen.MaxLength = 80;
            this.txtAlmacen.Name = "txtAlmacen";
            this.txtAlmacen.Size = new System.Drawing.Size(135, 21);
            this.txtAlmacen.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(14, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.Text = "Almacen:";
            // 
            // txtMedida
            // 
            this.txtMedida.Location = new System.Drawing.Point(82, 124);
            this.txtMedida.MaxLength = 80;
            this.txtMedida.Name = "txtMedida";
            this.txtMedida.Size = new System.Drawing.Size(135, 21);
            this.txtMedida.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.Text = "Medida:";
            // 
            // txtCB
            // 
            this.txtCB.Location = new System.Drawing.Point(83, 1);
            this.txtCB.MaxLength = 25;
            this.txtCB.Name = "txtCB";
            this.txtCB.Size = new System.Drawing.Size(96, 21);
            this.txtCB.TabIndex = 37;
            this.txtCB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCB_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 20);
            this.label1.Text = "Lote:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.None;
            this.tabControl1.Location = new System.Drawing.Point(3, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(223, 500);
            this.tabControl1.TabIndex = 68;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnComentarios);
            this.tabPage1.Controls.Add(this.cmbComentario);
            this.tabPage1.Controls.Add(this.lboxComentarios);
            this.tabPage1.Controls.Add(this.lblCometarios);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.lblIdArt);
            this.tabPage1.Controls.Add(this.BtnAñadir);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtCB);
            this.tabPage1.Controls.Add(this.txtUbicacion);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtMedida);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtDesc);
            this.tabPage1.Controls.Add(this.txtAlmacen);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtLote);
            this.tabPage1.Controls.Add(this.txtEspesor);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtLongitud);
            this.tabPage1.Controls.Add(this.txtNorma);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(223, 477);
            this.tabPage1.Text = "Agregar Lote";
            // 
            // btnComentarios
            // 
            this.btnComentarios.Location = new System.Drawing.Point(188, 300);
            this.btnComentarios.Name = "btnComentarios";
            this.btnComentarios.Size = new System.Drawing.Size(28, 20);
            this.btnComentarios.TabIndex = 95;
            this.btnComentarios.Text = "+";
            this.btnComentarios.Click += new System.EventHandler(this.btnComentarios_Click);
            // 
            // cmbComentario
            // 
            this.cmbComentario.Location = new System.Drawing.Point(16, 300);
            this.cmbComentario.Name = "cmbComentario";
            this.cmbComentario.Size = new System.Drawing.Size(170, 22);
            this.cmbComentario.TabIndex = 94; 
            // 
            // lboxComentarios
            // 
            this.lboxComentarios.Location = new System.Drawing.Point(14, 327);
            this.lboxComentarios.Name = "lboxComentarios";
            this.lboxComentarios.Size = new System.Drawing.Size(202, 114);
            this.lboxComentarios.TabIndex = 93;
            // 
            // lblCometarios
            // 
            this.lblCometarios.Location = new System.Drawing.Point(14, 282);
            this.lblCometarios.Name = "lblCometarios";
            this.lblCometarios.Size = new System.Drawing.Size(205, 20);
            this.lblCometarios.Text = "Comentarios:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(185, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 21);
            this.button1.TabIndex = 77;
            this.button1.Text = "...";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblIdArt
            // 
            this.lblIdArt.Location = new System.Drawing.Point(58, 98);
            this.lblIdArt.Name = "lblIdArt";
            this.lblIdArt.Size = new System.Drawing.Size(18, 20);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvInventario);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(215, 474);
            this.tabPage2.Text = "Material en Inventario";
            // 
            // dgvInventario
            // 
            this.dgvInventario.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgvInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventario.Location = new System.Drawing.Point(0, 0);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.Size = new System.Drawing.Size(215, 474);
            this.dgvInventario.TabIndex = 0;
            this.dgvInventario.DoubleClick += new System.EventHandler(this.dgvInventario_DoubleClick);
            // 
            // notification1
            // 
            this.notification1.Text = "notification1";
            // 
            // mnuComentarios
            // 
            this.mnuComentarios.Text = "Cargar Comentarios (WiFi)";
            this.mnuComentarios.Click += new System.EventHandler(this.mnuComentarios_Click);
            // 
            // FrmInventarioNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tabControl1);
            this.Menu = this.mainMenu1;
            this.Name = "FrmInventarioNew";
            this.Text = "Inventario";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button BtnAñadir;
        private TextBox txtDesc;
        private Label label9;
        private TextBox txtUbicacion;
        private Label label8;
        private TextBox txtEspesor;
        private Label label7;
        private TextBox txtNorma;
        private Label label6;
        private TextBox txtLongitud;
        private Label label5;
        private TextBox txtLote;
        private Label label4;
        private TextBox txtAlmacen;
        private Label label3;
        private TextBox txtMedida;
        private Label label2;
        private TextBox txtCB;
        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGrid dgvInventario;

        public int IdConexion { get; set; }
        public int idusuario { get; set; }
        private string dir = Assembly.GetExecutingAssembly().GetName().CodeBase;
        //private bool refrescar = false;
        private SqlCeConnection cnn;
        private Label lblIdArt;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private MenuItem menuItem3;
        private MenuItem menuItem4;
        private MenuItem menuItem5;
        private MenuItem menuItem6;
        private Button button1;
        private Microsoft.WindowsCE.Forms.Notification notification1;
        private Label lblCometarios;
        private ListBox lboxComentarios;
        private Button btnComentarios;
        private ComboBox cmbComentario;
        private MenuItem mnuComentarios;

    }
}