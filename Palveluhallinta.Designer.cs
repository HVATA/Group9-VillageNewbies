namespace Group9_VillageNewbies
    {
    partial class Palveluhallinta
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.alueNimiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nimiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hintaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kuvausDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSet1 = new Group9_VillageNewbies.DataSet1();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.palveluTableAdapter = new Group9_VillageNewbies.DataSet1TableAdapters.palveluTableAdapter();
            this.palveluTableAdapter1 = new Group9_VillageNewbies.DataSet1TableAdapters.palveluTableAdapter();
            this.alueComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.alueNimiDataGridViewTextBoxColumn,
            this.nimiDataGridViewTextBoxColumn,
            this.hintaDataGridViewTextBoxColumn,
            this.kuvausDataGridViewTextBoxColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 151);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(788, 298);
            this.dataGridView1.TabIndex = 2;
            // 
            // alueNimiDataGridViewTextBoxColumn
            // 
            this.alueNimiDataGridViewTextBoxColumn.DataPropertyName = "AlueNimi";
            this.alueNimiDataGridViewTextBoxColumn.HeaderText = "Alue";
            this.alueNimiDataGridViewTextBoxColumn.Name = "alueNimiDataGridViewTextBoxColumn";
            // 
            // nimiDataGridViewTextBoxColumn
            // 
            this.nimiDataGridViewTextBoxColumn.DataPropertyName = "Nimi";
            this.nimiDataGridViewTextBoxColumn.HeaderText = "Nimi";
            this.nimiDataGridViewTextBoxColumn.Name = "nimiDataGridViewTextBoxColumn";
            // 
            // hintaDataGridViewTextBoxColumn
            // 
            this.hintaDataGridViewTextBoxColumn.DataPropertyName = "Hinta";
            this.hintaDataGridViewTextBoxColumn.HeaderText = "Hinta";
            this.hintaDataGridViewTextBoxColumn.Name = "hintaDataGridViewTextBoxColumn";
            this.hintaDataGridViewTextBoxColumn.ToolTipText = "ALV 24%";
            // 
            // kuvausDataGridViewTextBoxColumn
            // 
            this.kuvausDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kuvausDataGridViewTextBoxColumn.DataPropertyName = "Kuvaus";
            this.kuvausDataGridViewTextBoxColumn.HeaderText = "Kuvaus";
            this.kuvausDataGridViewTextBoxColumn.Name = "kuvausDataGridViewTextBoxColumn";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "palvelu";
            this.bindingSource1.DataSource = this.dataSet1;
            // 
            // palveluTableAdapter
            // 
            this.palveluTableAdapter.ClearBeforeFill = true;
            // 
            // palveluTableAdapter1
            // 
            this.palveluTableAdapter1.ClearBeforeFill = true;
            // 
            // alueComboBox
            // 
            this.alueComboBox.FormattingEnabled = true;
            this.alueComboBox.Location = new System.Drawing.Point(256, 77);
            this.alueComboBox.Name = "alueComboBox";
            this.alueComboBox.Size = new System.Drawing.Size(121, 21);
            this.alueComboBox.TabIndex = 3;
            // 
            // Palveluhallinta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(812, 461);
            this.Controls.Add(this.alueComboBox);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Palveluhallinta";
            this.Text = "Palveluhallinta";
            this.Load += new System.EventHandler(this.Palveluhallinta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn alueNimiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nimiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hintaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kuvausDataGridViewTextBoxColumn;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DataSet1TableAdapters.palveluTableAdapter palveluTableAdapter;
        private DataSet1TableAdapters.palveluTableAdapter palveluTableAdapter1;
        private System.Windows.Forms.ComboBox alueComboBox;
        }
    }
