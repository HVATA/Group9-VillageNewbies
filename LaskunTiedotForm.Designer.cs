namespace Group9_VillageNewbies
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
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCreatePdf = new System.Windows.Forms.Button();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxSumma
            // 
            this.textBoxSumma.Location = new System.Drawing.Point(93, 91);
            this.textBoxSumma.Name = "textBoxSumma";
            this.textBoxSumma.Size = new System.Drawing.Size(189, 20);
            this.textBoxSumma.TabIndex = 0;
            // 
            // textBoxErapvm
            // 
            this.textBoxErapvm.Location = new System.Drawing.Point(93, 179);
            this.textBoxErapvm.Name = "textBoxErapvm";
            this.textBoxErapvm.Size = new System.Drawing.Size(189, 20);
            this.textBoxErapvm.TabIndex = 2;
            // 
            // textBoxALV
            // 
            this.textBoxALV.Location = new System.Drawing.Point(93, 133);
            this.textBoxALV.Name = "textBoxALV";
            this.textBoxALV.Size = new System.Drawing.Size(189, 20);
            this.textBoxALV.TabIndex = 3;
            // 
            // checkBoxMaksettu
            // 
            this.checkBoxMaksettu.AutoSize = true;
            this.checkBoxMaksettu.Location = new System.Drawing.Point(93, 265);
            this.checkBoxMaksettu.Name = "checkBoxMaksettu";
            this.checkBoxMaksettu.Size = new System.Drawing.Size(70, 17);
            this.checkBoxMaksettu.TabIndex = 4;
            this.checkBoxMaksettu.Text = "Maksettu";
            this.checkBoxMaksettu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxMaksettu.UseVisualStyleBackColor = true;
            this.checkBoxMaksettu.CheckedChanged += new System.EventHandler(this.checkBoxMaksettu_CheckedChanged);
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(93, 48);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(189, 20);
            this.textBoxID.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Laskun numero";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(90, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Eräpvm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(90, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "ALV";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(90, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Laskun summa";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnCreatePdf
            // 
            this.btnCreatePdf.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreatePdf.Location = new System.Drawing.Point(95, 330);
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
            this.btnSendEmail.Location = new System.Drawing.Point(95, 359);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(152, 23);
            this.btnSendEmail.TabIndex = 11;
            this.btnSendEmail.Text = "Lähetä sähköpostiin";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(290, 361);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(236, 20);
            this.textBoxEmail.TabIndex = 12;
            // 
            // LaskunTiedotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.btnSendEmail);
            this.Controls.Add(this.btnCreatePdf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxID);
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
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCreatePdf;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
    }
}