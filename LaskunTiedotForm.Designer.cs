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
            this.checkBoxMaksettu.Location = new System.Drawing.Point(93, 270);
            this.checkBoxMaksettu.Name = "checkBoxMaksettu";
            this.checkBoxMaksettu.Size = new System.Drawing.Size(80, 17);
            this.checkBoxMaksettu.TabIndex = 4;
            this.checkBoxMaksettu.Text = "checkBox1";
            this.checkBoxMaksettu.UseVisualStyleBackColor = true;
            // 
            // LaskunTiedotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}