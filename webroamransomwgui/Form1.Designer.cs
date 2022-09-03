namespace webroamransomwgui
{
    partial class Form1// : System.Windows.Forms.Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ClExclude = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ClFolderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClBrowse = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ClSubFolders = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ClExeFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClBrowse2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clSign = new System.Windows.Forms.DataGridViewImageColumn();
            this.ClSigned = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Exclude = new System.Windows.Forms.TabPage();
            this.Rule = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.ClAdminOnly = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Enabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Exclude.SuspendLayout();
            this.Rule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClExclude,
            this.ClFolderName,
            this.ClBrowse,
            this.ClSubFolders,
            this.ClExeFile,
            this.ClBrowse2,
            this.clSign,
            this.ClSigned});
            this.dataGridView1.Location = new System.Drawing.Point(31, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(905, 385);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseUp);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // ClExclude
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.ClExclude.DefaultCellStyle = dataGridViewCellStyle13;
            this.ClExclude.FillWeight = 160F;
            this.ClExclude.HeaderText = "Exclude State";
            this.ClExclude.Name = "ClExclude";
            this.ClExclude.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ClExclude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ClExclude.Width = 160;
            // 
            // ClFolderName
            // 
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.White;
            this.ClFolderName.DefaultCellStyle = dataGridViewCellStyle14;
            this.ClFolderName.FillWeight = 240F;
            this.ClFolderName.HeaderText = "Folder Name";
            this.ClFolderName.Name = "ClFolderName";
            this.ClFolderName.Width = 240;
            // 
            // ClBrowse
            // 
            this.ClBrowse.HeaderText = "";
            this.ClBrowse.Name = "ClBrowse";
            this.ClBrowse.Text = "...";
            this.ClBrowse.UseColumnTextForButtonValue = true;
            this.ClBrowse.Width = 30;
            // 
            // ClSubFolders
            // 
            this.ClSubFolders.FillWeight = 60F;
            this.ClSubFolders.HeaderText = "Include Subfolders";
            this.ClSubFolders.Name = "ClSubFolders";
            this.ClSubFolders.Width = 60;
            // 
            // ClExeFile
            // 
            this.ClExeFile.FillWeight = 240F;
            this.ClExeFile.HeaderText = "Application";
            this.ClExeFile.Name = "ClExeFile";
            this.ClExeFile.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ClExeFile.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ClExeFile.Width = 240;
            // 
            // ClBrowse2
            // 
            this.ClBrowse2.HeaderText = "";
            this.ClBrowse2.Name = "ClBrowse2";
            this.ClBrowse2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ClBrowse2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ClBrowse2.Text = "...";
            this.ClBrowse2.UseColumnTextForButtonValue = true;
            this.ClBrowse2.Width = 30;
            // 
            // clSign
            // 
            this.clSign.HeaderText = "IsSigned?";
            this.clSign.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.clSign.Name = "clSign";
            this.clSign.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clSign.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ClSigned
            // 
            this.ClSigned.FillWeight = 65F;
            this.ClSigned.HeaderText = "Allow Signed Apps";
            this.ClSigned.Name = "ClSigned";
            this.ClSigned.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ClSigned.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ClSigned.Visible = false;
            this.ClSigned.Width = 65;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Edit Exclude rules";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Exclude);
            this.tabControl1.Controls.Add(this.Rule);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(-2, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1007, 414);
            this.tabControl1.TabIndex = 3;
            // 
            // Exclude
            // 
            this.Exclude.BackColor = System.Drawing.SystemColors.Control;
            this.Exclude.Controls.Add(this.label1);
            this.Exclude.Controls.Add(this.dataGridView1);
            this.Exclude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exclude.Location = new System.Drawing.Point(4, 22);
            this.Exclude.Name = "Exclude";
            this.Exclude.Padding = new System.Windows.Forms.Padding(3);
            this.Exclude.Size = new System.Drawing.Size(999, 388);
            this.Exclude.TabIndex = 0;
            this.Exclude.Text = "Excludes";
            // 
            // Rule
            // 
            this.Rule.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Rule.Controls.Add(this.label2);
            this.Rule.Controls.Add(this.dataGridView2);
            this.Rule.Location = new System.Drawing.Point(4, 22);
            this.Rule.Name = "Rule";
            this.Rule.Padding = new System.Windows.Forms.Padding(3);
            this.Rule.Size = new System.Drawing.Size(999, 388);
            this.Rule.TabIndex = 1;
            this.Rule.Text = "Rules";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Edit assignment rules";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewButtonColumn1,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewButtonColumn2,
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewImageColumn1,
            this.ClAdminOnly,
            this.Enabled,
            this.clDelete});
            this.dataGridView2.Location = new System.Drawing.Point(0, 66);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(993, 407);
            this.dataGridView2.TabIndex = 3;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_RowEnter);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(404, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 33);
            this.button2.TabIndex = 4;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button1.Location = new System.Drawing.Point(302, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 33);
            this.button1.TabIndex = 5;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(97, 420);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 52);
            this.panel1.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 210F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Folder Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 210;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "...";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 30;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.FillWeight = 60F;
            this.dataGridViewCheckBoxColumn1.HeaderText = "Include Subfolders";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 210F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Application";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 210;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.HeaderText = "";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewButtonColumn2.Text = "...";
            this.dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn2.Width = 30;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.FillWeight = 65F;
            this.dataGridViewCheckBoxColumn2.HeaderText = "Allow Signed Apps";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn2.Width = 65;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "IsSigned";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // ClAdminOnly
            // 
            this.ClAdminOnly.HeaderText = "Admin Only";
            this.ClAdminOnly.Name = "ClAdminOnly";
            // 
            // Enabled
            // 
            this.Enabled.FalseValue = "";
            this.Enabled.HeaderText = "Enable";
            this.Enabled.Name = "Enabled";
            this.Enabled.ReadOnly = true;
            this.Enabled.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Enabled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Enabled.ToolTipText = "Enable/Disable";
            this.Enabled.TrueValue = "";
            // 
            // clDelete
            // 
            this.clDelete.FillWeight = 45F;
            this.clDelete.HeaderText = "Delete";
            this.clDelete.Name = "clDelete";
            this.clDelete.Text = "-";
            this.clDelete.Width = 45;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(998, 477);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Webroam Ransomeware Protection";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Exclude.ResumeLayout(false);
            this.Exclude.PerformLayout();
            this.Rule.ResumeLayout(false);
            this.Rule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Exclude;
        private System.Windows.Forms.TabPage Rule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewComboBoxColumn ClExclude;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClFolderName;
        private System.Windows.Forms.DataGridViewButtonColumn ClBrowse;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ClSubFolders;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClExeFile;
        private System.Windows.Forms.DataGridViewButtonColumn ClBrowse2;
        private System.Windows.Forms.DataGridViewImageColumn clSign;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ClSigned;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ClAdminOnly;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Enabled;
        private System.Windows.Forms.DataGridViewButtonColumn clDelete;
    }
}

