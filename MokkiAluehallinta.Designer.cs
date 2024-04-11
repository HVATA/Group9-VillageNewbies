namespace Group9_VillageNewbies
    {
    partial class MokkiAluehallinta
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.header = new System.Windows.Forms.Label();
            this.btnClearAlue = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnDeleteAlue = new System.Windows.Forms.Button();
            this.btnChangeAlue = new System.Windows.Forms.Button();
            this.btnAddAlue = new System.Windows.Forms.Button();
            this.textBoxAlue = new System.Windows.Forms.TextBox();
            this.listBoxAlue = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBoxMokID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBoxMokHinta = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBoxMokOsoite = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtBoxMokKuvaus = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBoxMokVarust = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtBoxMokMaara = new System.Windows.Forms.TextBox();
            this.btnClearMokki = new System.Windows.Forms.Button();
            this.btnDeleteMokki = new System.Windows.Forms.Button();
            this.btnChangeMokki = new System.Windows.Forms.Button();
            this.btnAddMokki = new System.Windows.Forms.Button();
            this.listBoxMokki = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPalveluihin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxAlue = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxMokPostinro = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxMokNimi = new System.Windows.Forms.TextBox();
            this.btn_back2menuALMOK = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.btn_back2menuALMOK);
            this.panel1.Controls.Add(this.header);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 64);
            this.panel1.TabIndex = 11;
            // 
            // header
            // 
            this.header.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.header.AutoSize = true;
            this.header.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header.Location = new System.Drawing.Point(184, 7);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(446, 39);
            this.header.TabIndex = 5;
            this.header.Text = "Alueiden ja mökkien hallinta";
            this.header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClearAlue
            // 
            this.btnClearAlue.Location = new System.Drawing.Point(14, 211);
            this.btnClearAlue.Name = "btnClearAlue";
            this.btnClearAlue.Size = new System.Drawing.Size(75, 23);
            this.btnClearAlue.TabIndex = 43;
            this.btnClearAlue.Text = "Tyhjennä";
            this.btnClearAlue.UseVisualStyleBackColor = true;
            this.btnClearAlue.Click += new System.EventHandler(this.btnClearAlue_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Alue :";
            // 
            // BtnDeleteAlue
            // 
            this.BtnDeleteAlue.Location = new System.Drawing.Point(257, 211);
            this.BtnDeleteAlue.Name = "BtnDeleteAlue";
            this.BtnDeleteAlue.Size = new System.Drawing.Size(75, 23);
            this.BtnDeleteAlue.TabIndex = 35;
            this.BtnDeleteAlue.Text = "Poista";
            this.BtnDeleteAlue.UseVisualStyleBackColor = true;
            this.BtnDeleteAlue.Click += new System.EventHandler(this.BtnDeleteAlue_Click);
            // 
            // btnChangeAlue
            // 
            this.btnChangeAlue.Location = new System.Drawing.Point(176, 211);
            this.btnChangeAlue.Name = "btnChangeAlue";
            this.btnChangeAlue.Size = new System.Drawing.Size(75, 23);
            this.btnChangeAlue.TabIndex = 34;
            this.btnChangeAlue.Text = "Muokkaa";
            this.btnChangeAlue.UseVisualStyleBackColor = true;
            this.btnChangeAlue.Click += new System.EventHandler(this.btnChangeAlue_Click);
            // 
            // btnAddAlue
            // 
            this.btnAddAlue.Location = new System.Drawing.Point(95, 211);
            this.btnAddAlue.Name = "btnAddAlue";
            this.btnAddAlue.Size = new System.Drawing.Size(75, 23);
            this.btnAddAlue.TabIndex = 33;
            this.btnAddAlue.Text = "Lisää";
            this.btnAddAlue.UseVisualStyleBackColor = true;
            this.btnAddAlue.Click += new System.EventHandler(this.btnAddAlue_Click);
            // 
            // textBoxAlue
            // 
            this.textBoxAlue.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAlue.Location = new System.Drawing.Point(114, 131);
            this.textBoxAlue.Name = "textBoxAlue";
            this.textBoxAlue.Size = new System.Drawing.Size(196, 21);
            this.textBoxAlue.TabIndex = 27;
            // 
            // listBoxAlue
            // 
            this.listBoxAlue.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAlue.FormattingEnabled = true;
            this.listBoxAlue.Location = new System.Drawing.Point(14, 277);
            this.listBoxAlue.Name = "listBoxAlue";
            this.listBoxAlue.Size = new System.Drawing.Size(156, 290);
            this.listBoxAlue.TabIndex = 26;
            this.listBoxAlue.SelectedIndexChanged += new System.EventHandler(this.listBoxAlue_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(503, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(196, 25);
            this.label8.TabIndex = 45;
            this.label8.Text = "Mökkien hallinta";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(449, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "Alue :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(425, 193);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 49;
            this.label10.Text = "MokkiID :";
            // 
            // txtBoxMokID
            // 
            this.txtBoxMokID.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMokID.Location = new System.Drawing.Point(503, 190);
            this.txtBoxMokID.Name = "txtBoxMokID";
            this.txtBoxMokID.ReadOnly = true;
            this.txtBoxMokID.Size = new System.Drawing.Size(196, 21);
            this.txtBoxMokID.TabIndex = 48;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(449, 247);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 53;
            this.label11.Text = "Hinta :";
            // 
            // txtBoxMokHinta
            // 
            this.txtBoxMokHinta.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMokHinta.Location = new System.Drawing.Point(503, 244);
            this.txtBoxMokHinta.Name = "txtBoxMokHinta";
            this.txtBoxMokHinta.Size = new System.Drawing.Size(196, 21);
            this.txtBoxMokHinta.TabIndex = 52;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(409, 220);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 51;
            this.label12.Text = "Katuosoite :";
            // 
            // txtBoxMokOsoite
            // 
            this.txtBoxMokOsoite.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMokOsoite.Location = new System.Drawing.Point(503, 217);
            this.txtBoxMokOsoite.Name = "txtBoxMokOsoite";
            this.txtBoxMokOsoite.Size = new System.Drawing.Size(196, 21);
            this.txtBoxMokOsoite.TabIndex = 50;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(435, 413);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 59;
            this.label13.Text = "Kuvaus :";
            // 
            // txtBoxMokKuvaus
            // 
            this.txtBoxMokKuvaus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMokKuvaus.Location = new System.Drawing.Point(503, 410);
            this.txtBoxMokKuvaus.Multiline = true;
            this.txtBoxMokKuvaus.Name = "txtBoxMokKuvaus";
            this.txtBoxMokKuvaus.Size = new System.Drawing.Size(196, 79);
            this.txtBoxMokKuvaus.TabIndex = 58;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(420, 328);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 13);
            this.label14.TabIndex = 57;
            this.label14.Text = "Varustelu :";
            // 
            // txtBoxMokVarust
            // 
            this.txtBoxMokVarust.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMokVarust.Location = new System.Drawing.Point(503, 325);
            this.txtBoxMokVarust.Multiline = true;
            this.txtBoxMokVarust.Name = "txtBoxMokVarust";
            this.txtBoxMokVarust.Size = new System.Drawing.Size(196, 79);
            this.txtBoxMokVarust.TabIndex = 56;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(392, 274);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 13);
            this.label15.TabIndex = 55;
            this.label15.Text = "Henkilömäärä :";
            // 
            // txtBoxMokMaara
            // 
            this.txtBoxMokMaara.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMokMaara.Location = new System.Drawing.Point(503, 271);
            this.txtBoxMokMaara.Name = "txtBoxMokMaara";
            this.txtBoxMokMaara.Size = new System.Drawing.Size(196, 21);
            this.txtBoxMokMaara.TabIndex = 54;
            // 
            // btnClearMokki
            // 
            this.btnClearMokki.Location = new System.Drawing.Point(713, 129);
            this.btnClearMokki.Name = "btnClearMokki";
            this.btnClearMokki.Size = new System.Drawing.Size(75, 23);
            this.btnClearMokki.TabIndex = 63;
            this.btnClearMokki.Text = "Tyhjennä";
            this.btnClearMokki.UseVisualStyleBackColor = true;
            this.btnClearMokki.Click += new System.EventHandler(this.btnClearMokki_Click);
            // 
            // btnDeleteMokki
            // 
            this.btnDeleteMokki.Location = new System.Drawing.Point(713, 212);
            this.btnDeleteMokki.Name = "btnDeleteMokki";
            this.btnDeleteMokki.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteMokki.TabIndex = 62;
            this.btnDeleteMokki.Text = "Poista";
            this.btnDeleteMokki.UseVisualStyleBackColor = true;
            this.btnDeleteMokki.Click += new System.EventHandler(this.btnDeleteMokki_Click);
            // 
            // btnChangeMokki
            // 
            this.btnChangeMokki.Location = new System.Drawing.Point(713, 185);
            this.btnChangeMokki.Name = "btnChangeMokki";
            this.btnChangeMokki.Size = new System.Drawing.Size(75, 23);
            this.btnChangeMokki.TabIndex = 61;
            this.btnChangeMokki.Text = "Muokkaa";
            this.btnChangeMokki.UseVisualStyleBackColor = true;
            this.btnChangeMokki.Click += new System.EventHandler(this.btnChangeMokki_Click);
            // 
            // btnAddMokki
            // 
            this.btnAddMokki.Location = new System.Drawing.Point(713, 158);
            this.btnAddMokki.Name = "btnAddMokki";
            this.btnAddMokki.Size = new System.Drawing.Size(75, 23);
            this.btnAddMokki.TabIndex = 60;
            this.btnAddMokki.Text = "Lisää";
            this.btnAddMokki.UseVisualStyleBackColor = true;
            this.btnAddMokki.Click += new System.EventHandler(this.btnAddMokki_Click);
            // 
            // listBoxMokki
            // 
            this.listBoxMokki.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxMokki.FormattingEnabled = true;
            this.listBoxMokki.Location = new System.Drawing.Point(176, 277);
            this.listBoxMokki.Name = "listBoxMokki";
            this.listBoxMokki.Size = new System.Drawing.Size(156, 290);
            this.listBoxMokki.TabIndex = 64;
            this.listBoxMokki.SelectedIndexChanged += new System.EventHandler(this.listBoxMokki_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(173, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 65;
            this.label3.Text = "Mökit :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 66;
            this.label4.Text = "Alueet :";
            // 
            // btnPalveluihin
            // 
            this.btnPalveluihin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPalveluihin.BackColor = System.Drawing.Color.Teal;
            this.btnPalveluihin.Location = new System.Drawing.Point(501, 495);
            this.btnPalveluihin.Name = "btnPalveluihin";
            this.btnPalveluihin.Size = new System.Drawing.Size(196, 72);
            this.btnPalveluihin.TabIndex = 67;
            this.btnPalveluihin.Text = "Palveluiden hallinta";
            this.btnPalveluihin.UseVisualStyleBackColor = false;
            this.btnPalveluihin.Click += new System.EventHandler(this.btnPalveluihin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(61, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 25);
            this.label1.TabIndex = 36;
            this.label1.Text = "Alueiden hallinta";
            // 
            // comboBoxAlue
            // 
            this.comboBoxAlue.FormattingEnabled = true;
            this.comboBoxAlue.Location = new System.Drawing.Point(503, 132);
            this.comboBoxAlue.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxAlue.Name = "comboBoxAlue";
            this.comboBoxAlue.Size = new System.Drawing.Size(196, 21);
            this.comboBoxAlue.TabIndex = 68;
            this.comboBoxAlue.SelectedIndexChanged += new System.EventHandler(this.comboBoxAlue_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(428, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 70;
            this.label5.Text = "Postinro :";
            // 
            // txtBoxMokPostinro
            // 
            this.txtBoxMokPostinro.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMokPostinro.Location = new System.Drawing.Point(503, 298);
            this.txtBoxMokPostinro.Name = "txtBoxMokPostinro";
            this.txtBoxMokPostinro.Size = new System.Drawing.Size(196, 21);
            this.txtBoxMokPostinro.TabIndex = 69;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(449, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 72;
            this.label6.Text = "Nimi :";
            // 
            // txtBoxMokNimi
            // 
            this.txtBoxMokNimi.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMokNimi.Location = new System.Drawing.Point(503, 163);
            this.txtBoxMokNimi.Name = "txtBoxMokNimi";
            this.txtBoxMokNimi.Size = new System.Drawing.Size(196, 21);
            this.txtBoxMokNimi.TabIndex = 71;
            // 
            // btn_back2menuALMOK
            // 
            this.btn_back2menuALMOK.Location = new System.Drawing.Point(11, 7);
            this.btn_back2menuALMOK.Name = "btn_back2menuALMOK";
            this.btn_back2menuALMOK.Size = new System.Drawing.Size(75, 23);
            this.btn_back2menuALMOK.TabIndex = 6;
            this.btn_back2menuALMOK.Text = "<Takaisin";
            this.btn_back2menuALMOK.UseVisualStyleBackColor = true;
            this.btn_back2menuALMOK.Click += new System.EventHandler(this.btn_back2menuALMOK_Click);
            // 
            // MokkiAluehallinta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(796, 573);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBoxMokNimi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBoxMokPostinro);
            this.Controls.Add(this.comboBoxAlue);
            this.Controls.Add(this.btnPalveluihin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxMokki);
            this.Controls.Add(this.btnClearMokki);
            this.Controls.Add(this.btnDeleteMokki);
            this.Controls.Add(this.btnChangeMokki);
            this.Controls.Add(this.btnAddMokki);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtBoxMokKuvaus);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtBoxMokVarust);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtBoxMokMaara);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtBoxMokHinta);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtBoxMokOsoite);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtBoxMokID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnClearAlue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnDeleteAlue);
            this.Controls.Add(this.btnChangeAlue);
            this.Controls.Add(this.btnAddAlue);
            this.Controls.Add(this.textBoxAlue);
            this.Controls.Add(this.listBoxAlue);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MokkiAluehallinta";
            this.Text = "Aluehallinta";
            this.Load += new System.EventHandler(this.MokkiAluehallinta_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.Button btnClearAlue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnDeleteAlue;
        private System.Windows.Forms.Button btnChangeAlue;
        private System.Windows.Forms.Button btnAddAlue;
        private System.Windows.Forms.TextBox textBoxAlue;
        private System.Windows.Forms.ListBox listBoxAlue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBoxMokID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBoxMokHinta;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBoxMokOsoite;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtBoxMokKuvaus;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBoxMokVarust;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtBoxMokMaara;
        private System.Windows.Forms.Button btnClearMokki;
        private System.Windows.Forms.Button btnDeleteMokki;
        private System.Windows.Forms.Button btnChangeMokki;
        private System.Windows.Forms.Button btnAddMokki;
        private System.Windows.Forms.ListBox listBoxMokki;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPalveluihin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxAlue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxMokPostinro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxMokNimi;
        private System.Windows.Forms.Button btn_back2menuALMOK;
    }
    }