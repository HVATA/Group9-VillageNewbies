using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Group9_VillageNewbies
{
    partial class Form1 : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.btn_asiakas = new System.Windows.Forms.Button();
            this.btn_lasku = new System.Windows.Forms.Button();
            this.btn_aluemokki = new System.Windows.Forms.Button();
            this.header = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_majava2 = new System.Windows.Forms.Button();
            this.Majoittautumiset = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_asiakas
            // 
            this.btn_asiakas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_asiakas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_asiakas.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_asiakas.Location = new System.Drawing.Point(37, 150);
            this.btn_asiakas.Name = "btn_asiakas";
            this.btn_asiakas.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_asiakas.Size = new System.Drawing.Size(277, 60);
            this.btn_asiakas.TabIndex = 2;
            this.btn_asiakas.Text = "Asiakkaiden hallinta";
            this.btn_asiakas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_asiakas.UseVisualStyleBackColor = false;
            this.btn_asiakas.Click += new System.EventHandler(this.btn_asiakas_Click);
            // 
            // btn_lasku
            // 
            this.btn_lasku.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_lasku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_lasku.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lasku.Location = new System.Drawing.Point(37, 282);
            this.btn_lasku.Name = "btn_lasku";
            this.btn_lasku.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_lasku.Size = new System.Drawing.Size(277, 60);
            this.btn_lasku.TabIndex = 3;
            this.btn_lasku.Text = "Laskujen hallinta ja seuranta";
            this.btn_lasku.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_lasku.UseVisualStyleBackColor = false;
            this.btn_lasku.Click += new System.EventHandler(this.btn_lasku_Click);
            // 
            // btn_aluemokki
            // 
            this.btn_aluemokki.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_aluemokki.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_aluemokki.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_aluemokki.Location = new System.Drawing.Point(37, 216);
            this.btn_aluemokki.Name = "btn_aluemokki";
            this.btn_aluemokki.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_aluemokki.Size = new System.Drawing.Size(277, 60);
            this.btn_aluemokki.TabIndex = 4;
            this.btn_aluemokki.Text = "Alueiden ja mökkien hallinta";
            this.btn_aluemokki.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_aluemokki.UseVisualStyleBackColor = false;
            this.btn_aluemokki.Click += new System.EventHandler(this.btn_aluemokki_Click);
            // 
            // header
            // 
            this.header.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.header.AutoSize = true;
            this.header.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header.Location = new System.Drawing.Point(299, 9);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(279, 42);
            this.header.TabIndex = 5;
            this.header.Text = "VillageNewbies";
            this.header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.header);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(847, 64);
            this.panel1.TabIndex = 6;
            // 
            // btn_majava2
            // 
            this.btn_majava2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_majava2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_majava2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_majava2.Location = new System.Drawing.Point(37, 83);
            this.btn_majava2.Name = "btn_majava2";
            this.btn_majava2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_majava2.Size = new System.Drawing.Size(277, 60);
            this.btn_majava2.TabIndex = 7;
            this.btn_majava2.Text = "Majoitusvarausten hallinta";
            this.btn_majava2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_majava2.UseVisualStyleBackColor = false;
            this.btn_majava2.Click += new System.EventHandler(this.btn_majava2_Click);
            // 
            // Majoittautumiset
            // 
            this.Majoittautumiset.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Majoittautumiset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Majoittautumiset.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Majoittautumiset.Location = new System.Drawing.Point(37, 348);
            this.Majoittautumiset.Name = "Majoittautumiset";
            this.Majoittautumiset.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Majoittautumiset.Size = new System.Drawing.Size(277, 60);
            this.Majoittautumiset.TabIndex = 8;
            this.Majoittautumiset.Text = "Palveluiden hallinta ja seuranta";
            this.Majoittautumiset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Majoittautumiset.UseVisualStyleBackColor = false;
            this.Majoittautumiset.Click += new System.EventHandler(this.btn_majoittutumiset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.BackgroundImage = global::Group9_VillageNewbies.Properties.Resources.VillageLogo;
            this.ClientSize = new System.Drawing.Size(836, 685);
            this.Controls.Add(this.Majoittautumiset);
            this.Controls.Add(this.btn_majava2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_aluemokki);
            this.Controls.Add(this.btn_lasku);
            this.Controls.Add(this.btn_asiakas);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Päävalikko";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private Button btn_asiakas;
        private Button btn_lasku;
        private Button btn_aluemokki;
        private Label header;
        private Panel panel1;
        private Button btn_majava2;
        private Button Majoittautumiset;
    }

}

