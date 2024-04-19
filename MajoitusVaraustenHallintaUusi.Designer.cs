namespace Group9_VillageNewbies
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_back2menuVar = new System.Windows.Forms.Button();
            this.header = new System.Windows.Forms.Label();
            this.btn_EtsiVaraus = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataSet1 = new Group9_VillageNewbies.DataSet1();
            this.palveluBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.palveluTableAdapter = new Group9_VillageNewbies.DataSet1TableAdapters.palveluTableAdapter();
            this.dataGridView_Varaus = new System.Windows.Forms.DataGridView();
            this.varausidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asiakasidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mokkimokkiidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varattupvmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vahvistuspvmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varattualkupvmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varattuloppupvmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varausBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2 = new Group9_VillageNewbies.DataSet2();
            this.varausTableAdapter = new Group9_VillageNewbies.DataSet2TableAdapters.varausTableAdapter();
            this.comboBox_VarFindMokki = new System.Windows.Forms.ComboBox();
            this.comboBox_VarFindAlue = new System.Windows.Forms.ComboBox();
            this.comboBox_VarFindAsiakas = new System.Windows.Forms.ComboBox();
            this.btn_toAddEditDelete = new System.Windows.Forms.Button();
            this.emptyHakuEhdot = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palveluBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Varaus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.varausBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
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
            // btn_EtsiVaraus
            // 
            this.btn_EtsiVaraus.Location = new System.Drawing.Point(121, 272);
            this.btn_EtsiVaraus.Name = "btn_EtsiVaraus";
            this.btn_EtsiVaraus.Size = new System.Drawing.Size(75, 23);
            this.btn_EtsiVaraus.TabIndex = 76;
            this.btn_EtsiVaraus.Text = "Etsi";
            this.btn_EtsiVaraus.UseVisualStyleBackColor = true;
            this.btn_EtsiVaraus.Click += new System.EventHandler(this.btn_EtsiVaraus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "Mökki:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 81;
            this.label2.Text = "Alue:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 82;
            this.label3.Text = "Sukunimi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 83;
            this.label4.Text = "Alkamispäivämäärä:";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(121, 210);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerStart.TabIndex = 84;
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.dateTimePickerStart_ValueChanged);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(120, 236);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEnd.TabIndex = 85;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 86;
            this.label5.Text = "Päättymispäivämäärä:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(79, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(288, 64);
            this.label6.TabIndex = 0;
            this.label6.Text = "Etsi varaus";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // palveluBindingSource
            // 
            this.palveluBindingSource.DataMember = "palvelu";
            this.palveluBindingSource.DataSource = this.dataSet1;
            // 
            // palveluTableAdapter
            // 
            this.palveluTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView_Varaus
            // 
            this.dataGridView_Varaus.AutoGenerateColumns = false;
            this.dataGridView_Varaus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Varaus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.varausidDataGridViewTextBoxColumn,
            this.asiakasidDataGridViewTextBoxColumn,
            this.mokkimokkiidDataGridViewTextBoxColumn,
            this.varattupvmDataGridViewTextBoxColumn,
            this.vahvistuspvmDataGridViewTextBoxColumn,
            this.varattualkupvmDataGridViewTextBoxColumn,
            this.varattuloppupvmDataGridViewTextBoxColumn});
            this.dataGridView_Varaus.DataSource = this.varausBindingSource;
            this.dataGridView_Varaus.Location = new System.Drawing.Point(26, 344);
            this.dataGridView_Varaus.Name = "dataGridView_Varaus";
            this.dataGridView_Varaus.Size = new System.Drawing.Size(744, 150);
            this.dataGridView_Varaus.TabIndex = 89;
            // 
            // varausidDataGridViewTextBoxColumn
            // 
            this.varausidDataGridViewTextBoxColumn.DataPropertyName = "varaus_id";
            this.varausidDataGridViewTextBoxColumn.HeaderText = "varaus_id";
            this.varausidDataGridViewTextBoxColumn.Name = "varausidDataGridViewTextBoxColumn";
            // 
            // asiakasidDataGridViewTextBoxColumn
            // 
            this.asiakasidDataGridViewTextBoxColumn.DataPropertyName = "asiakas_id";
            this.asiakasidDataGridViewTextBoxColumn.HeaderText = "asiakas_id";
            this.asiakasidDataGridViewTextBoxColumn.Name = "asiakasidDataGridViewTextBoxColumn";
            // 
            // mokkimokkiidDataGridViewTextBoxColumn
            // 
            this.mokkimokkiidDataGridViewTextBoxColumn.DataPropertyName = "mokki_mokki_id";
            this.mokkimokkiidDataGridViewTextBoxColumn.HeaderText = "mokki_mokki_id";
            this.mokkimokkiidDataGridViewTextBoxColumn.Name = "mokkimokkiidDataGridViewTextBoxColumn";
            // 
            // varattupvmDataGridViewTextBoxColumn
            // 
            this.varattupvmDataGridViewTextBoxColumn.DataPropertyName = "varattu_pvm";
            this.varattupvmDataGridViewTextBoxColumn.HeaderText = "varattu_pvm";
            this.varattupvmDataGridViewTextBoxColumn.Name = "varattupvmDataGridViewTextBoxColumn";
            // 
            // vahvistuspvmDataGridViewTextBoxColumn
            // 
            this.vahvistuspvmDataGridViewTextBoxColumn.DataPropertyName = "vahvistus_pvm";
            this.vahvistuspvmDataGridViewTextBoxColumn.HeaderText = "vahvistus_pvm";
            this.vahvistuspvmDataGridViewTextBoxColumn.Name = "vahvistuspvmDataGridViewTextBoxColumn";
            // 
            // varattualkupvmDataGridViewTextBoxColumn
            // 
            this.varattualkupvmDataGridViewTextBoxColumn.DataPropertyName = "varattu_alkupvm";
            this.varattualkupvmDataGridViewTextBoxColumn.HeaderText = "varattu_alkupvm";
            this.varattualkupvmDataGridViewTextBoxColumn.Name = "varattualkupvmDataGridViewTextBoxColumn";
            // 
            // varattuloppupvmDataGridViewTextBoxColumn
            // 
            this.varattuloppupvmDataGridViewTextBoxColumn.DataPropertyName = "varattu_loppupvm";
            this.varattuloppupvmDataGridViewTextBoxColumn.HeaderText = "varattu_loppupvm";
            this.varattuloppupvmDataGridViewTextBoxColumn.Name = "varattuloppupvmDataGridViewTextBoxColumn";
            // 
            // varausBindingSource
            // 
            this.varausBindingSource.DataMember = "varaus";
            this.varausBindingSource.DataSource = this.dataSet2;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // varausTableAdapter
            // 
            this.varausTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox_VarFindMokki
            // 
            this.comboBox_VarFindMokki.FormattingEnabled = true;
            this.comboBox_VarFindMokki.Location = new System.Drawing.Point(120, 156);
            this.comboBox_VarFindMokki.Name = "comboBox_VarFindMokki";
            this.comboBox_VarFindMokki.Size = new System.Drawing.Size(200, 21);
            this.comboBox_VarFindMokki.TabIndex = 90;
            this.comboBox_VarFindMokki.SelectedIndexChanged += new System.EventHandler(this.comboBox_VarFindMokki_SelectedIndexChanged);
            // 
            // comboBox_VarFindAlue
            // 
            this.comboBox_VarFindAlue.FormattingEnabled = true;
            this.comboBox_VarFindAlue.Location = new System.Drawing.Point(120, 129);
            this.comboBox_VarFindAlue.Name = "comboBox_VarFindAlue";
            this.comboBox_VarFindAlue.Size = new System.Drawing.Size(200, 21);
            this.comboBox_VarFindAlue.TabIndex = 91;
            this.comboBox_VarFindAlue.SelectedIndexChanged += new System.EventHandler(this.comboBox_VarFindAlue_SelectedIndexChanged);
            // 
            // comboBox_VarFindAsiakas
            // 
            this.comboBox_VarFindAsiakas.FormattingEnabled = true;
            this.comboBox_VarFindAsiakas.Location = new System.Drawing.Point(121, 183);
            this.comboBox_VarFindAsiakas.Name = "comboBox_VarFindAsiakas";
            this.comboBox_VarFindAsiakas.Size = new System.Drawing.Size(200, 21);
            this.comboBox_VarFindAsiakas.TabIndex = 92;
            this.comboBox_VarFindAsiakas.SelectedIndexChanged += new System.EventHandler(this.comboBox_VarFindAsiakas_SelectedIndexChanged);
            // 
            // btn_toAddEditDelete
            // 
            this.btn_toAddEditDelete.Location = new System.Drawing.Point(404, 132);
            this.btn_toAddEditDelete.Name = "btn_toAddEditDelete";
            this.btn_toAddEditDelete.Size = new System.Drawing.Size(195, 60);
            this.btn_toAddEditDelete.TabIndex = 93;
            this.btn_toAddEditDelete.Text = "Varausten lisäys, muokkaus ja poisto";
            this.btn_toAddEditDelete.UseVisualStyleBackColor = true;
            this.btn_toAddEditDelete.Click += new System.EventHandler(this.btn_toAddEditDelete_Click);
            // 
            // emptyHakuEhdot
            // 
            this.emptyHakuEhdot.Location = new System.Drawing.Point(202, 272);
            this.emptyHakuEhdot.Name = "emptyHakuEhdot";
            this.emptyHakuEhdot.Size = new System.Drawing.Size(119, 23);
            this.emptyHakuEhdot.TabIndex = 94;
            this.emptyHakuEhdot.Text = "Tyhjennä hakuehdot";
            this.emptyHakuEhdot.UseVisualStyleBackColor = true;
            this.emptyHakuEhdot.Click += new System.EventHandler(this.emptyHakuEhdot_Click);
            // 
            // MajoitusVaraustenHallintaUusi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.emptyHakuEhdot);
            this.Controls.Add(this.btn_toAddEditDelete);
            this.Controls.Add(this.comboBox_VarFindAsiakas);
            this.Controls.Add(this.comboBox_VarFindAlue);
            this.Controls.Add(this.comboBox_VarFindMokki);
            this.Controls.Add(this.dataGridView_Varaus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_EtsiVaraus);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MajoitusVaraustenHallintaUusi";
            this.Text = "MajoitusVaraustenHallintaUusi";
            this.Load += new System.EventHandler(this.MajoitusVaraustenHallintaUusi_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palveluBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Varaus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.varausBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_back2menuVar;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.Button btn_EtsiVaraus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource palveluBindingSource;
        private DataSet1TableAdapters.palveluTableAdapter palveluTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView_Varaus;
        private DataSet2 dataSet2;
        private System.Windows.Forms.BindingSource varausBindingSource;
        private DataSet2TableAdapters.varausTableAdapter varausTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn varausidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn asiakasidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mokkimokkiidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn varattupvmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vahvistuspvmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn varattualkupvmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn varattuloppupvmDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox comboBox_VarFindMokki;
        private System.Windows.Forms.ComboBox comboBox_VarFindAlue;
        private System.Windows.Forms.ComboBox comboBox_VarFindAsiakas;
        private System.Windows.Forms.Button btn_toAddEditDelete;
        private System.Windows.Forms.Button emptyHakuEhdot;
    }
}