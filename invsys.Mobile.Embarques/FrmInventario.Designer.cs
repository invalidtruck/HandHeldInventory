using System.ComponentModel;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Data.SqlServerCe;
namespace invsys.Mobile.Embarques
{
    partial class FrmInventario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = (IContainer)null;
        private string dir = Assembly.GetExecutingAssembly().GetName().CodeBase;
        private bool refrescar = false;
        private MainMenu mainMenu1;
        private MenuItem menuItem1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label lblIdArt;
        private Button BtnAñadir;
        private Label label10;
        private NumericUpDown nudCantidad;
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
        private TabPage tabPage2;
        private DataGrid dgvInventario;
        private Label lblTotal;
        private MenuItem menuItem2;
        private MenuItem menuItem3;
        private MenuItem menuItem4;
        private MenuItem menuItem5;
        private ComboBox cmbFiltro;
        private Label label11;
        private SqlCeConnection cnn;

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
        
            this.label11.Text = "Filtro carga:";
            this.cmbFiltro.Items.Add((object)"4x0");
            this.cmbFiltro.Items.Add((object)"6x0");
            this.cmbFiltro.Items.Add((object)"8x0");
            this.cmbFiltro.Items.Add((object)"10x0");
            this.cmbFiltro.Items.Add((object)"12x0");
            this.cmbFiltro.Items.Add((object)"14x0");
            this.cmbFiltro.Items.Add((object)"16x0");
            this.cmbFiltro.Items.Add((object)"18x0");
            this.cmbFiltro.Items.Add((object)"20x0");
            this.cmbFiltro.Items.Add((object)"24x0");
            this.cmbFiltro.Items.Add((object)"4x4");
            this.cmbFiltro.Items.Add((object)"6x6x");
            this.cmbFiltro.Items.Add((object)"8x8");
            this.cmbFiltro.Items.Add((object)"10x10");
            this.cmbFiltro.Items.Add((object)"12x12");
            this.cmbFiltro.Items.Add((object)"14x14");
            this.cmbFiltro.Items.Add((object)"16x16");
            this.cmbFiltro.Items.Add((object)"8x4");
            this.cmbFiltro.Items.Add((object)"10x6");
            this.cmbFiltro.Items.Add((object)"HELUCOIDAL");
            this.cmbFiltro.Location = new Point(98, 3);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new Size(126, 22);
            this.cmbFiltro.TabIndex = 67;
            this.lblIdArt.Location = new Point(31, 343);
            this.lblIdArt.Name = "lblIdArt";
            this.lblIdArt.Size = new Size(160, 23);
            this.lblIdArt.Visible = false;
            this.BtnAñadir.Location = new Point(106, 305);
            this.BtnAñadir.Name = "BtnAñadir";
            this.BtnAñadir.Size = new Size(120, 33);
            this.BtnAñadir.TabIndex = 56;
            this.BtnAñadir.Text = "Añadir";
            this.BtnAñadir.Click += new EventHandler(this.BtnAñadir_Click);
            this.label10.Location = new Point(135, 40);
            this.label10.Name = "label10";
            this.label10.Size = new Size(35, 20);
            this.label10.Text = "Cant:";
            this.label10.Visible = false;
            this.nudCantidad.Location = new Point(178, 38);
            NumericUpDown numericUpDown1 = this.nudCantidad;
            int[] bits1 = new int[4];
            bits1[0] = 999;
            Decimal num1 = new Decimal(bits1);
            numericUpDown1.Maximum = num1;
            NumericUpDown numericUpDown2 = this.nudCantidad;
            int[] bits2 = new int[4];
            bits2[0] = 1;
            Decimal num2 = new Decimal(bits2);
            numericUpDown2.Minimum = num2;
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new Size(46, 22);
            this.nudCantidad.TabIndex = 46;
            NumericUpDown numericUpDown3 = this.nudCantidad;
            int[] bits3 = new int[4];
            bits3[0] = 1;
            Decimal num3 = new Decimal(bits3);
            numericUpDown3.Value = num3;
            this.nudCantidad.Visible = false;
            this.txtDesc.Location = new Point(74, 64);
            this.txtDesc.MaxLength = (int)byte.MaxValue;
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new Size(150, 46);
            this.txtDesc.TabIndex = 45;
            this.label9.Location = new Point(4, 67);
            this.label9.Name = "label9";
            this.label9.Size = new Size(72, 20);
            this.label9.Text = "Descripción:";
            this.txtUbicacion.Location = new Point(74, 278);
            this.txtUbicacion.MaxLength = 80;
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new Size(150, 21);
            this.txtUbicacion.TabIndex = 44;
            this.label8.Location = new Point(6, 281);
            this.label8.Name = "label8";
            this.label8.Size = new Size(62, 20);
            this.label8.Text = "Ubicación:";
            this.txtEspesor.Location = new Point(74, 251);
            this.txtEspesor.MaxLength = 80;
            this.txtEspesor.Name = "txtEspesor";
            this.txtEspesor.Size = new Size(150, 21);
            this.txtEspesor.TabIndex = 43;
            this.label7.Location = new Point(6, 254);
            this.label7.Name = "label7";
            this.label7.Size = new Size(53, 20);
            this.label7.Text = "Espesor:";
            this.txtNorma.Location = new Point(74, 224);
            this.txtNorma.MaxLength = 80;
            this.txtNorma.Name = "txtNorma";
            this.txtNorma.Size = new Size(150, 21);
            this.txtNorma.TabIndex = 42;
            this.label6.Location = new Point(6, 227);
            this.label6.Name = "label6";
            this.label6.Size = new Size(53, 20);
            this.label6.Text = "Norma:";
            this.txtLongitud.Location = new Point(74, 197);
            this.txtLongitud.MaxLength = 80;
            this.txtLongitud.Name = "txtLongitud";
            this.txtLongitud.Size = new Size(150, 21);
            this.txtLongitud.TabIndex = 41;
            this.label5.Location = new Point(6, 200);
            this.label5.Name = "label5";
            this.label5.Size = new Size(62, 20);
            this.label5.Text = "Longitud:";
            this.txtLote.Location = new Point(74, 170);
            this.txtLote.MaxLength = 80;
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new Size(150, 21);
            this.txtLote.TabIndex = 40;
            this.label4.Location = new Point(6, 173);
            this.label4.Name = "label4";
            this.label4.Size = new Size(53, 20);
            this.label4.Text = "Lote:";
            this.txtAlmacen.Location = new Point(74, 143);
            this.txtAlmacen.MaxLength = 80;
            this.txtAlmacen.Name = "txtAlmacen";
            this.txtAlmacen.Size = new Size(150, 21);
            this.txtAlmacen.TabIndex = 39;
            this.label3.Location = new Point(6, 146);
            this.label3.Name = "label3";
            this.label3.Size = new Size(62, 20);
            this.label3.Text = "Almacen:";
            this.txtMedida.Location = new Point(74, 116);
            this.txtMedida.MaxLength = 80;
            this.txtMedida.Name = "txtMedida";
            this.txtMedida.Size = new Size(150, 21);
            this.txtMedida.TabIndex = 38;
            this.label2.Location = new Point(4, 117);
            this.label2.Name = "label2";
            this.label2.Size = new Size(53, 20);
            this.label2.Text = "Medida:";
            this.txtCB.Location = new Point(74, 37);
            this.txtCB.MaxLength = 25;
            this.txtCB.Name = "txtCB";
            this.txtCB.Size = new Size(150, 21);
            this.txtCB.TabIndex = 37;
            this.txtCB.Validated += new EventHandler(this.txtCB_Validated);
            this.label1.Location = new Point(4, 40);
            this.label1.Name = "label1";
            this.label1.Size = new Size(46, 20);
            this.label1.Text = "Lote:";
            this.tabPage2.Controls.Add((Control)this.lblTotal);
            this.tabPage2.Controls.Add((Control)this.dgvInventario);
            this.tabPage2.Location = new Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new Size(232, 239);
            this.tabPage2.Text = "Material en Inventario";
            this.lblTotal.Dock = DockStyle.Top;
            this.lblTotal.Location = new Point(0, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new Size(232, 20);
            this.lblTotal.Text = "Total:";
            this.dgvInventario.BackgroundColor = Color.FromArgb(128, 128, 128);
            this.dgvInventario.Dock = DockStyle.Fill;
            this.dgvInventario.Location = new Point(0, 0);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.Size = new Size(232, 239);
            this.dgvInventario.TabIndex = 0; 
            this.AutoScroll = true;
            this.ClientSize = new Size(240, 268);
            this.Controls.Add((Control)this.tabControl1);
            this.Menu = this.mainMenu1;
            this.Name = "FrmInventario";
            this.Text = "Inventario";
            this.Load += new EventHandler(this.FrmInventario_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}