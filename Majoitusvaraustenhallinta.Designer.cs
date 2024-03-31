namespace Group9_VillageNewbies
{
    partial class Majoitusvaraustenhallinta
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.header = new System.Windows.Forms.Label();
            this.dataSet1 = new Group9_VillageNewbies.DataSet1();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxNimi = new System.Windows.Forms.TextBox();
            this.textBoxOsoite = new System.Windows.Forms.TextBox();
            this.textBoxVarustelu = new System.Windows.Forms.TextBox();
            this.textBoxHenkilomaara = new System.Windows.Forms.TextBox();
            this.textBoxHinta = new System.Windows.Forms.TextBox();
            this.dataGridViewMokit = new System.Windows.Forms.DataGridView();
            this.Lisää = new System.Windows.Forms.Button();
            this.Poista = new System.Windows.Forms.Button();
            this.Muokkaa = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMokit)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.header);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1027, 64);
            this.panel1.TabIndex = 12;
            // 
            // header
            // 
            this.header.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.header.AutoSize = true;
            this.header.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header.Location = new System.Drawing.Point(303, 9);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(410, 39);
            this.header.TabIndex = 5;
            this.header.Text = "Majoitusvaraustenhallinta\r\n";
            this.header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.header.Click += new System.EventHandler(this.header_Click);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSet1BindingSource
            // 
            this.dataSet1BindingSource.DataSource = this.dataSet1;
            this.dataSet1BindingSource.Position = 0;
            // 
            // textBoxNimi
            // 
            this.textBoxNimi.Location = new System.Drawing.Point(208, 135);
            this.textBoxNimi.Name = "textBoxNimi";
            this.textBoxNimi.Size = new System.Drawing.Size(296, 20);
            this.textBoxNimi.TabIndex = 14;
            // 
            // textBoxOsoite
            // 
            this.textBoxOsoite.Location = new System.Drawing.Point(208, 173);
            this.textBoxOsoite.Name = "textBoxOsoite";
            this.textBoxOsoite.Size = new System.Drawing.Size(296, 20);
            this.textBoxOsoite.TabIndex = 15;
            // 
            // textBoxVarustelu
            // 
            this.textBoxVarustelu.Location = new System.Drawing.Point(208, 299);
            this.textBoxVarustelu.Name = "textBoxVarustelu";
            this.textBoxVarustelu.Size = new System.Drawing.Size(296, 20);
            this.textBoxVarustelu.TabIndex = 16;
            // 
            // textBoxHenkilomaara
            // 
            this.textBoxHenkilomaara.Location = new System.Drawing.Point(208, 255);
            this.textBoxHenkilomaara.Name = "textBoxHenkilomaara";
            this.textBoxHenkilomaara.Size = new System.Drawing.Size(296, 20);
            this.textBoxHenkilomaara.TabIndex = 17;
            // 
            // textBoxHinta
            // 
            this.textBoxHinta.Location = new System.Drawing.Point(208, 215);
            this.textBoxHinta.Name = "textBoxHinta";
            this.textBoxHinta.Size = new System.Drawing.Size(296, 20);
            this.textBoxHinta.TabIndex = 18;
            // 
            // dataGridViewMokit
            // 
            this.dataGridViewMokit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMokit.Location = new System.Drawing.Point(104, 366);
            this.dataGridViewMokit.Name = "dataGridViewMokit";
            this.dataGridViewMokit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMokit.Size = new System.Drawing.Size(881, 150);
            this.dataGridViewMokit.TabIndex = 19;
            this.dataGridViewMokit.SelectionChanged += new System.EventHandler(this.dataGridViewMokit_SelectionChanged);
            // 
            // Lisää
            // 
            this.Lisää.Location = new System.Drawing.Point(740, 135);
            this.Lisää.Name = "Lisää";
            this.Lisää.Size = new System.Drawing.Size(75, 23);
            this.Lisää.TabIndex = 20;
            this.Lisää.Text = "Lisää";
            this.Lisää.UseVisualStyleBackColor = true;
            // 
            // Poista
            // 
            this.Poista.Location = new System.Drawing.Point(740, 212);
            this.Poista.Name = "Poista";
            this.Poista.Size = new System.Drawing.Size(75, 23);
            this.Poista.TabIndex = 21;
            this.Poista.Text = "Poista";
            this.Poista.UseVisualStyleBackColor = true;
            // 
            // Muokkaa
            // 
            this.Muokkaa.Location = new System.Drawing.Point(740, 173);
            this.Muokkaa.Name = "Muokkaa";
            this.Muokkaa.Size = new System.Drawing.Size(75, 23);
            this.Muokkaa.TabIndex = 22;
            this.Muokkaa.Text = "Muokkaa";
            this.Muokkaa.UseVisualStyleBackColor = true;
            // 
            // Majoitusvaraustenhallinta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(1032, 625);
            this.Controls.Add(this.Muokkaa);
            this.Controls.Add(this.Poista);
            this.Controls.Add(this.Lisää);
            this.Controls.Add(this.dataGridViewMokit);
            this.Controls.Add(this.textBoxHinta);
            this.Controls.Add(this.textBoxHenkilomaara);
            this.Controls.Add(this.textBoxVarustelu);
            this.Controls.Add(this.textBoxOsoite);
            this.Controls.Add(this.textBoxNimi);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Majoitusvaraustenhallinta";
            this.Text = "Majoitusvaraustenhallinta";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMokit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label header;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private System.Windows.Forms.TextBox textBoxNimi;
        private System.Windows.Forms.TextBox textBoxOsoite;
        private System.Windows.Forms.TextBox textBoxVarustelu;
        private System.Windows.Forms.TextBox textBoxHenkilomaara;
        private System.Windows.Forms.TextBox textBoxHinta;
        private System.Windows.Forms.DataGridView dataGridViewMokit;
        private System.Windows.Forms.Button Lisää;
        private System.Windows.Forms.Button Poista;
        private System.Windows.Forms.Button Muokkaa;
    }
}