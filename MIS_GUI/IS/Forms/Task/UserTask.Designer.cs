namespace IS.Forms.Task
{
    partial class UserTask
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
            groupBox1 = new GroupBox();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            button5 = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            button6 = new Button();
            comboBox1 = new ComboBox();
            button2 = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(button5);
            groupBox1.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(7, 371);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(866, 54);
            groupBox1.TabIndex = 28;
            groupBox1.TabStop = false;
            groupBox1.Text = "搜索选项";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(165, 21);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(75, 24);
            radioButton3.TabIndex = 2;
            radioButton3.Text = "未完成";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(84, 21);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(75, 24);
            radioButton2.TabIndex = 1;
            radioButton2.Text = "已完成";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(18, 21);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(60, 24);
            radioButton1.TabIndex = 0;
            radioButton1.Text = "全部";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(246, 18);
            button5.Name = "button5";
            button5.Size = new Size(80, 30);
            button5.TabIndex = 24;
            button5.Text = "筛选";
            button5.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(482, 336);
            button1.Name = "button1";
            button1.Size = new Size(80, 30);
            button1.TabIndex = 22;
            button1.Text = "搜索";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(206, 338);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(273, 27);
            textBox1.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(4, 337);
            label1.Name = "label1";
            label1.Size = new Size(52, 27);
            label1.TabIndex = 23;
            label1.Text = "搜索";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(869, 325);
            dataGridView1.TabIndex = 27;
            dataGridView1.TabStop = false;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // button6
            // 
            button6.Location = new Point(571, 334);
            button6.Name = "button6";
            button6.Size = new Size(80, 30);
            button6.TabIndex = 25;
            button6.Text = "刷新";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "任务名", "团队名" });
            comboBox1.Location = new Point(62, 337);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(138, 28);
            comboBox1.TabIndex = 29;
            // 
            // button2
            // 
            button2.Location = new Point(657, 335);
            button2.Name = "button2";
            button2.Size = new Size(80, 30);
            button2.TabIndex = 30;
            button2.Text = "创建任务";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // UserTask
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 433);
            Controls.Add(button2);
            Controls.Add(comboBox1);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button6);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserTask";
            Text = "TaskInfo";
            Load += TaskInfo_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button button5;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private DataGridView dataGridView1;
        private Button button6;
        private ComboBox comboBox1;
        private Button button2;
    }
}