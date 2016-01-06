using System.Reflection;
using System.ComponentModel;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Data.SqlServerCe;
namespace invsys.Mobile.Embarques
{
    partial class FrmAddEmbarque
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null; 
        private string dir = Assembly.GetExecutingAssembly().GetName().CodeBase;
        private SqlCeConnection cnn;
        private MainMenu mainMenu1;
        private Label lblDescripcion;
        private TextBox txtEmbarque;
        private Button BtnAgregar;
        private Button Cancelar;
        public int idusario { get; set; }
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
            this.mainMenu1 = new MainMenu();
            this.lblDescripcion = new Label();
            this.txtEmbarque = new TextBox();
            this.BtnAgregar = new Button();
            this.Cancelar = new Button();
            this.SuspendLayout();
            this.lblDescripcion.Location = new Point(28, 84);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new Size(89, 20);
            this.lblDescripcion.Text = "Descripcion";
            this.txtEmbarque.Location = new Point(28, 107);
            this.txtEmbarque.MaxLength = 50;
            this.txtEmbarque.Name = "txtEmbarque";
            this.txtEmbarque.Size = new Size(192, 21);
            this.txtEmbarque.TabIndex = 1;
            this.BtnAgregar.Location = new Point(24, 155);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new Size(72, 20);
            this.BtnAgregar.TabIndex = 2;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.Click += new EventHandler(this.BtnAgregar_Click);
            this.Cancelar.Location = new Point(148, 155);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new Size(72, 20);
            this.Cancelar.TabIndex = 3;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.Click += new EventHandler(this.Cancelar_Click); 
            this.AutoScroll = true;
            this.ClientSize = new Size(240, 268);
            this.Controls.Add((Control)this.Cancelar);
            this.Controls.Add((Control)this.BtnAgregar);
            this.Controls.Add((Control)this.txtEmbarque);
            this.Controls.Add((Control)this.lblDescripcion);
            this.Menu = this.mainMenu1;
            this.Name = "frmAddEmbarque";
            this.Text = "frmAddEmbarque";
            this.ResumeLayout(false);
        }

        #endregion
    }
}