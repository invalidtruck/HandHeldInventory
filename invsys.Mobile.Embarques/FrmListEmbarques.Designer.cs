namespace invsys.Mobile.Embarques
{
    partial class FrmListEmbarques
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
            this.lviewEmbarques = new System.Windows.Forms.ListView();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem3);
            // 
            // lviewEmbarques
            // 
            this.lviewEmbarques.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lviewEmbarques.CheckBoxes = true;
            this.lviewEmbarques.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lviewEmbarques.Location = new System.Drawing.Point(0, 0);
            this.lviewEmbarques.Name = "lviewEmbarques";
            this.lviewEmbarques.Size = new System.Drawing.Size(240, 268);
            this.lviewEmbarques.TabIndex = 0;
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItem2);
            this.menuItem1.Text = "Menu";
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Embarques";
            // 
            // menuItem3
            // 
            this.menuItem3.MenuItems.Add(this.menuItem4);
            this.menuItem3.Text = "Acciones";
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "Enviar seleccionados";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // FrmListEmbarques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.lviewEmbarques);
            this.Menu = this.mainMenu1;
            this.Name = "FrmListEmbarques";
            this.Text = "FrmListEmbarques";
            this.Load += new System.EventHandler(this.FrmListEmbarques_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lviewEmbarques;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;


    }
}