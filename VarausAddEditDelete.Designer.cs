namespace Group9_VillageNewbies
{
    partial class VarausAddEditDelete
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
            this.btn_back2Var = new System.Windows.Forms.Button();
            this.header = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataSet2 = new Group9_VillageNewbies.DataSet2();
            this.varausBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.varausTableAdapter = new Group9_VillageNewbies.DataSet2TableAdapters.varausTableAdapter();
            this.varausidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asiakasidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mokkimokkiidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varattupvmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vahvistuspvmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varattualkupvmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varattuloppupvmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox_VarVarAsiakas = new System.Windows.Forms.ComboBox();
            this.comboBox_VarVarAlue = new System.Windows.Forms.ComboBox();
            this.comboBox_VarVarMokki = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerVarEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerVarStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_LisaaVaraus = new System.Windows.Forms.Button();
            this.btn_EditVaraus = new System.Windows.Forms.Button();
            this.btn_DeleteVaraus = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox_VarValitutPalvelut = new System.Windows.Forms.ListBox();
            this.comboBox_VarVarPalvelut = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_AddPalveluToVaraus = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_deleteVarPalvelu = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.varausBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.btn_back2Var);
            this.panel1.Controls.Add(this.header);
            this.panel1.Location = new System.Drawing.Point(1, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 64);
            this.panel1.TabIndex = 74;
            // 
            // btn_back2Var
            // 
            this.btn_back2Var.Location = new System.Drawing.Point(7, 11);
            this.btn_back2Var.Name = "btn_back2Var";
            this.btn_back2Var.Size = new System.Drawing.Size(75, 23);
            this.btn_back2Var.TabIndex = 74;
            this.btn_back2Var.Text = "<Takaisin";
            this.btn_back2Var.UseVisualStyleBackColor = true;
            this.btn_back2Var.Click += new System.EventHandler(this.btn_back2Var_Click);
            // 
            // header
            // 
            this.header.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.header.AutoSize = true;
            this.header.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header.Location = new System.Drawing.Point(118, 11);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(606, 39);
            this.header.TabIndex = 5;
            this.header.Text = "Varauksien lisäys, muokkaus ja poisto";
            this.header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.varausidDataGridViewTextBoxColumn,
            this.asiakasidDataGridViewTextBoxColumn,
            this.mokkimokkiidDataGridViewTextBoxColumn,
            this.varattupvmDataGridViewTextBoxColumn,
            this.vahvistuspvmDataGridViewTextBoxColumn,
            this.varattualkupvmDataGridViewTextBoxColumn,
            this.varattuloppupvmDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.varausBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(25, 302);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(744, 247);
            this.dataGridView1.TabIndex = 75;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // varausBindingSource
            // 
            this.varausBindingSource.DataMember = "varaus";
            this.varausBindingSource.DataSource = this.dataSet2;
            // 
            // varausTableAdapter
            // 
            this.varausTableAdapter.ClearBeforeFill = true;
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
            // comboBox_VarVarAsiakas
            // 
            this.comboBox_VarVarAsiakas.FormattingEnabled = true;
            this.comboBox_VarVarAsiakas.Location = new System.Drawing.Point(116, 171);
            this.comboBox_VarVarAsiakas.Name = "comboBox_VarVarAsiakas";
            this.comboBox_VarVarAsiakas.Size = new System.Drawing.Size(200, 21);
            this.comboBox_VarVarAsiakas.TabIndex = 103;
            this.comboBox_VarVarAsiakas.SelectedIndexChanged += new System.EventHandler(this.comboBox_VarVarAsiakas_SelectedIndexChanged);
            // 
            // comboBox_VarVarAlue
            // 
            this.comboBox_VarVarAlue.FormattingEnabled = true;
            this.comboBox_VarVarAlue.Location = new System.Drawing.Point(116, 86);
            this.comboBox_VarVarAlue.Name = "comboBox_VarVarAlue";
            this.comboBox_VarVarAlue.Size = new System.Drawing.Size(200, 21);
            this.comboBox_VarVarAlue.TabIndex = 102;
            this.comboBox_VarVarAlue.SelectedIndexChanged += new System.EventHandler(this.comboBox_VarVarAlue_SelectedIndexChanged);
            // 
            // comboBox_VarVarMokki
            // 
            this.comboBox_VarVarMokki.FormattingEnabled = true;
            this.comboBox_VarVarMokki.Location = new System.Drawing.Point(116, 113);
            this.comboBox_VarVarMokki.Name = "comboBox_VarVarMokki";
            this.comboBox_VarVarMokki.Size = new System.Drawing.Size(200, 21);
            this.comboBox_VarVarMokki.TabIndex = 101;
            this.comboBox_VarVarMokki.SelectedIndexChanged += new System.EventHandler(this.comboBox_VarVarMokki_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 100;
            this.label5.Text = "Päättymispäivämäärä:";
            // 
            // dateTimePickerVarEnd
            // 
            this.dateTimePickerVarEnd.Location = new System.Drawing.Point(116, 228);
            this.dateTimePickerVarEnd.Name = "dateTimePickerVarEnd";
            this.dateTimePickerVarEnd.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerVarEnd.TabIndex = 99;
            this.dateTimePickerVarEnd.ValueChanged += new System.EventHandler(this.dateTimePickerVarEnd_ValueChanged);
            // 
            // dateTimePickerVarStart
            // 
            this.dateTimePickerVarStart.Location = new System.Drawing.Point(116, 202);
            this.dateTimePickerVarStart.Name = "dateTimePickerVarStart";
            this.dateTimePickerVarStart.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerVarStart.TabIndex = 98;
            this.dateTimePickerVarStart.ValueChanged += new System.EventHandler(this.dateTimePickerVarStart_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 97;
            this.label4.Text = "Alkamispäivämäärä:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 96;
            this.label3.Text = "Asiakas:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "Alue:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 94;
            this.label1.Text = "Mökki:";
            // 
            // btn_LisaaVaraus
            // 
            this.btn_LisaaVaraus.Location = new System.Drawing.Point(269, 273);
            this.btn_LisaaVaraus.Name = "btn_LisaaVaraus";
            this.btn_LisaaVaraus.Size = new System.Drawing.Size(75, 23);
            this.btn_LisaaVaraus.TabIndex = 93;
            this.btn_LisaaVaraus.Text = "Lisää";
            this.btn_LisaaVaraus.UseVisualStyleBackColor = true;
            this.btn_LisaaVaraus.Click += new System.EventHandler(this.btn_LisaaVaraus_Click);
            // 
            // btn_EditVaraus
            // 
            this.btn_EditVaraus.Location = new System.Drawing.Point(350, 273);
            this.btn_EditVaraus.Name = "btn_EditVaraus";
            this.btn_EditVaraus.Size = new System.Drawing.Size(75, 23);
            this.btn_EditVaraus.TabIndex = 104;
            this.btn_EditVaraus.Text = "Muokkaa";
            this.btn_EditVaraus.UseVisualStyleBackColor = true;
            this.btn_EditVaraus.Click += new System.EventHandler(this.btn_EditVaraus_Click);
            // 
            // btn_DeleteVaraus
            // 
            this.btn_DeleteVaraus.Location = new System.Drawing.Point(431, 273);
            this.btn_DeleteVaraus.Name = "btn_DeleteVaraus";
            this.btn_DeleteVaraus.Size = new System.Drawing.Size(75, 23);
            this.btn_DeleteVaraus.TabIndex = 105;
            this.btn_DeleteVaraus.Text = "Poista";
            this.btn_DeleteVaraus.UseVisualStyleBackColor = true;
            this.btn_DeleteVaraus.Click += new System.EventHandler(this.btn_DeleteVaraus_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 106;
            this.label6.Text = "Palvelut:";
            // 
            // listBox_VarValitutPalvelut
            // 
            this.listBox_VarValitutPalvelut.FormattingEnabled = true;
            this.listBox_VarValitutPalvelut.Location = new System.Drawing.Point(488, 92);
            this.listBox_VarValitutPalvelut.Name = "listBox_VarValitutPalvelut";
            this.listBox_VarValitutPalvelut.Size = new System.Drawing.Size(200, 160);
            this.listBox_VarValitutPalvelut.TabIndex = 113;
            // 
            // comboBox_VarVarPalvelut
            // 
            this.comboBox_VarVarPalvelut.FormattingEnabled = true;
            this.comboBox_VarVarPalvelut.Location = new System.Drawing.Point(116, 140);
            this.comboBox_VarVarPalvelut.Name = "comboBox_VarVarPalvelut";
            this.comboBox_VarVarPalvelut.Size = new System.Drawing.Size(200, 21);
            this.comboBox_VarVarPalvelut.TabIndex = 114;
            this.comboBox_VarVarPalvelut.SelectedIndexChanged += new System.EventHandler(this.comboBox_VarVarPalvelut_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(485, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 115;
            this.label7.Text = "Valitut palvelut:";
            // 
            // btn_AddPalveluToVaraus
            // 
            this.btn_AddPalveluToVaraus.Location = new System.Drawing.Point(322, 140);
            this.btn_AddPalveluToVaraus.Name = "btn_AddPalveluToVaraus";
            this.btn_AddPalveluToVaraus.Size = new System.Drawing.Size(80, 23);
            this.btn_AddPalveluToVaraus.TabIndex = 116;
            this.btn_AddPalveluToVaraus.Text = "Lisää palvelu";
            this.btn_AddPalveluToVaraus.UseVisualStyleBackColor = true;
            this.btn_AddPalveluToVaraus.Click += new System.EventHandler(this.btn_AddPalveluToVaraus_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(150, 278);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 13);
            this.label8.TabIndex = 117;
            this.label8.Text = "Varauksen muutokset:";
            // 
            // btn_deleteVarPalvelu
            // 
            this.btn_deleteVarPalvelu.Location = new System.Drawing.Point(694, 92);
            this.btn_deleteVarPalvelu.Name = "btn_deleteVarPalvelu";
            this.btn_deleteVarPalvelu.Size = new System.Drawing.Size(80, 23);
            this.btn_deleteVarPalvelu.TabIndex = 118;
            this.btn_deleteVarPalvelu.Text = "Poista palvelu";
            this.btn_deleteVarPalvelu.UseVisualStyleBackColor = true;
            this.btn_deleteVarPalvelu.Click += new System.EventHandler(this.btn_deleteVarPalvelu_Click);
            // 
            // VarausAddEditDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.btn_deleteVarPalvelu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_AddPalveluToVaraus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox_VarVarPalvelut);
            this.Controls.Add(this.listBox_VarValitutPalvelut);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_DeleteVaraus);
            this.Controls.Add(this.btn_EditVaraus);
            this.Controls.Add(this.comboBox_VarVarAsiakas);
            this.Controls.Add(this.comboBox_VarVarAlue);
            this.Controls.Add(this.comboBox_VarVarMokki);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePickerVarEnd);
            this.Controls.Add(this.dateTimePickerVarStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_LisaaVaraus);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "VarausAddEditDelete";
            this.Text = "VarausAddEditDelete";
            this.Load += new System.EventHandler(this.VarausAddEditDelete_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.varausBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_back2Var;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.DataGridView dataGridView1;
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
        private System.Windows.Forms.ComboBox comboBox_VarVarAsiakas;
        private System.Windows.Forms.ComboBox comboBox_VarVarAlue;
        private System.Windows.Forms.ComboBox comboBox_VarVarMokki;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerVarEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerVarStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_LisaaVaraus;
        private System.Windows.Forms.Button btn_EditVaraus;
        private System.Windows.Forms.Button btn_DeleteVaraus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox_VarValitutPalvelut;
        private System.Windows.Forms.ComboBox comboBox_VarVarPalvelut;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_AddPalveluToVaraus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_deleteVarPalvelu;
    }
}