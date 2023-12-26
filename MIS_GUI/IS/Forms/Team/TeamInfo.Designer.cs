namespace IS.Forms.Team
{
    partial class TeamInfo
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
            label1 = new Label();
            label2 = new Label();
            TeamNameTextBox = new TextBox();
            TeamDescriptionTextBox = new TextBox();
            label3 = new Label();
            TeamOwnerLabel = new Label();
            label5 = new Label();
            label6 = new Label();
            TeamPeopleNumberLabel = new Label();
            label8 = new Label();
            JoinRightComboBox = new ComboBox();
            button1 = new Button();
            TeamJoinCodeLabel = new Label();
            label10 = new Label();
            label11 = new Label();
            JoinCodeRigthComboBox = new ComboBox();
            CloseButton = new Button();
            button3 = new Button();
            UpdateButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(32, 75);
            label1.Name = "label1";
            label1.Size = new Size(92, 27);
            label1.TabIndex = 0;
            label1.Text = "团队名称";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(32, 125);
            label2.Name = "label2";
            label2.Size = new Size(92, 27);
            label2.TabIndex = 1;
            label2.Text = "团队描述";
            // 
            // TeamNameTextBox
            // 
            TeamNameTextBox.Location = new Point(130, 75);
            TeamNameTextBox.MaxLength = 20;
            TeamNameTextBox.Name = "TeamNameTextBox";
            TeamNameTextBox.Size = new Size(177, 27);
            TeamNameTextBox.TabIndex = 2;
            TeamNameTextBox.TabStop = false;
            // 
            // TeamDescriptionTextBox
            // 
            TeamDescriptionTextBox.Location = new Point(43, 166);
            TeamDescriptionTextBox.MaxLength = 140;
            TeamDescriptionTextBox.Multiline = true;
            TeamDescriptionTextBox.Name = "TeamDescriptionTextBox";
            TeamDescriptionTextBox.Size = new Size(555, 89);
            TeamDescriptionTextBox.TabIndex = 3;
            TeamDescriptionTextBox.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(324, 75);
            label3.Name = "label3";
            label3.Size = new Size(72, 27);
            label3.TabIndex = 4;
            label3.Text = "创建者";
            // 
            // TeamOwnerLabel
            // 
            TeamOwnerLabel.AutoSize = true;
            TeamOwnerLabel.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            TeamOwnerLabel.Location = new Point(402, 75);
            TeamOwnerLabel.Name = "TeamOwnerLabel";
            TeamOwnerLabel.Size = new Size(92, 27);
            TeamOwnerLabel.TabIndex = 5;
            TeamOwnerLabel.Text = "未知用户";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(221, 19);
            label5.Name = "label5";
            label5.Size = new Size(204, 35);
            label5.TabIndex = 6;
            label5.Text = "团队信息详情页";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(32, 275);
            label6.Name = "label6";
            label6.Size = new Size(92, 27);
            label6.TabIndex = 7;
            label6.Text = "团队人数";
            // 
            // TeamPeopleNumberLabel
            // 
            TeamPeopleNumberLabel.AutoSize = true;
            TeamPeopleNumberLabel.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TeamPeopleNumberLabel.Location = new Point(130, 275);
            TeamPeopleNumberLabel.Name = "TeamPeopleNumberLabel";
            TeamPeopleNumberLabel.Size = new Size(92, 27);
            TeamPeopleNumberLabel.TabIndex = 8;
            TeamPeopleNumberLabel.Text = "团队人数";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(304, 275);
            label8.Name = "label8";
            label8.Size = new Size(92, 27);
            label8.TabIndex = 9;
            label8.Text = "加入限制";
            // 
            // JoinRightComboBox
            // 
            JoinRightComboBox.FormattingEnabled = true;
            JoinRightComboBox.Items.AddRange(new object[] { "允许所有方式", "禁止搜索加入", "禁止加入码加入" });
            JoinRightComboBox.Location = new Point(402, 274);
            JoinRightComboBox.Name = "JoinRightComboBox";
            JoinRightComboBox.Size = new Size(149, 28);
            JoinRightComboBox.TabIndex = 10;
            JoinRightComboBox.TabStop = false;
            JoinRightComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(81, 372);
            button1.Name = "button1";
            button1.Size = new Size(94, 33);
            button1.TabIndex = 11;
            button1.Text = "进入";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // TeamJoinCodeLabel
            // 
            TeamJoinCodeLabel.AutoSize = true;
            TeamJoinCodeLabel.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TeamJoinCodeLabel.Location = new Point(132, 321);
            TeamJoinCodeLabel.Name = "TeamJoinCodeLabel";
            TeamJoinCodeLabel.Size = new Size(72, 27);
            TeamJoinCodeLabel.TabIndex = 13;
            TeamJoinCodeLabel.Text = "加入码";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(43, 321);
            label10.Name = "label10";
            label10.Size = new Size(72, 27);
            label10.TabIndex = 12;
            label10.Text = "加入码";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(284, 321);
            label11.Name = "label11";
            label11.Size = new Size(112, 27);
            label11.TabIndex = 14;
            label11.Text = "加入码权限";
            // 
            // JoinCodeRigthComboBox
            // 
            JoinCodeRigthComboBox.FormattingEnabled = true;
            JoinCodeRigthComboBox.Items.AddRange(new object[] { "允许所有人查看", "只允许管理员查看", "禁止所有人查看" });
            JoinCodeRigthComboBox.Location = new Point(402, 320);
            JoinCodeRigthComboBox.Name = "JoinCodeRigthComboBox";
            JoinCodeRigthComboBox.Size = new Size(149, 28);
            JoinCodeRigthComboBox.TabIndex = 15;
            JoinCodeRigthComboBox.TabStop = false;
            // 
            // CloseButton
            // 
            CloseButton.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CloseButton.Location = new Point(213, 372);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(94, 33);
            CloseButton.TabIndex = 16;
            CloseButton.Text = "关闭";
            CloseButton.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(476, 372);
            button3.Name = "button3";
            button3.Size = new Size(105, 33);
            button3.TabIndex = 18;
            button3.Text = "退出团队";
            button3.UseVisualStyleBackColor = true;
            // 
            // UpdateButton
            // 
            UpdateButton.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            UpdateButton.Location = new Point(347, 372);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(95, 33);
            UpdateButton.TabIndex = 17;
            UpdateButton.Text = "更新";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // TeamInfo
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 429);
            Controls.Add(UpdateButton);
            Controls.Add(button3);
            Controls.Add(CloseButton);
            Controls.Add(JoinCodeRigthComboBox);
            Controls.Add(label11);
            Controls.Add(TeamJoinCodeLabel);
            Controls.Add(label10);
            Controls.Add(button1);
            Controls.Add(JoinRightComboBox);
            Controls.Add(label8);
            Controls.Add(TeamPeopleNumberLabel);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(TeamOwnerLabel);
            Controls.Add(label3);
            Controls.Add(TeamDescriptionTextBox);
            Controls.Add(TeamNameTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TeamInfo";
            Text = "团队详情";
            Load += TeamInfo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox TeamNameTextBox;
        private TextBox TeamDescriptionTextBox;
        private Label label3;
        private Label TeamOwnerLabel;
        private Label label5;
        private Label label6;
        private Label TeamPeopleNumberLabel;
        private Label label8;
        private ComboBox JoinRightComboBox;
        private Button button1;
        private Label TeamJoinCodeLabel;
        private Label label10;
        private Label label11;
        private ComboBox JoinCodeRigthComboBox;
        private Button CloseButton;
        private Button button3;
        private Button UpdateButton;
    }
}