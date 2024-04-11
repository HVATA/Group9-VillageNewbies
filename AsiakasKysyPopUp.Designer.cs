namespace Group9_VillageNewbies
{
    partial class AsiakasKysyPopUp
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_asUusi = new System.Windows.Forms.Button();
            this.btn_asVanha = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Uusi asiakas vai Vanha asiakas?";
            // 
            // btn_asUusi
            // 
            this.btn_asUusi.Location = new System.Drawing.Point(52, 58);
            this.btn_asUusi.Name = "btn_asUusi";
            this.btn_asUusi.Size = new System.Drawing.Size(146, 54);
            this.btn_asUusi.TabIndex = 1;
            this.btn_asUusi.Text = "Uusi Asiakas";
            this.btn_asUusi.UseVisualStyleBackColor = true;
            this.btn_asUusi.Click += new System.EventHandler(this.btn_asUusi_Click);
            // 
            // btn_asVanha
            // 
            this.btn_asVanha.Location = new System.Drawing.Point(52, 118);
            this.btn_asVanha.Name = "btn_asVanha";
            this.btn_asVanha.Size = new System.Drawing.Size(146, 54);
            this.btn_asVanha.TabIndex = 2;
            this.btn_asVanha.Text = "Vanha Asiakas";
            this.btn_asVanha.UseVisualStyleBackColor = true;
            this.btn_asVanha.Click += new System.EventHandler(this.btn_asVanha_Click);
            // 
            // AsiakasKysyPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 207);
            this.Controls.Add(this.btn_asVanha);
            this.Controls.Add(this.btn_asUusi);
            this.Controls.Add(this.label1);
            this.Name = "AsiakasKysyPopUp";
            this.Text = "AsiakasKysyPopUp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_asUusi;
        private System.Windows.Forms.Button btn_asVanha;
    }
}