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
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
             
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmLogin));
            this.label1 = new Label();
            this.label2 = new Label();
            this.txtUser = new TextBox();
            this.txtcontra = new TextBox();
            this.BtnLogin = new Button();
            this.pictureBox1 = new PictureBox();
            this.label3 = new Label();
            this.BtnSalir = new Button();
            this.SuspendLayout();
            this.label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.label1.Location = new Point(3, 116);
            this.label1.Name = "label1";
            this.label1.Size = new Size(72, 20);
            this.label1.Text = "Usuario:";
            this.label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.label2.Location = new Point(0, 164);
            this.label2.Name = "label2";
            this.label2.Size = new Size(75, 20);
            this.label2.Text = "Contraseña:";
            this.txtUser.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.txtUser.Location = new Point(0, 139);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new Size(240, 21);
            this.txtUser.TabIndex = 3;
            this.txtcontra.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.txtcontra.Location = new Point(0, 187);
            this.txtcontra.Name = "txtcontra";
            this.txtcontra.PasswordChar = '*';
            this.txtcontra.Size = new Size(240, 21);
            this.txtcontra.TabIndex = 4;
            this.BtnLogin.Dock = DockStyle.Bottom;
            this.BtnLogin.Location = new Point(0, 236);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new Size(240, 28);
            this.BtnLogin.TabIndex = 5;
            this.BtnLogin.Text = "Acceder";
            this.BtnLogin.Click += new EventHandler(this.BtnLogin_Click);
            this.pictureBox1.Dock = DockStyle.Top;
 
            this.pictureBox1.Location = new Point(0, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(240, 65);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.label3.Dock = DockStyle.Top;
            this.label3.Font = new Font("Tahoma", 14f, FontStyle.Bold);
            this.label3.Location = new Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(240, 20);
            this.label3.Text = "INVENTARIO";
            this.label3.TextAlign = ContentAlignment.TopCenter;
            this.BtnSalir.Dock = DockStyle.Bottom;
            this.BtnSalir.Location = new Point(0, 264);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new Size(240, 30);
            this.BtnSalir.TabIndex = 8;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.Click += new EventHandler(this.BtnSalir_Click);
            this.AutoScaleDimensions = new SizeF(96f, 96f);
 
            this.AutoScroll = true;
            this.ClientSize = new Size(240, 294);
            this.Controls.Add((Control)this.pictureBox1);
            this.Controls.Add((Control)this.label3);
            this.Controls.Add((Control)this.BtnLogin);
            this.Controls.Add((Control)this.txtcontra);
            this.Controls.Add((Control)this.txtUser);
            this.Controls.Add((Control)this.label2);
            this.Controls.Add((Control)this.label1);
            this.Controls.Add((Control)this.BtnSalir);
            this.Name = "login";
            this.Text = "login";
            this.ResumeLayout(false);
        }

        #endregion
    }
}