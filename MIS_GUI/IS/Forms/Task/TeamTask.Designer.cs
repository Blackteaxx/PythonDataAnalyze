namespace IS.Forms.Task
{
    partial class TeamTask
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
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            label1 = new Label();
            SearchTextBox = new TextBox();
            SearchButton = new Button();
            FilterGroupBox = new GroupBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            CreateTaskButton = new Button();
            FlushButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            FilterGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column6, Column4, Column5 });
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.Size = new Size(876, 346);
            dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            Column1.HeaderText = "名字";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 150;
            // 
            // Column2
            // 
            Column2.HeaderText = "描述";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 370;
            // 
            // Column3
            // 
            Column3.HeaderText = "主管者";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 150;
            // 
            // Column6
            // 
            Column6.HeaderText = "状态";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.Width = 80;
            // 
            // Column4
            // 
            Column4.HeaderText = "查看";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 125;
            // 
            // Column5
            // 
            Column5.HeaderText = "taskid";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 366);
            label1.Name = "label1";
            label1.Size = new Size(52, 27);
            label1.TabIndex = 1;
            label1.Text = "搜索";
            // 
            // SearchTextBox
            // 
            SearchTextBox.Location = new Point(70, 366);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(504, 27);
            SearchTextBox.TabIndex = 2;
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(580, 364);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(104, 29);
            SearchButton.TabIndex = 3;
            SearchButton.Text = "确认";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // FilterGroupBox
            // 
            FilterGroupBox.Controls.Add(checkBox3);
            FilterGroupBox.Controls.Add(checkBox2);
            FilterGroupBox.Controls.Add(checkBox1);
            FilterGroupBox.Location = new Point(12, 396);
            FilterGroupBox.Name = "FilterGroupBox";
            FilterGroupBox.Size = new Size(876, 72);
            FilterGroupBox.TabIndex = 4;
            FilterGroupBox.TabStop = false;
            FilterGroupBox.Text = "筛选条件";
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(730, 26);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(76, 24);
            checkBox3.TabIndex = 2;
            checkBox3.Text = "未完成";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(390, 26);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(76, 24);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "已完成";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(41, 26);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(91, 24);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "我参与的";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // CreateTaskButton
            // 
            CreateTaskButton.Location = new Point(690, 365);
            CreateTaskButton.Name = "CreateTaskButton";
            CreateTaskButton.Size = new Size(94, 29);
            CreateTaskButton.TabIndex = 5;
            CreateTaskButton.Text = "创建任务";
            CreateTaskButton.UseVisualStyleBackColor = true;
            // 
            // FlushButton
            // 
            FlushButton.Location = new Point(794, 364);
            FlushButton.Name = "FlushButton";
            FlushButton.Size = new Size(94, 29);
            FlushButton.TabIndex = 6;
            FlushButton.Text = "刷新";
            FlushButton.UseVisualStyleBackColor = true;
            FlushButton.Click += FlushButton_Click;
            // 
            // TeamTask
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 480);
            Controls.Add(FlushButton);
            Controls.Add(CreateTaskButton);
            Controls.Add(FilterGroupBox);
            Controls.Add(SearchButton);
            Controls.Add(SearchTextBox);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TeamTask";
            Text = "TeamTask";
            Load += TeamTask_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            FilterGroupBox.ResumeLayout(false);
            FilterGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private TextBox SearchTextBox;
        private Button SearchButton;
        private GroupBox FilterGroupBox;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Button CreateTaskButton;
        private Button FlushButton;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
    }
}