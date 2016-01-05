﻿using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Data.SqlServerCe;

namespace invsys.Mobile.Embarques
{
    partial class FrmLoginNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;
        private string dir = Assembly.GetExecutingAssembly().GetName().CodeBase;
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.BtnAcceder = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 26);
            this.label1.Text = "INVENTARIO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Usuario:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(4, 119);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(233, 21);
            this.textBox1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "Contraseña:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(4, 162);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(233, 21);
            this.textBox2.TabIndex = 4;
            // 
            // BtnAcceder
            // 
            this.BtnAcceder.Location = new System.Drawing.Point(4, 201);
            this.BtnAcceder.Name = "BtnAcceder";
            this.BtnAcceder.Size = new System.Drawing.Size(233, 31);
            this.BtnAcceder.TabIndex = 5;
            this.BtnAcceder.Text = "Acceder";
            this.BtnAcceder.Click += new System.EventHandler(this.BtnAcceder_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(4, 236);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(233, 31);
            this.BtnSalir.TabIndex = 6;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // FrmLoginNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnAcceder);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu1;
            this.Name = "FrmLoginNew";
            this.Text = "login";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button BtnAcceder;
        private System.Windows.Forms.Button BtnSalir;
    }
}