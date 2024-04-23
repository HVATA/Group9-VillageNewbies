namespace Group9_VillageNewbies
{
    partial class Laskujenhallinta
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnShowUnpaidInvoices = new System.Windows.Forms.Button();
            this.btnShowPaidInvoices = new System.Windows.Forms.Button();
            this.btnOverdue = new System.Windows.Forms.Button();
            this.btnAllInvoices = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 209);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1081, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kaikki laskut:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(421, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(261, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Laskujen seuranta";
            // 
            // btnShowUnpaidInvoices
            // 
            this.btnShowUnpaidInvoices.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowUnpaidInvoices.Location = new System.Drawing.Point(31, 410);
            this.btnShowUnpaidInvoices.Name = "btnShowUnpaidInvoices";
            this.btnShowUnpaidInvoices.Size = new System.Drawing.Size(174, 23);
            this.btnShowUnpaidInvoices.TabIndex = 3;
            this.btnShowUnpaidInvoices.Text = "Näytä maksamattomat";
            this.btnShowUnpaidInvoices.UseVisualStyleBackColor = true;
            this.btnShowUnpaidInvoices.Click += new System.EventHandler(this.btnShowUnpaidInvoices_Click);
            // 
            // btnShowPaidInvoices
            // 
            this.btnShowPaidInvoices.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowPaidInvoices.Location = new System.Drawing.Point(31, 439);
            this.btnShowPaidInvoices.Name = "btnShowPaidInvoices";
            this.btnShowPaidInvoices.Size = new System.Drawing.Size(174, 23);
            this.btnShowPaidInvoices.TabIndex = 4;
            this.btnShowPaidInvoices.Text = "Näytä maksetut";
            this.btnShowPaidInvoices.UseVisualStyleBackColor = true;
            this.btnShowPaidInvoices.Click += new System.EventHandler(this.btnShowPaidInvoices_Click);
            // 
            // btnOverdue
            // 
            this.btnOverdue.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOverdue.Location = new System.Drawing.Point(31, 468);
            this.btnOverdue.Name = "btnOverdue";
            this.btnOverdue.Size = new System.Drawing.Size(174, 23);
            this.btnOverdue.TabIndex = 5;
            this.btnOverdue.Text = "Näytä myöhässä olevat laskut";
            this.btnOverdue.UseVisualStyleBackColor = true;
            this.btnOverdue.Click += new System.EventHandler(this.btnOverdue_Click);
            // 
            // btnAllInvoices
            // 
            this.btnAllInvoices.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllInvoices.Location = new System.Drawing.Point(31, 381);
            this.btnAllInvoices.Name = "btnAllInvoices";
            this.btnAllInvoices.Size = new System.Drawing.Size(174, 23);
            this.btnAllInvoices.TabIndex = 6;
            this.btnAllInvoices.Text = "Näytä kaikki laskut";
            this.btnAllInvoices.UseVisualStyleBackColor = true;
            this.btnAllInvoices.Click += new System.EventHandler(this.btnAllInvoices_Click);
            // 
            // Laskujenhallinta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1133, 585);
            this.Controls.Add(this.btnAllInvoices);
            this.Controls.Add(this.btnOverdue);
            this.Controls.Add(this.btnShowPaidInvoices);
            this.Controls.Add(this.btnShowUnpaidInvoices);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Laskujenhallinta";
            this.Text = "Laskujenhallinta";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnShowUnpaidInvoices;
        private System.Windows.Forms.Button btnShowPaidInvoices;
        private System.Windows.Forms.Button btnOverdue;
        private System.Windows.Forms.Button btnAllInvoices;
    }
}