namespace Group9_VillageNewbies
    {
    partial class Palvelumuokkaus
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
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
        private void InitializeComponent ()
            {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.PalveluNimiTextBox = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.AlueNimiTextBox = new System.Windows.Forms.TextBox();
            this.HintaTextBox = new System.Windows.Forms.TextBox();
            this.KuvausTextBox = new System.Windows.Forms.TextBox();
            this.BtnTallenna = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.Location = new System.Drawing.Point(19, 139);
            this.textBox1.Margin = new System.Windows.Forms.Padding(10);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Kuvaus";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox2.Location = new System.Drawing.Point(19, 59);
            this.textBox2.Margin = new System.Windows.Forms.Padding(10);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "Alueen nimi";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PalveluNimiTextBox
            // 
            this.PalveluNimiTextBox.Location = new System.Drawing.Point(139, 19);
            this.PalveluNimiTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.PalveluNimiTextBox.Name = "PalveluNimiTextBox";
            this.PalveluNimiTextBox.Size = new System.Drawing.Size(261, 20);
            this.PalveluNimiTextBox.TabIndex = 2;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox5.Location = new System.Drawing.Point(19, 99);
            this.textBox5.Margin = new System.Windows.Forms.Padding(10);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 4;
            this.textBox5.Text = "Hinta";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox6.Location = new System.Drawing.Point(19, 19);
            this.textBox6.Margin = new System.Windows.Forms.Padding(10);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 5;
            this.textBox6.Text = "Palvelun nimi";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AlueNimiTextBox
            // 
            this.AlueNimiTextBox.Location = new System.Drawing.Point(139, 59);
            this.AlueNimiTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.AlueNimiTextBox.Name = "AlueNimiTextBox";
            this.AlueNimiTextBox.Size = new System.Drawing.Size(261, 20);
            this.AlueNimiTextBox.TabIndex = 6;
            // 
            // HintaTextBox
            // 
            this.HintaTextBox.Location = new System.Drawing.Point(139, 99);
            this.HintaTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.HintaTextBox.Name = "HintaTextBox";
            this.HintaTextBox.Size = new System.Drawing.Size(261, 20);
            this.HintaTextBox.TabIndex = 7;
            // 
            // KuvausTextBox
            // 
            this.KuvausTextBox.Location = new System.Drawing.Point(139, 139);
            this.KuvausTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.KuvausTextBox.Multiline = true;
            this.KuvausTextBox.Name = "KuvausTextBox";
            this.KuvausTextBox.Size = new System.Drawing.Size(261, 115);
            this.KuvausTextBox.TabIndex = 8;
            // 
            // BtnTallenna
            // 
            this.BtnTallenna.Location = new System.Drawing.Point(19, 381);
            this.BtnTallenna.Margin = new System.Windows.Forms.Padding(10);
            this.BtnTallenna.Name = "BtnTallenna";
            this.BtnTallenna.Size = new System.Drawing.Size(151, 74);
            this.BtnTallenna.TabIndex = 9;
            this.BtnTallenna.Text = "Tallenna";
            this.BtnTallenna.UseVisualStyleBackColor = true;
            this.BtnTallenna.Click += new System.EventHandler(this.BtnTallenna_Click);
            // 
            // BtnBack
            // 
            this.BtnBack.Location = new System.Drawing.Point(247, 381);
            this.BtnBack.Margin = new System.Windows.Forms.Padding(10);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(153, 74);
            this.BtnBack.TabIndex = 10;
            this.BtnBack.Text = "Peruuta";
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // Palvelumuokkaus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(419, 474);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.BtnTallenna);
            this.Controls.Add(this.KuvausTextBox);
            this.Controls.Add(this.HintaTextBox);
            this.Controls.Add(this.AlueNimiTextBox);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.PalveluNimiTextBox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Palvelumuokkaus";
            this.Text = "Palvelumuokkaus";
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox PalveluNimiTextBox;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox AlueNimiTextBox;
        private System.Windows.Forms.TextBox HintaTextBox;
        private System.Windows.Forms.TextBox KuvausTextBox;
        private System.Windows.Forms.Button BtnTallenna;
        private System.Windows.Forms.Button BtnBack;
        }
    }