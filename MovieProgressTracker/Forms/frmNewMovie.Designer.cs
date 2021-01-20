namespace MovieProgressTracker
{
    partial class frmNewMovie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewMovie));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lstGenres = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGenres = new System.Windows.Forms.TextBox();
            this.txtSeasons = new System.Windows.Forms.TextBox();
            this.txtEpisodes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddSelGenres = new System.Windows.Forms.Button();
            this.btnCreateAndClose = new System.Windows.Forms.Button();
            this.btnGenreHelp = new System.Windows.Forms.Button();
            this.lstCustomSeasons = new System.Windows.Forms.ListBox();
            this.lstCustomEpisodes = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCustomSeason = new System.Windows.Forms.TextBox();
            this.txtCustomEpisode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(71, 6);
            this.txtName.MaxLength = 255;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(472, 20);
            this.txtName.TabIndex = 0;
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(548, 365);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(89, 23);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "&Create Movie";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(15, 365);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lstGenres
            // 
            this.lstGenres.FormattingEnabled = true;
            this.lstGenres.Location = new System.Drawing.Point(610, 6);
            this.lstGenres.Name = "lstGenres";
            this.lstGenres.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstGenres.Size = new System.Drawing.Size(152, 264);
            this.lstGenres.TabIndex = 4;
            this.lstGenres.TabStop = false;
            this.lstGenres.DoubleClick += new System.EventHandler(this.lstGenres_DoubleClick);
            this.lstGenres.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstGenres_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Genres (;)";
            // 
            // txtGenres
            // 
            this.txtGenres.Location = new System.Drawing.Point(71, 29);
            this.txtGenres.MaxLength = 999;
            this.txtGenres.Name = "txtGenres";
            this.txtGenres.Size = new System.Drawing.Size(472, 20);
            this.txtGenres.TabIndex = 1;
            // 
            // txtSeasons
            // 
            this.txtSeasons.Location = new System.Drawing.Point(120, 15);
            this.txtSeasons.MaxLength = 4;
            this.txtSeasons.Name = "txtSeasons";
            this.txtSeasons.Size = new System.Drawing.Size(32, 20);
            this.txtSeasons.TabIndex = 3;
            this.txtSeasons.Text = "0";
            this.txtSeasons.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSeasons_KeyPress);
            // 
            // txtEpisodes
            // 
            this.txtEpisodes.Location = new System.Drawing.Point(120, 41);
            this.txtEpisodes.MaxLength = 4;
            this.txtEpisodes.Name = "txtEpisodes";
            this.txtEpisodes.Size = new System.Drawing.Size(32, 20);
            this.txtEpisodes.TabIndex = 4;
            this.txtEpisodes.Text = "0";
            this.txtEpisodes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEpisodes_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Episodes per season";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Seasons";
            // 
            // txtDirectory
            // 
            this.txtDirectory.Location = new System.Drawing.Point(123, 55);
            this.txtDirectory.MaxLength = 9999;
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(451, 20);
            this.txtDirectory.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Movie Directory";
            // 
            // btnAddSelGenres
            // 
            this.btnAddSelGenres.Location = new System.Drawing.Point(610, 270);
            this.btnAddSelGenres.Name = "btnAddSelGenres";
            this.btnAddSelGenres.Size = new System.Drawing.Size(152, 23);
            this.btnAddSelGenres.TabIndex = 13;
            this.btnAddSelGenres.TabStop = false;
            this.btnAddSelGenres.Text = "Add selected &genres";
            this.btnAddSelGenres.UseVisualStyleBackColor = true;
            this.btnAddSelGenres.Click += new System.EventHandler(this.btnAddSelGenres_Click);
            // 
            // btnCreateAndClose
            // 
            this.btnCreateAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateAndClose.Location = new System.Drawing.Point(643, 365);
            this.btnCreateAndClose.Name = "btnCreateAndClose";
            this.btnCreateAndClose.Size = new System.Drawing.Size(119, 23);
            this.btnCreateAndClose.TabIndex = 6;
            this.btnCreateAndClose.Text = "Create Movie && C&lose";
            this.btnCreateAndClose.UseVisualStyleBackColor = true;
            this.btnCreateAndClose.Click += new System.EventHandler(this.btnCreateAndClose_Click);
            // 
            // btnGenreHelp
            // 
            this.btnGenreHelp.BackgroundImage = global::MovieProgressTracker.Properties.Resources.question1;
            this.btnGenreHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenreHelp.Location = new System.Drawing.Point(548, 27);
            this.btnGenreHelp.Name = "btnGenreHelp";
            this.btnGenreHelp.Size = new System.Drawing.Size(23, 23);
            this.btnGenreHelp.TabIndex = 15;
            this.btnGenreHelp.Text = "?";
            this.btnGenreHelp.UseVisualStyleBackColor = true;
            this.btnGenreHelp.Click += new System.EventHandler(this.btnGenreHelp_Click);
            // 
            // lstCustomSeasons
            // 
            this.lstCustomSeasons.FormattingEnabled = true;
            this.lstCustomSeasons.Location = new System.Drawing.Point(6, 35);
            this.lstCustomSeasons.Name = "lstCustomSeasons";
            this.lstCustomSeasons.Size = new System.Drawing.Size(120, 160);
            this.lstCustomSeasons.TabIndex = 16;
            this.lstCustomSeasons.TabStop = false;
            this.lstCustomSeasons.SelectedIndexChanged += new System.EventHandler(this.lstCustomSeasons_SelectedIndexChanged);
            this.lstCustomSeasons.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstDelete_KeyUp);
            // 
            // lstCustomEpisodes
            // 
            this.lstCustomEpisodes.FormattingEnabled = true;
            this.lstCustomEpisodes.Location = new System.Drawing.Point(132, 35);
            this.lstCustomEpisodes.Name = "lstCustomEpisodes";
            this.lstCustomEpisodes.Size = new System.Drawing.Size(120, 160);
            this.lstCustomEpisodes.TabIndex = 17;
            this.lstCustomEpisodes.TabStop = false;
            this.lstCustomEpisodes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstDelete_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Custom Seasons";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(149, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Custom Episodes";
            // 
            // txtCustomSeason
            // 
            this.txtCustomSeason.Location = new System.Drawing.Point(6, 219);
            this.txtCustomSeason.Name = "txtCustomSeason";
            this.txtCustomSeason.Size = new System.Drawing.Size(120, 20);
            this.txtCustomSeason.TabIndex = 7;
            this.txtCustomSeason.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomSeason_KeyUp);
            // 
            // txtCustomEpisode
            // 
            this.txtCustomEpisode.Location = new System.Drawing.Point(132, 219);
            this.txtCustomEpisode.Name = "txtCustomEpisode";
            this.txtCustomEpisode.Size = new System.Drawing.Size(120, 20);
            this.txtCustomEpisode.TabIndex = 8;
            this.txtCustomEpisode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomEpisode_KeyUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEpisodes);
            this.groupBox1.Controls.Add(this.txtSeasons);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(10, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 73);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Automatic Generation";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lstCustomSeasons);
            this.groupBox2.Controls.Add(this.lstCustomEpisodes);
            this.groupBox2.Controls.Add(this.txtCustomEpisode);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtCustomSeason);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(181, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 266);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Custom";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(138, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "New Episode Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "New Season Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(79, 242);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Press enter to add";
            // 
            // frmNewMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(781, 400);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGenreHelp);
            this.Controls.Add(this.btnCreateAndClose);
            this.Controls.Add(this.btnAddSelGenres);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtGenres);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstGenres);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmNewMovie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create New Movie";
            this.Load += new System.EventHandler(this.frmNewMovie_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lstGenres;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGenres;
        private System.Windows.Forms.TextBox txtSeasons;
        private System.Windows.Forms.TextBox txtEpisodes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddSelGenres;
        private System.Windows.Forms.Button btnCreateAndClose;
        private System.Windows.Forms.Button btnGenreHelp;
        private System.Windows.Forms.ListBox lstCustomSeasons;
        private System.Windows.Forms.ListBox lstCustomEpisodes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCustomSeason;
        private System.Windows.Forms.TextBox txtCustomEpisode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
    }
}