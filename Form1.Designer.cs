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
            this.btn_majoitus = new System.Windows.Forms.Button();
            this.btn_asiakas = new System.Windows.Forms.Button();
            this.btn_lasku = new System.Windows.Forms.Button();
            this.btn_aluemokki = new System.Windows.Forms.Button();
            this.header = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_majava2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_majoitus
            // 
            this.btn_majoitus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_majoitus.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_majoitus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_majoitus.Location = new System.Drawing.Point(60, 70);
            this.btn_majoitus.Name = "btn_majoitus";
            this.btn_majoitus.Size = new System.Drawing.Size(154, 72);
            this.btn_majoitus.TabIndex = 1;
            this.btn_majoitus.Text = "Majoitusvarausten hallinta";
            this.btn_majoitus.UseVisualStyleBackColor = false;
            this.btn_majoitus.Click += new System.EventHandler(this.btn_majoitus_Click);
            // 
            // btn_asiakas
            // 
            this.btn_asiakas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_asiakas.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_asiakas.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_asiakas.Location = new System.Drawing.Point(232, 70);
            this.btn_asiakas.Name = "btn_asiakas";
            this.btn_asiakas.Size = new System.Drawing.Size(154, 72);
            this.btn_asiakas.TabIndex = 2;
            this.btn_asiakas.Text = "Asiakkaiden hallinta";
            this.btn_asiakas.UseVisualStyleBackColor = false;
            this.btn_asiakas.Click += new System.EventHandler(this.btn_asiakas_Click);
            // 
            // btn_lasku
            // 
            this.btn_lasku.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_lasku.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_lasku.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lasku.Location = new System.Drawing.Point(576, 70);
            this.btn_lasku.Name = "btn_lasku";
            this.btn_lasku.Size = new System.Drawing.Size(152, 72);
            this.btn_lasku.TabIndex = 3;
            this.btn_lasku.Text = "Laskujen hallinta ja seuranta";
            this.btn_lasku.UseVisualStyleBackColor = false;
            this.btn_lasku.Click += new System.EventHandler(this.btn_lasku_Click);
            // 
            // btn_aluemokki
            // 
            this.btn_aluemokki.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_aluemokki.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_aluemokki.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_aluemokki.Location = new System.Drawing.Point(404, 70);
            this.btn_aluemokki.Name = "btn_aluemokki";
            this.btn_aluemokki.Size = new System.Drawing.Size(154, 72);
            this.btn_aluemokki.TabIndex = 4;
            this.btn_aluemokki.Text = "Alueiden ja mökkien hallinta";
            this.btn_aluemokki.UseVisualStyleBackColor = false;
            this.btn_aluemokki.Click += new System.EventHandler(this.btn_aluemokki_Click);
            // 
            // header
            // 
            this.header.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.header.AutoSize = true;
            this.header.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header.Location = new System.Drawing.Point(273, 9);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(254, 39);
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
            this.panel1.Size = new System.Drawing.Size(795, 64);
            this.panel1.TabIndex = 6;
            // 
            // btn_majava2
            // 
            this.btn_majava2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_majava2.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_majava2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_majava2.Location = new System.Drawing.Point(315, 244);
            this.btn_majava2.Name = "btn_majava2";
            this.btn_majava2.Size = new System.Drawing.Size(154, 72);
            this.btn_majava2.TabIndex = 7;
            this.btn_majava2.Text = "Majoitusvarausten hallinta2";
            this.btn_majava2.UseVisualStyleBackColor = false;
            this.btn_majava2.Click += new System.EventHandler(this.btn_majava2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btn_majava2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_aluemokki);
            this.Controls.Add(this.btn_lasku);
            this.Controls.Add(this.btn_asiakas);
            this.Controls.Add(this.btn_majoitus);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Päävalikko";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;

        /*
        private void button1_Click(object sender, EventArgs e)
        {
            AsiakasRepository asiakasRepository = new AsiakasRepository();
            List<Asiakas> asiakkaat = asiakasRepository.HaeAsiakkaat();
            foreach (Asiakas asiakas in asiakkaat)
            {
                textBox1.Text += asiakas.Etunimi + " " + asiakas.Sukunimi + "\n";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AsiakasRepository asiakasRepository = new AsiakasRepository();
            List<Asiakas> asiakkaat = asiakasRepository.HaeAsiakkaat();
            foreach (Asiakas asiakas in asiakkaat)
            {
                textBox2.Text += asiakas.Etunimi + " " + asiakas.Sukunimi + "\n";
            }
        }
        */
        private Button btn_majoitus;
        private Button btn_asiakas;
        private Button btn_lasku;
        private Button btn_aluemokki;
        private Label header;
        private Panel panel1;
        private Button btn_majava2;
    }

}

