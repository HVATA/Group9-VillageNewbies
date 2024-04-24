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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataSet1 = new Group9_VillageNewbies.DataSet1();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.palveluTableAdapter = new Group9_VillageNewbies.DataSet1TableAdapters.palveluTableAdapter();
            this.palveluTableAdapter1 = new Group9_VillageNewbies.DataSet1TableAdapters.palveluTableAdapter();
            this.AlueComboBox = new System.Windows.Forms.ComboBox();
            this.BtnChange = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.alueNimiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nimiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hintaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kuvausDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varatutPalvelutBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
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
            // AlueComboBox
            // 
            this.AlueComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AlueComboBox.FormattingEnabled = true;
            this.AlueComboBox.Location = new System.Drawing.Point(12, 12);
            this.AlueComboBox.Name = "AlueComboBox";
            this.AlueComboBox.Size = new System.Drawing.Size(164, 28);
            this.AlueComboBox.TabIndex = 7;
            this.AlueComboBox.SelectedIndexChanged += new System.EventHandler(this.AlueComboBox_SelectedIndexChanged);
            // 
            // BtnChange
            // 
            this.BtnChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnChange.Location = new System.Drawing.Point(333, 12);
            this.BtnChange.Name = "BtnChange";
            this.BtnChange.Size = new System.Drawing.Size(130, 56);
            this.BtnChange.TabIndex = 8;
            this.BtnChange.Text = "Muokkaa";
            this.BtnChange.UseVisualStyleBackColor = true;
            this.BtnChange.Click += new System.EventHandler(this.BtnChange_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnDelete.Location = new System.Drawing.Point(469, 12);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(135, 56);
            this.BtnDelete.TabIndex = 9;
            this.BtnDelete.Text = "Poista";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnAdd.Location = new System.Drawing.Point(197, 12);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(130, 56);
            this.BtnAdd.TabIndex = 10;
            this.BtnAdd.Text = "Lisää palveluita";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BtnClose.Location = new System.Drawing.Point(738, 12);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(62, 56);
            this.BtnClose.TabIndex = 11;
            this.BtnClose.Text = "Sulje";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.AllowUserToResizeColumns = false;
            this.DataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.alueNimiDataGridViewTextBoxColumn,
            this.nimiDataGridViewTextBoxColumn,
            this.hintaDataGridViewTextBoxColumn,
            this.kuvausDataGridViewTextBoxColumn});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridView1.Location = new System.Drawing.Point(12, 74);
            this.DataGridView1.MultiSelect = false;
            this.DataGridView1.Name = "DataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DataGridView1.RowHeadersVisible = false;
            this.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView1.Size = new System.Drawing.Size(788, 375);
            this.DataGridView1.TabIndex = 2;
            // 
            // alueNimiDataGridViewTextBoxColumn
            // 
            this.alueNimiDataGridViewTextBoxColumn.DataPropertyName = "AlueNimi";
            this.alueNimiDataGridViewTextBoxColumn.HeaderText = "Alue";
            this.alueNimiDataGridViewTextBoxColumn.Name = "alueNimiDataGridViewTextBoxColumn";
            this.alueNimiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nimiDataGridViewTextBoxColumn
            // 
            this.nimiDataGridViewTextBoxColumn.DataPropertyName = "Nimi";
            this.nimiDataGridViewTextBoxColumn.HeaderText = "Nimi";
            this.nimiDataGridViewTextBoxColumn.Name = "nimiDataGridViewTextBoxColumn";
            this.nimiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // hintaDataGridViewTextBoxColumn
            // 
            this.hintaDataGridViewTextBoxColumn.DataPropertyName = "Hinta";
            this.hintaDataGridViewTextBoxColumn.HeaderText = "Hinta";
            this.hintaDataGridViewTextBoxColumn.Name = "hintaDataGridViewTextBoxColumn";
            this.hintaDataGridViewTextBoxColumn.ReadOnly = true;
            this.hintaDataGridViewTextBoxColumn.ToolTipText = "ALV 24%";
            // 
            // kuvausDataGridViewTextBoxColumn
            // 
            this.kuvausDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kuvausDataGridViewTextBoxColumn.DataPropertyName = "Kuvaus";
            this.kuvausDataGridViewTextBoxColumn.HeaderText = "Kuvaus";
            this.kuvausDataGridViewTextBoxColumn.Name = "kuvausDataGridViewTextBoxColumn";
            this.kuvausDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // varatutPalvelutBtn
            // 
            this.varatutPalvelutBtn.Location = new System.Drawing.Point(610, 12);
            this.varatutPalvelutBtn.Name = "varatutPalvelutBtn";
            this.varatutPalvelutBtn.Size = new System.Drawing.Size(122, 56);
            this.varatutPalvelutBtn.TabIndex = 12;
            this.varatutPalvelutBtn.Text = "Varatut palvelut";
            this.varatutPalvelutBtn.UseVisualStyleBackColor = true;
            this.varatutPalvelutBtn.Click += new System.EventHandler(this.varatutPalvelutBtn_Click);
            // 
            // Palveluhallinta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(812, 461);
            this.Controls.Add(this.varatutPalvelutBtn);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnChange);
            this.Controls.Add(this.AlueComboBox);
            this.Controls.Add(this.DataGridView1);
            this.Name = "Palveluhallinta";
            this.Text = "Palveluhallinta";
            this.Load += new System.EventHandler(this.Palveluhallinta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DataSet1TableAdapters.palveluTableAdapter palveluTableAdapter;
        private DataSet1TableAdapters.palveluTableAdapter palveluTableAdapter1;
        private System.Windows.Forms.ComboBox AlueComboBox;
        private System.Windows.Forms.Button BtnChange;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn alueNimiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nimiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hintaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kuvausDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button varatutPalvelutBtn;
        }
    }
