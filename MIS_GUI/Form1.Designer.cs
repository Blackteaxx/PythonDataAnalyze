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
            this.btnSortByTime = new System.Windows.Forms.Button();
            this.btnSortBySize = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.backtomain = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.txtTeamNumber = new System.Windows.Forms.TextBox();
            this.txtPersonalNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSortByTime
            // 
            this.btnSortByTime.Location = new System.Drawing.Point(496, 82);
            this.btnSortByTime.Name = "btnSortByTime";
            this.btnSortByTime.Size = new System.Drawing.Size(112, 34);
            this.btnSortByTime.TabIndex = 0;
            this.btnSortByTime.Text = "按时间排序";
            this.btnSortByTime.UseVisualStyleBackColor = true;
            this.btnSortByTime.Click += new System.EventHandler(this.btnSortByTime_Click);
            // 
            // btnSortBySize
            // 
            this.btnSortBySize.Location = new System.Drawing.Point(625, 82);
            this.btnSortBySize.Name = "btnSortBySize";
            this.btnSortBySize.Size = new System.Drawing.Size(112, 34);
            this.btnSortBySize.TabIndex = 1;
            this.btnSortBySize.Text = "按大小排序";
            this.btnSortBySize.UseVisualStyleBackColor = true;
            this.btnSortBySize.Click += new System.EventHandler(this.btnSortBySize_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 122);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 32;
            this.dataGridView1.Size = new System.Drawing.Size(852, 225);
            this.dataGridView1.TabIndex = 2;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(456, 368);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(112, 34);
            this.btnUpload.TabIndex = 3;
            this.btnUpload.Text = "上传";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(609, 368);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(112, 34);
            this.btnDownload.TabIndex = 4;
            this.btnDownload.Text = "下载";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // backtomain
            // 
            this.backtomain.Location = new System.Drawing.Point(752, 368);
            this.backtomain.Name = "backtomain";
            this.backtomain.Size = new System.Drawing.Size(112, 34);
            this.backtomain.TabIndex = 5;
            this.backtomain.Text = "返回";
            this.backtomain.UseVisualStyleBackColor = true;
            this.backtomain.Click += new System.EventHandler(this.backtomain_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(754, 82);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(112, 34);
            this.btnReload.TabIndex = 6;
            this.btnReload.Text = "加载文件";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // txtTeamNumber
            // 
            this.txtTeamNumber.Location = new System.Drawing.Point(698, 12);
            this.txtTeamNumber.Name = "txtTeamNumber";
            this.txtTeamNumber.Size = new System.Drawing.Size(150, 30);
            this.txtTeamNumber.TabIndex = 7;
            // 
            // txtPersonalNumber
            // 
            this.txtPersonalNumber.Location = new System.Drawing.Point(698, 46);
            this.txtPersonalNumber.Name = "txtPersonalNumber";
            this.txtPersonalNumber.Size = new System.Drawing.Size(150, 30);
            this.txtPersonalNumber.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(625, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "团队号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(625, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "个人号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(50, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 36);
            this.label3.TabIndex = 11;
            this.label3.Text = "文件上传与下载";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 424);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPersonalNumber);
            this.Controls.Add(this.txtTeamNumber);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.backtomain);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSortBySize);
            this.Controls.Add(this.btnSortByTime);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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