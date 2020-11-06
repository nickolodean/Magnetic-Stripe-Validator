namespace MagneticStripeValidation
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.ChkExcludeSpecial = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtBarcode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtDelimeters = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtTrack1Length = new System.Windows.Forms.TextBox();
            this.TxtTrack2Length = new System.Windows.Forms.TextBox();
            this.TxtStatus = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtMagstripeData = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LblFileName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnSelectFile = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.DGView = new System.Windows.Forms.DataGridView();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ChkExcludeSpecial);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.TxtBarcode);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.TxtDelimeters);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.TxtTrack1Length);
            this.panel3.Controls.Add(this.TxtTrack2Length);
            this.panel3.Controls.Add(this.TxtStatus);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.TxtMagstripeData);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.LblFileName);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.BtnSelectFile);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(795, 460);
            this.panel3.TabIndex = 16;
            // 
            // ChkExcludeSpecial
            // 
            this.ChkExcludeSpecial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChkExcludeSpecial.AutoSize = true;
            this.ChkExcludeSpecial.Checked = true;
            this.ChkExcludeSpecial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkExcludeSpecial.Location = new System.Drawing.Point(385, 150);
            this.ChkExcludeSpecial.Name = "ChkExcludeSpecial";
            this.ChkExcludeSpecial.Size = new System.Drawing.Size(204, 24);
            this.ChkExcludeSpecial.TabIndex = 2;
            this.ChkExcludeSpecial.Text = "Exclude Special Characters";
            this.ChkExcludeSpecial.UseVisualStyleBackColor = true;
            this.ChkExcludeSpecial.CheckedChanged += new System.EventHandler(this.ChkExcludeSpecial_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(53, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 20);
            this.label8.TabIndex = 31;
            this.label8.Text = "BARCODE :";
            // 
            // TxtBarcode
            // 
            this.TxtBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBarcode.Location = new System.Drawing.Point(147, 213);
            this.TxtBarcode.Name = "TxtBarcode";
            this.TxtBarcode.Size = new System.Drawing.Size(634, 27);
            this.TxtBarcode.TabIndex = 6;
            this.TxtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBarcode_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(53, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 30;
            this.label7.Text = "Delimeters :";
            // 
            // TxtDelimeters
            // 
            this.TxtDelimeters.Location = new System.Drawing.Point(147, 180);
            this.TxtDelimeters.Name = "TxtDelimeters";
            this.TxtDelimeters.Size = new System.Drawing.Size(198, 27);
            this.TxtDelimeters.TabIndex = 3;
            this.TxtDelimeters.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(581, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Track 2 Length :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(381, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "Track 1 Length :";
            // 
            // TxtTrack1Length
            // 
            this.TxtTrack1Length.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTrack1Length.Location = new System.Drawing.Point(501, 180);
            this.TxtTrack1Length.Name = "TxtTrack1Length";
            this.TxtTrack1Length.Size = new System.Drawing.Size(74, 27);
            this.TxtTrack1Length.TabIndex = 4;
            this.TxtTrack1Length.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtTrack2Length
            // 
            this.TxtTrack2Length.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTrack2Length.Location = new System.Drawing.Point(707, 180);
            this.TxtTrack2Length.Name = "TxtTrack2Length";
            this.TxtTrack2Length.Size = new System.Drawing.Size(74, 27);
            this.TxtTrack2Length.TabIndex = 5;
            this.TxtTrack2Length.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtStatus
            // 
            this.TxtStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtStatus.ForeColor = System.Drawing.Color.Red;
            this.TxtStatus.Location = new System.Drawing.Point(0, 316);
            this.TxtStatus.Name = "TxtStatus";
            this.TxtStatus.ReadOnly = true;
            this.TxtStatus.Size = new System.Drawing.Size(795, 144);
            this.TxtStatus.TabIndex = 8;
            this.TxtStatus.TabStop = false;
            this.TxtStatus.Text = "";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(1, 279);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 45);
            this.panel2.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "STATUS";
            // 
            // TxtMagstripeData
            // 
            this.TxtMagstripeData.Location = new System.Drawing.Point(147, 246);
            this.TxtMagstripeData.Name = "TxtMagstripeData";
            this.TxtMagstripeData.Size = new System.Drawing.Size(634, 27);
            this.TxtMagstripeData.TabIndex = 7;
            this.TxtMagstripeData.UseSystemPasswordChar = true;
            this.TxtMagstripeData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMagstripeData_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(16, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Magstripe Data :";
            // 
            // LblFileName
            // 
            this.LblFileName.AutoSize = true;
            this.LblFileName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFileName.ForeColor = System.Drawing.Color.Black;
            this.LblFileName.Location = new System.Drawing.Point(209, 89);
            this.LblFileName.Name = "LblFileName";
            this.LblFileName.Size = new System.Drawing.Size(83, 25);
            this.LblFileName.TabIndex = 0;
            this.LblFileName.Text = "filename";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(175, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "File Name";
            // 
            // BtnSelectFile
            // 
            this.BtnSelectFile.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSelectFile.Location = new System.Drawing.Point(16, 64);
            this.BtnSelectFile.Name = "BtnSelectFile";
            this.BtnSelectFile.Size = new System.Drawing.Size(125, 78);
            this.BtnSelectFile.TabIndex = 1;
            this.BtnSelectFile.Text = "Select File";
            this.BtnSelectFile.UseVisualStyleBackColor = true;
            this.BtnSelectFile.Click += new System.EventHandler(this.BtnSelectFile_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(795, 58);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Magnetic Stripe Validation";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.DGView);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 496);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(795, 188);
            this.panel4.TabIndex = 17;
            // 
            // DGView
            // 
            this.DGView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DGView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGView.Location = new System.Drawing.Point(0, 0);
            this.DGView.Name = "DGView";
            this.DGView.ReadOnly = true;
            this.DGView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGView.Size = new System.Drawing.Size(795, 188);
            this.DGView.TabIndex = 0;
            // 
            // Worker
            // 
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
            this.Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Worker_ProgressChanged);
            this.Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(795, 684);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dz Card Philippines";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtBarcode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtDelimeters;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtTrack1Length;
        private System.Windows.Forms.TextBox TxtTrack2Length;
        private System.Windows.Forms.RichTextBox TxtStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtMagstripeData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnSelectFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView DGView;
        private System.Windows.Forms.CheckBox ChkExcludeSpecial;
        private System.ComponentModel.BackgroundWorker Worker;
    }
}

