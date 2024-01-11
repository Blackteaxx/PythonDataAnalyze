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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            NameTextBox = new TextBox();
            DescriptionTextBox = new TextBox();
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
            QuitButton = new Button();
            UpdateButton = new Button();
            TeamMemberList = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            DataVIewMenu = new ContextMenuStrip(components);
            设置身份ToolStripMenuItem = new ToolStripMenuItem();
            所有者ToolStripMenuItem = new ToolStripMenuItem();
            管理员ToolStripMenuItem = new ToolStripMenuItem();
            成员ToolStripMenuItem = new ToolStripMenuItem();
            查看个人信息ToolStripMenuItem = new ToolStripMenuItem();
            button2 = new Button();
            button4 = new Button();
            button6 = new Button();
            DissolveButton = new Button();
            Tips = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)TeamMemberList).BeginInit();
            DataVIewMenu.SuspendLayout();
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
            // NameTextBox
            // 
            NameTextBox.Location = new Point(130, 75);
            NameTextBox.MaxLength = 20;
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(177, 27);
            NameTextBox.TabIndex = 2;
            NameTextBox.TabStop = false;
            // 
            // DescriptionTextBox
            // 
            DescriptionTextBox.Location = new Point(43, 155);
            DescriptionTextBox.MaxLength = 140;
            DescriptionTextBox.Multiline = true;
            DescriptionTextBox.Name = "DescriptionTextBox";
            DescriptionTextBox.Size = new Size(555, 149);
            DescriptionTextBox.TabIndex = 3;
            DescriptionTextBox.TabStop = false;
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
            label6.Location = new Point(32, 324);
            label6.Name = "label6";
            label6.Size = new Size(92, 27);
            label6.TabIndex = 7;
            label6.Text = "团队人数";
            // 
            // TeamPeopleNumberLabel
            // 
            TeamPeopleNumberLabel.AutoSize = true;
            TeamPeopleNumberLabel.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TeamPeopleNumberLabel.Location = new Point(130, 324);
            TeamPeopleNumberLabel.Name = "TeamPeopleNumberLabel";
            TeamPeopleNumberLabel.Size = new Size(92, 27);
            TeamPeopleNumberLabel.TabIndex = 8;
            TeamPeopleNumberLabel.Text = "团队人数";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(304, 324);
            label8.Name = "label8";
            label8.Size = new Size(92, 27);
            label8.TabIndex = 9;
            label8.Text = "加入限制";
            // 
            // JoinRightComboBox
            // 
            JoinRightComboBox.FormattingEnabled = true;
            JoinRightComboBox.Items.AddRange(new object[] { "允许所有方式", "禁止搜索加入", "禁止加入码加入" });
            JoinRightComboBox.Location = new Point(402, 323);
            JoinRightComboBox.Name = "JoinRightComboBox";
            JoinRightComboBox.Size = new Size(149, 28);
            JoinRightComboBox.TabIndex = 10;
            JoinRightComboBox.TabStop = false;
            JoinRightComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(66, 421);
            button1.Name = "button1";
            button1.Size = new Size(94, 33);
            button1.TabIndex = 1;
            button1.Text = "进入";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // TeamJoinCodeLabel
            // 
            TeamJoinCodeLabel.AutoSize = true;
            TeamJoinCodeLabel.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TeamJoinCodeLabel.Location = new Point(132, 370);
            TeamJoinCodeLabel.Name = "TeamJoinCodeLabel";
            TeamJoinCodeLabel.Size = new Size(72, 27);
            TeamJoinCodeLabel.TabIndex = 13;
            TeamJoinCodeLabel.Text = "加入码";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(43, 370);
            label10.Name = "label10";
            label10.Size = new Size(72, 27);
            label10.TabIndex = 12;
            label10.Text = "加入码";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(284, 370);
            label11.Name = "label11";
            label11.Size = new Size(112, 27);
            label11.TabIndex = 14;
            label11.Text = "加入码权限";
            // 
            // JoinCodeRigthComboBox
            // 
            JoinCodeRigthComboBox.FormattingEnabled = true;
            JoinCodeRigthComboBox.Items.AddRange(new object[] { "允许所有人查看", "只允许管理员查看", "禁止所有人查看" });
            JoinCodeRigthComboBox.Location = new Point(402, 369);
            JoinCodeRigthComboBox.Name = "JoinCodeRigthComboBox";
            JoinCodeRigthComboBox.Size = new Size(149, 28);
            JoinCodeRigthComboBox.TabIndex = 15;
            JoinCodeRigthComboBox.TabStop = false;
            // 
            // QuitButton
            // 
            QuitButton.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            QuitButton.Location = new Point(335, 421);
            QuitButton.Name = "QuitButton";
            QuitButton.Size = new Size(105, 33);
            QuitButton.TabIndex = 18;
            QuitButton.Text = "退出团队";
            QuitButton.UseVisualStyleBackColor = true;
            // 
            // UpdateButton
            // 
            UpdateButton.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            UpdateButton.Location = new Point(198, 421);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(95, 33);
            UpdateButton.TabIndex = 17;
            UpdateButton.Text = "更新";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // TeamMemberList
            // 
            TeamMemberList.AllowUserToAddRows = false;
            TeamMemberList.AllowUserToDeleteRows = false;
            TeamMemberList.AllowUserToResizeColumns = false;
            TeamMemberList.AllowUserToResizeRows = false;
            TeamMemberList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TeamMemberList.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3 });
            TeamMemberList.ContextMenuStrip = DataVIewMenu;
            TeamMemberList.Location = new Point(613, 19);
            TeamMemberList.Name = "TeamMemberList";
            TeamMemberList.RowHeadersVisible = false;
            TeamMemberList.RowHeadersWidth = 51;
            TeamMemberList.RowTemplate.Height = 29;
            TeamMemberList.ScrollBars = ScrollBars.Vertical;
            TeamMemberList.Size = new Size(263, 378);
            TeamMemberList.TabIndex = 19;
            TeamMemberList.CellContentClick += TeamMemberList_CellContentClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "名字";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 180;
            // 
            // Column2
            // 
            Column2.HeaderText = "身份";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 80;
            // 
            // Column3
            // 
            Column3.HeaderText = "uid";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // DataVIewMenu
            // 
            DataVIewMenu.ImageScalingSize = new Size(20, 20);
            DataVIewMenu.Items.AddRange(new ToolStripItem[] { 设置身份ToolStripMenuItem, 查看个人信息ToolStripMenuItem });
            DataVIewMenu.Name = "contextMenuStrip1";
            DataVIewMenu.Size = new Size(169, 52);
            // 
            // 设置身份ToolStripMenuItem
            // 
            设置身份ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 所有者ToolStripMenuItem, 管理员ToolStripMenuItem, 成员ToolStripMenuItem });
            设置身份ToolStripMenuItem.Enabled = false;
            设置身份ToolStripMenuItem.Name = "设置身份ToolStripMenuItem";
            设置身份ToolStripMenuItem.Size = new Size(168, 24);
            设置身份ToolStripMenuItem.Text = "设置身份";
            // 
            // 所有者ToolStripMenuItem
            // 
            所有者ToolStripMenuItem.Name = "所有者ToolStripMenuItem";
            所有者ToolStripMenuItem.Size = new Size(137, 26);
            所有者ToolStripMenuItem.Text = "所有者";
            // 
            // 管理员ToolStripMenuItem
            // 
            管理员ToolStripMenuItem.Name = "管理员ToolStripMenuItem";
            管理员ToolStripMenuItem.Size = new Size(137, 26);
            管理员ToolStripMenuItem.Text = "管理员";
            // 
            // 成员ToolStripMenuItem
            // 
            成员ToolStripMenuItem.Name = "成员ToolStripMenuItem";
            成员ToolStripMenuItem.Size = new Size(137, 26);
            成员ToolStripMenuItem.Text = "成员";
            // 
            // 查看个人信息ToolStripMenuItem
            // 
            查看个人信息ToolStripMenuItem.Name = "查看个人信息ToolStripMenuItem";
            查看个人信息ToolStripMenuItem.Size = new Size(168, 24);
            查看个人信息ToolStripMenuItem.Text = "查看个人信息";
            // 
            // button2
            // 
            button2.Image = Properties.Resources.邀请;
            button2.Location = new Point(613, 421);
            button2.Name = "button2";
            button2.Size = new Size(40, 40);
            button2.TabIndex = 23;
            Tips.SetToolTip(button2, "邀请新成员");
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.Image = Properties.Resources.删除;
            button4.Location = new Point(726, 421);
            button4.Name = "button4";
            button4.Size = new Size(40, 40);
            button4.TabIndex = 24;
            Tips.SetToolTip(button4, "删除所选成员");
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button6
            // 
            button6.Image = Properties.Resources.刷新;
            button6.Location = new Point(836, 419);
            button6.Name = "button6";
            button6.Size = new Size(40, 40);
            button6.TabIndex = 25;
            Tips.SetToolTip(button6, "刷新列表");
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // DissolveButton
            // 
            DissolveButton.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DissolveButton.Location = new Point(472, 421);
            DissolveButton.Name = "DissolveButton";
            DissolveButton.Size = new Size(105, 33);
            DissolveButton.TabIndex = 22;
            DissolveButton.Text = "解散团队";
            DissolveButton.UseVisualStyleBackColor = true;
            DissolveButton.Click += button5_Click;
            // 
            // TeamInfo
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 480);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(DissolveButton);
            Controls.Add(TeamMemberList);
            Controls.Add(UpdateButton);
            Controls.Add(QuitButton);
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
            Controls.Add(DescriptionTextBox);
            Controls.Add(NameTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TeamInfo";
            Text = "团队详情";
            Load += TeamInfo_Load;
            ((System.ComponentModel.ISupportInitialize)TeamMemberList).EndInit();
            DataVIewMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox NameTextBox;
        private TextBox DescriptionTextBox;
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
        private Button QuitButton;
        private Button UpdateButton;
        private DataGridView TeamMemberList;
        private Button button2;
        private Button button4;
        private Button button6;
        private Button DissolveButton;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private ToolTip Tips;
        private ContextMenuStrip DataVIewMenu;
        private ToolStripMenuItem 设置身份ToolStripMenuItem;
        private ToolStripMenuItem 所有者ToolStripMenuItem;
        private ToolStripMenuItem 管理员ToolStripMenuItem;
        private ToolStripMenuItem 成员ToolStripMenuItem;
        private ToolStripMenuItem 查看个人信息ToolStripMenuItem;
    }
}