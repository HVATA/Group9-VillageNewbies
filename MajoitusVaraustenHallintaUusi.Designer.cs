﻿namespace Group9_VillageNewbies
{
    partial class MajoitusVaraustenHallintaUusi
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.header = new System.Windows.Forms.Label();
            this.btn_back2menuVar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.btn_back2menuVar);
            this.panel1.Controls.Add(this.header);
            this.panel1.Location = new System.Drawing.Point(5, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 64);
            this.panel1.TabIndex = 73;
            // 
            // header
            // 
            this.header.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.header.AutoSize = true;
            this.header.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header.Location = new System.Drawing.Point(240, 11);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(300, 39);
            this.header.TabIndex = 5;
            this.header.Text = "Varausten Hallinta";
            this.header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_back2menuVar
            // 
            this.btn_back2menuVar.Location = new System.Drawing.Point(7, 11);
            this.btn_back2menuVar.Name = "btn_back2menuVar";
            this.btn_back2menuVar.Size = new System.Drawing.Size(75, 23);
            this.btn_back2menuVar.TabIndex = 74;
            this.btn_back2menuVar.Text = "<Takaisin";
            this.btn_back2menuVar.UseVisualStyleBackColor = true;
            this.btn_back2menuVar.Click += new System.EventHandler(this.btn_back2menuVar_Click);
            // 
            // MajoitusVaraustenHallintaUusi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MajoitusVaraustenHallintaUusi";
            this.Text = "MajoitusVaraustenHallintaUusi";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_back2menuVar;
        private System.Windows.Forms.Label header;
    }
}