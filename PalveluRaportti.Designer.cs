namespace Group9_VillageNewbies
    {
    partial class PalveluRaportti
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
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.palveluBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Group9_VillageNewbies.DataSet1();
            this.PalveluVarausAlkuPvm = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.AlueComboBox = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.palveluTableAdapter = new Group9_VillageNewbies.DataSet1TableAdapters.palveluTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.palveluBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView1
            // 
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Location = new System.Drawing.Point(12, 195);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.Size = new System.Drawing.Size(776, 305);
            this.DataGridView1.TabIndex = 0;
            // 
            // palveluBindingSource
            // 
            this.palveluBindingSource.DataMember = "palvelu";
            this.palveluBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PalveluVarausAlkuPvm
            // 
            this.PalveluVarausAlkuPvm.Location = new System.Drawing.Point(94, 166);
            this.PalveluVarausAlkuPvm.Name = "PalveluVarausAlkuPvm";
            this.PalveluVarausAlkuPvm.Size = new System.Drawing.Size(200, 20);
            this.PalveluVarausAlkuPvm.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(426, 166);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 2;
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(713, 12);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(75, 23);
            this.ExitBtn.TabIndex = 3;
            this.ExitBtn.Text = "Takaisin";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // AlueComboBox
            // 
            this.AlueComboBox.FormattingEnabled = true;
            this.AlueComboBox.Location = new System.Drawing.Point(645, 165);
            this.AlueComboBox.Name = "AlueComboBox";
            this.AlueComboBox.Size = new System.Drawing.Size(121, 21);
            this.AlueComboBox.TabIndex = 4;
            this.AlueComboBox.SelectedIndexChanged += new System.EventHandler(this.AlueComboBox_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBox1.Location = new System.Drawing.Point(320, 163);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Päättyen : ";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBox2.Location = new System.Drawing.Point(12, 163);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(76, 23);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "Alkaen : ";
            // 
            // palveluTableAdapter
            // 
            this.palveluTableAdapter.ClearBeforeFill = true;
            // 
            // PalveluRaportti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 512);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.AlueComboBox);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.PalveluVarausAlkuPvm);
            this.Controls.Add(this.DataGridView1);
            this.Name = "PalveluRaportti";
            this.Text = "PalveluRaportti";
            this.Load += new System.EventHandler(this.PalveluRaportti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.palveluBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.DateTimePicker PalveluVarausAlkuPvm;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.ComboBox AlueComboBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private DataSet1 dataSet1;
        
        private DataSet1TableAdapters.palveluTableAdapter palveluTableAdapter;
        }
    }