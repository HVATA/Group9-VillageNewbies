﻿namespace Group9_VillageNewbies
{
    partial class LaskunTiedotForm
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
            this.textBoxSumma = new System.Windows.Forms.TextBox();
            this.textBoxErapvm = new System.Windows.Forms.TextBox();
            this.textBoxALV = new System.Windows.Forms.TextBox();
            this.checkBoxMaksettu = new System.Windows.Forms.CheckBox();
            this.textBoxEmail2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCreatePdf = new System.Windows.Forms.Button();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPuhelinnumero = new System.Windows.Forms.TextBox();
            this.textBoxOsoite = new System.Windows.Forms.TextBox();
            this.textBoxSukunimi = new System.Windows.Forms.TextBox();
            this.textBoxEtunimi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxLabel = new System.Windows.Forms.Label();
            this.Lasku = new System.Windows.Forms.Label();
            this.btn_DeleteLasku = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxSumma
            // 
            this.textBoxSumma.Location = new System.Drawing.Point(69, 323);
            this.textBoxSumma.Name = "textBoxSumma";
            this.textBoxSumma.Size = new System.Drawing.Size(189, 20);
            this.textBoxSumma.TabIndex = 0;
            // 
            // textBoxErapvm
            // 
            this.textBoxErapvm.Location = new System.Drawing.Point(69, 411);
            this.textBoxErapvm.Name = "textBoxErapvm";
            this.textBoxErapvm.Size = new System.Drawing.Size(189, 20);
            this.textBoxErapvm.TabIndex = 2;
            // 
            // textBoxALV
            // 
            this.textBoxALV.Location = new System.Drawing.Point(69, 365);
            this.textBoxALV.Name = "textBoxALV";
            this.textBoxALV.Size = new System.Drawing.Size(189, 20);
            this.textBoxALV.TabIndex = 3;
            // 
            // checkBoxMaksettu
            // 
            this.checkBoxMaksettu.AutoSize = true;
            this.checkBoxMaksettu.Location = new System.Drawing.Point(69, 460);
            this.checkBoxMaksettu.Name = "checkBoxMaksettu";
            this.checkBoxMaksettu.Size = new System.Drawing.Size(70, 17);
            this.checkBoxMaksettu.TabIndex = 4;
            this.checkBoxMaksettu.Text = "Maksettu";
            this.checkBoxMaksettu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxMaksettu.UseVisualStyleBackColor = true;
            this.checkBoxMaksettu.CheckedChanged += new System.EventHandler(this.checkBoxMaksettu_CheckedChanged);
            // 
            // textBoxEmail2
            // 
            this.textBoxEmail2.Location = new System.Drawing.Point(69, 280);
            this.textBoxEmail2.Name = "textBoxEmail2";
            this.textBoxEmail2.Size = new System.Drawing.Size(189, 20);
            this.textBoxEmail2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Sähköposti";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Eräpvm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(66, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "ALV";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(66, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Laskun summa";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnCreatePdf
            // 
            this.btnCreatePdf.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreatePdf.Location = new System.Drawing.Point(69, 498);
            this.btnCreatePdf.Name = "btnCreatePdf";
            this.btnCreatePdf.Size = new System.Drawing.Size(152, 23);
            this.btnCreatePdf.TabIndex = 10;
            this.btnCreatePdf.Text = "Tee pdf-lasku";
            this.btnCreatePdf.UseVisualStyleBackColor = true;
            this.btnCreatePdf.Click += new System.EventHandler(this.btnCreatePdf_Click);
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendEmail.Location = new System.Drawing.Point(69, 527);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(152, 23);
            this.btnSendEmail.TabIndex = 11;
            this.btnSendEmail.Text = "Lähetä sähköpostiin";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(266, 556);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(236, 20);
            this.textBoxEmail.TabIndex = 12;
            // 
            // textBoxPuhelinnumero
            // 
            this.textBoxPuhelinnumero.Location = new System.Drawing.Point(71, 241);
            this.textBoxPuhelinnumero.Name = "textBoxPuhelinnumero";
            this.textBoxPuhelinnumero.Size = new System.Drawing.Size(189, 20);
            this.textBoxPuhelinnumero.TabIndex = 13;
            // 
            // textBoxOsoite
            // 
            this.textBoxOsoite.Location = new System.Drawing.Point(69, 205);
            this.textBoxOsoite.Name = "textBoxOsoite";
            this.textBoxOsoite.Size = new System.Drawing.Size(189, 20);
            this.textBoxOsoite.TabIndex = 14;
            // 
            // textBoxSukunimi
            // 
            this.textBoxSukunimi.Location = new System.Drawing.Point(69, 168);
            this.textBoxSukunimi.Name = "textBoxSukunimi";
            this.textBoxSukunimi.Size = new System.Drawing.Size(189, 20);
            this.textBoxSukunimi.TabIndex = 15;
            // 
            // textBoxEtunimi
            // 
            this.textBoxEtunimi.Location = new System.Drawing.Point(71, 131);
            this.textBoxEtunimi.Name = "textBoxEtunimi";
            this.textBoxEtunimi.Size = new System.Drawing.Size(189, 20);
            this.textBoxEtunimi.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(68, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Puhelinnumero";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(68, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Osoite";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(68, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Sukunimi";
            // 
            // textBoxLabel
            // 
            this.textBoxLabel.AutoSize = true;
            this.textBoxLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLabel.Location = new System.Drawing.Point(68, 115);
            this.textBoxLabel.Name = "textBoxLabel";
            this.textBoxLabel.Size = new System.Drawing.Size(49, 13);
            this.textBoxLabel.TabIndex = 20;
            this.textBoxLabel.Text = "Etunimi";
            this.textBoxLabel.Click += new System.EventHandler(this.label8_Click);
            // 
            // Lasku
            // 
            this.Lasku.AutoSize = true;
            this.Lasku.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lasku.Location = new System.Drawing.Point(68, 59);
            this.Lasku.Name = "Lasku";
            this.Lasku.Size = new System.Drawing.Size(102, 29);
            this.Lasku.TabIndex = 21;
            this.Lasku.Text = "LASKU";
            // 
            // btn_DeleteLasku
            // 
            this.btn_DeleteLasku.Location = new System.Drawing.Point(71, 556);
            this.btn_DeleteLasku.Name = "btn_DeleteLasku";
            this.btn_DeleteLasku.Size = new System.Drawing.Size(150, 23);
            this.btn_DeleteLasku.TabIndex = 22;
            this.btn_DeleteLasku.Text = "Poista lasku";
            this.btn_DeleteLasku.UseVisualStyleBackColor = true;
            this.btn_DeleteLasku.Click += new System.EventHandler(this.btn_DeleteLasku_Click);
            // 
            // LaskunTiedotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 613);
            this.Controls.Add(this.btn_DeleteLasku);
            this.Controls.Add(this.Lasku);
            this.Controls.Add(this.textBoxLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxEtunimi);
            this.Controls.Add(this.textBoxSukunimi);
            this.Controls.Add(this.textBoxOsoite);
            this.Controls.Add(this.textBoxPuhelinnumero);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.btnSendEmail);
            this.Controls.Add(this.btnCreatePdf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEmail2);
            this.Controls.Add(this.checkBoxMaksettu);
            this.Controls.Add(this.textBoxALV);
            this.Controls.Add(this.textBoxErapvm);
            this.Controls.Add(this.textBoxSumma);
            this.Name = "LaskunTiedotForm";
            this.Text = "LaskunTiedotForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSumma;
        private System.Windows.Forms.TextBox textBoxErapvm;
        private System.Windows.Forms.TextBox textBoxALV;
        private System.Windows.Forms.CheckBox checkBoxMaksettu;
        private System.Windows.Forms.TextBox textBoxEmail2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCreatePdf;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPuhelinnumero;
        private System.Windows.Forms.TextBox textBoxOsoite;
        private System.Windows.Forms.TextBox textBoxSukunimi;
        private System.Windows.Forms.TextBox textBoxEtunimi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label textBoxLabel;
        private System.Windows.Forms.Label Lasku;
        private System.Windows.Forms.Button btn_DeleteLasku;
    }
}