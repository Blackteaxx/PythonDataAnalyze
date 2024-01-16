namespace WinFormsApp3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSortByTime = new Button();
            btnSortBySize = new Button();
            dataGridView1 = new DataGridView();
            btnUpload = new Button();
            btnDownload = new Button();
            backtomain = new Button();
            btnReload = new Button();
            txtTeamNumber = new TextBox();
            txtPersonalNumber = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnSortByTime
            // 
            btnSortByTime.Location = new Point(406, 68);
            btnSortByTime.Margin = new Padding(2, 2, 2, 2);
            btnSortByTime.Name = "btnSortByTime";
            btnSortByTime.Size = new Size(92, 28);
            btnSortByTime.TabIndex = 0;
            btnSortByTime.Text = "按时间排序";
            btnSortByTime.UseVisualStyleBackColor = true;
            btnSortByTime.Click += btnSortByTime_Click;
            // 
            // btnSortBySize
            // 
            btnSortBySize.Location = new Point(511, 68);
            btnSortBySize.Margin = new Padding(2, 2, 2, 2);
            btnSortBySize.Name = "btnSortBySize";
            btnSortBySize.Size = new Size(92, 28);
            btnSortBySize.TabIndex = 1;
            btnSortBySize.Text = "按大小排序";
            btnSortBySize.UseVisualStyleBackColor = true;
            btnSortBySize.Click += btnSortBySize_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(10, 102);
            dataGridView1.Margin = new Padding(2, 2, 2, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 32;
            dataGridView1.Size = new Size(697, 188);
            dataGridView1.TabIndex = 2;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(373, 307);
            btnUpload.Margin = new Padding(2, 2, 2, 2);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(92, 28);
            btnUpload.TabIndex = 3;
            btnUpload.Text = "上传";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnDownload
            // 
            btnDownload.Location = new Point(498, 307);
            btnDownload.Margin = new Padding(2, 2, 2, 2);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(92, 28);
            btnDownload.TabIndex = 4;
            btnDownload.Text = "下载";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // backtomain
            // 
            backtomain.Location = new Point(615, 307);
            backtomain.Margin = new Padding(2, 2, 2, 2);
            backtomain.Name = "backtomain";
            backtomain.Size = new Size(92, 28);
            backtomain.TabIndex = 5;
            backtomain.Text = "返回";
            backtomain.UseVisualStyleBackColor = true;
            backtomain.Click += backtomain_Click;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(617, 68);
            btnReload.Margin = new Padding(2, 2, 2, 2);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(92, 28);
            btnReload.TabIndex = 6;
            btnReload.Text = "加载文件";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // txtTeamNumber
            // 
            txtTeamNumber.Location = new Point(571, 10);
            txtTeamNumber.Margin = new Padding(2, 2, 2, 2);
            txtTeamNumber.Name = "txtTeamNumber";
            txtTeamNumber.Size = new Size(123, 27);
            txtTeamNumber.TabIndex = 7;
            // 
            // txtPersonalNumber
            // 
            txtPersonalNumber.Location = new Point(571, 38);
            txtPersonalNumber.Margin = new Padding(2, 2, 2, 2);
            txtPersonalNumber.Name = "txtPersonalNumber";
            txtPersonalNumber.Size = new Size(123, 27);
            txtPersonalNumber.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(511, 12);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 9;
            label1.Text = "团队号";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(511, 38);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 10;
            label2.Text = "个人号";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(41, 33);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(182, 31);
            label3.TabIndex = 11;
            label3.Text = "文件上传与下载";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 480);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPersonalNumber);
            Controls.Add(txtTeamNumber);
            Controls.Add(btnReload);
            Controls.Add(backtomain);
            Controls.Add(btnDownload);
            Controls.Add(btnUpload);
            Controls.Add(dataGridView1);
            Controls.Add(btnSortBySize);
            Controls.Add(btnSortByTime);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSortByTime;
        private Button btnSortBySize;
        private DataGridView dataGridView1;
        private Button btnUpload;
        private Button btnDownload;
        private Button backtomain;
        private Button btnReload;
        private TextBox txtTeamNumber;
        private TextBox txtPersonalNumber;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}