namespace Group9_VillageNewbies
{
    partial class LisaaPaikkakuntaForm
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
            this.txtPaikkakunta = new System.Windows.Forms.TextBox();
            this.txtPostinumero = new System.Windows.Forms.TextBox();
            this.Paikkakunta = new System.Windows.Forms.Label();
            this.Postinumero = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lisää paikkakunta";
            // 
            // txtPaikkakunta
            // 
            this.txtPaikkakunta.Location = new System.Drawing.Point(170, 85);
            this.txtPaikkakunta.Name = "txtPaikkakunta";
            this.txtPaikkakunta.Size = new System.Drawing.Size(100, 22);
            this.txtPaikkakunta.TabIndex = 1;
            // 
            // txtPostinumero
            // 
            this.txtPostinumero.Location = new System.Drawing.Point(170, 113);
            this.txtPostinumero.Name = "txtPostinumero";
            this.txtPostinumero.Size = new System.Drawing.Size(100, 22);
            this.txtPostinumero.TabIndex = 2;
            // 
            // Paikkakunta
            // 
            this.Paikkakunta.AutoSize = true;
            this.Paikkakunta.Location = new System.Drawing.Point(71, 88);
            this.Paikkakunta.Name = "Paikkakunta";
            this.Paikkakunta.Size = new System.Drawing.Size(81, 16);
            this.Paikkakunta.TabIndex = 3;
            this.Paikkakunta.Text = "Paikkakunta";
            // 
            // Postinumero
            // 
            this.Postinumero.AutoSize = true;
            this.Postinumero.Location = new System.Drawing.Point(71, 116);
            this.Postinumero.Name = "Postinumero";
            this.Postinumero.Size = new System.Drawing.Size(82, 16);
            this.Postinumero.TabIndex = 4;
            this.Postinumero.Text = "Postinumero";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(111, 170);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lisää";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(220, 170);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Peru";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // LisaaPaikkakuntaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.Postinumero);
            this.Controls.Add(this.Paikkakunta);
            this.Controls.Add(this.txtPostinumero);
            this.Controls.Add(this.txtPaikkakunta);
            this.Controls.Add(this.label1);
            this.Name = "LisaaPaikkakuntaForm";
            this.Text = "LisaaPaikkakuntaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPaikkakunta;
        private System.Windows.Forms.TextBox txtPostinumero;
        private System.Windows.Forms.Label Paikkakunta;
        private System.Windows.Forms.Label Postinumero;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button2;
    }
}