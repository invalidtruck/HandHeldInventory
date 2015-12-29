using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Data.SqlServerCe;
namespace invsys.Mobile.Embarques
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary> 
        private System.Windows.Forms.MainMenu mainMenu1;
        private IContainer components = (IContainer)null;
        private string dir = Assembly.GetExecutingAssembly().GetName().CodeBase;
        private Label label1;
        private Label label2;
        private TextBox txtUser;
        private TextBox txtcontra;
        private Button BtnLogin;
        private PictureBox pictureBox1;
        private Label label3;
        private Button BtnSalir;
        private SqlCeConnection cnn;

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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtcontra = new System.Windows.Forms.TextBox();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(3, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.Text = "Usuarios:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(0, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.Text = "Contraseña:";
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.Location = new System.Drawing.Point(0, 133);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(240, 21);
            this.txtUser.TabIndex = 3;
            // 
            // txtcontra
            // 
            this.txtcontra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcontra.Location = new System.Drawing.Point(0, 187);
            this.txtcontra.Name = "txtcontra";
            this.txtcontra.PasswordChar = '*';
            this.txtcontra.Size = new System.Drawing.Size(240, 21);
            this.txtcontra.TabIndex = 4;
            // 
            // BtnLogin
            // 
            this.BtnLogin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnLogin.Location = new System.Drawing.Point(0, 236);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(240, 28);
            this.BtnLogin.TabIndex = 5;
            this.BtnLogin.Text = "Acceder";
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 20);
            this.label3.Text = "INVENTARIO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnSalir.Location = new System.Drawing.Point(0, 264);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(240, 30);
            this.BtnSalir.TabIndex = 8;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.txtcontra);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSalir);
            this.Name = "frmLogin";
            this.Text = "login";
            this.ResumeLayout(false);

        }

        #endregion
    }
}