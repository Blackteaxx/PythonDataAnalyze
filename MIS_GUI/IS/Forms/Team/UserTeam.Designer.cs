﻿namespace IS.Forms.Team
{
    partial class UserTeam
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
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            groupBox1 = new GroupBox();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            button3 = new Button();
            button5 = new Button();
            button6 = new Button();
            CreateTeamButton = new Button();
            SearchTeamButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(15, 15);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(869, 342);
            dataGridView1.TabIndex = 10;
            dataGridView1.TabStop = false;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(15, 366);
            label1.Name = "label1";
            label1.Size = new Size(97, 27);
            label1.TabIndex = 2;
            label1.Text = "搜索团队:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(113, 366);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(374, 27);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(490, 364);
            button1.Name = "button1";
            button1.Size = new Size(80, 30);
            button1.TabIndex = 2;
            button1.Text = "搜索";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton4);
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(15, 399);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(730, 75);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "搜索选项";
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(337, 29);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(45, 24);
            radioButton4.TabIndex = 100;
            radioButton4.Text = "无";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(241, 29);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(90, 24);
            radioButton3.TabIndex = 2;
            radioButton3.Text = "我为成员";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(130, 29);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(105, 24);
            radioButton2.TabIndex = 1;
            radioButton2.Text = "我为管理员";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(19, 29);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(105, 24);
            radioButton1.TabIndex = 0;
            radioButton1.Text = "我为创建者";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(751, 366);
            button3.Name = "button3";
            button3.Size = new Size(130, 30);
            button3.TabIndex = 6;
            button3.Text = "批量删除/退出";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.Location = new Point(665, 366);
            button5.Name = "button5";
            button5.Size = new Size(80, 30);
            button5.TabIndex = 3;
            button5.Text = "筛选";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(579, 366);
            button6.Name = "button6";
            button6.Size = new Size(80, 30);
            button6.TabIndex = 4;
            button6.Text = "刷新";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // CreateTeamButton
            // 
            CreateTeamButton.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CreateTeamButton.Location = new Point(751, 399);
            CreateTeamButton.Name = "CreateTeamButton";
            CreateTeamButton.Size = new Size(130, 35);
            CreateTeamButton.TabIndex = 21;
            CreateTeamButton.Text = "创建团队";
            CreateTeamButton.UseVisualStyleBackColor = true;
            CreateTeamButton.Click += CreateTeamButton_Click;
            // 
            // SearchTeamButton
            // 
            SearchTeamButton.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SearchTeamButton.Location = new Point(751, 439);
            SearchTeamButton.Name = "SearchTeamButton";
            SearchTeamButton.Size = new Size(130, 35);
            SearchTeamButton.TabIndex = 22;
            SearchTeamButton.Text = "搜索团队";
            SearchTeamButton.UseVisualStyleBackColor = true;
            SearchTeamButton.Click += SearchTeamButton_Click;
            // 
            // UserTeam
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 480);
            ControlBox = false;
            Controls.Add(SearchTeamButton);
            Controls.Add(CreateTeamButton);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button3);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserTeam";
            Text = "UserTeam";
            FormClosed += UserTeam_FormClosed;
            Load += UserTeam_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private GroupBox groupBox1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button button3;
        private Button button5;
        private Button button6;
        private RadioButton radioButton4;
        private Button CreateTeamButton;
        private Button SearchTeamButton;
    }
}