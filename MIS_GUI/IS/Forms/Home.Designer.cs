namespace IS.Forms
{
    partial class Home
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
            SIderPanel = new Panel();
            label1 = new Label();
            TaskContainer = new Panel();
            CreateTaskButton = new Button();
            TaskButton = new Button();
            UserTaskButton = new Button();
            TeamTaskButton = new Button();
            PersonContainer = new Panel();
            PersonButton = new Button();
            UserInfoUpdateButton = new Button();
            TeamContainer = new Panel();
            UserTeamButton = new Button();
            TeamInviteMemberButton = new Button();
            TeamInfoButton = new Button();
            SearchTeamButton = new Button();
            CreateTeamButton = new Button();
            TeamButton = new Button();
            HeaderPanel = new Panel();
            NextButton = new Button();
            ForwardButton = new Button();
            MainPanel = new Panel();
            TeamTimer = new System.Windows.Forms.Timer(components);
            TaskTimer = new System.Windows.Forms.Timer(components);
            PersonTimer = new System.Windows.Forms.Timer(components);
            SIderPanel.SuspendLayout();
            TaskContainer.SuspendLayout();
            PersonContainer.SuspendLayout();
            TeamContainer.SuspendLayout();
            HeaderPanel.SuspendLayout();
            SuspendLayout();
            // 
            // SIderPanel
            // 
            SIderPanel.BackColor = Color.FromArgb(30, 40, 35);
            SIderPanel.Controls.Add(label1);
            SIderPanel.Controls.Add(TaskContainer);
            SIderPanel.Controls.Add(PersonContainer);
            SIderPanel.Controls.Add(TeamContainer);
            SIderPanel.Dock = DockStyle.Left;
            SIderPanel.Location = new Point(0, 0);
            SIderPanel.Margin = new Padding(4);
            SIderPanel.Name = "SIderPanel";
            SIderPanel.Size = new Size(244, 663);
            SIderPanel.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("思源黑体 CN", 15F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(51, 9);
            label1.Name = "label1";
            label1.Size = new Size(139, 44);
            label1.TabIndex = 0;
            label1.Text = "功能一览";
            // 
            // TaskContainer
            // 
            TaskContainer.Controls.Add(CreateTaskButton);
            TaskContainer.Controls.Add(TaskButton);
            TaskContainer.Controls.Add(UserTaskButton);
            TaskContainer.Controls.Add(TeamTaskButton);
            TaskContainer.Location = new Point(0, 355);
            TaskContainer.MaximumSize = new Size(244, 181);
            TaskContainer.MinimumSize = new Size(244, 59);
            TaskContainer.Name = "TaskContainer";
            TaskContainer.Size = new Size(244, 59);
            TaskContainer.TabIndex = 1;
            // 
            // CreateTaskButton
            // 
            CreateTaskButton.BackColor = SystemColors.AppWorkspace;
            CreateTaskButton.CausesValidation = false;
            CreateTaskButton.Cursor = Cursors.Hand;
            CreateTaskButton.FlatAppearance.BorderColor = Color.White;
            CreateTaskButton.FlatAppearance.BorderSize = 0;
            CreateTaskButton.FlatAppearance.MouseDownBackColor = Color.White;
            CreateTaskButton.FlatAppearance.MouseOverBackColor = Color.White;
            CreateTaskButton.FlatStyle = FlatStyle.Flat;
            CreateTaskButton.Font = new Font("思源黑体 CN", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            CreateTaskButton.ForeColor = Color.White;
            CreateTaskButton.Image = Properties.Resources.正确;
            CreateTaskButton.ImageAlign = ContentAlignment.MiddleLeft;
            CreateTaskButton.Location = new Point(-16, 61);
            CreateTaskButton.Margin = new Padding(4);
            CreateTaskButton.Name = "CreateTaskButton";
            CreateTaskButton.Padding = new Padding(30, 0, 0, 0);
            CreateTaskButton.Size = new Size(272, 41);
            CreateTaskButton.TabIndex = 6;
            CreateTaskButton.Text = "创建任务";
            CreateTaskButton.UseVisualStyleBackColor = false;
            // 
            // TaskButton
            // 
            TaskButton.BackColor = Color.FromArgb(30, 40, 35);
            TaskButton.CausesValidation = false;
            TaskButton.Cursor = Cursors.Hand;
            TaskButton.FlatAppearance.BorderColor = Color.White;
            TaskButton.FlatAppearance.BorderSize = 0;
            TaskButton.FlatAppearance.MouseDownBackColor = Color.White;
            TaskButton.FlatAppearance.MouseOverBackColor = Color.White;
            TaskButton.FlatStyle = FlatStyle.Popup;
            TaskButton.Font = new Font("思源黑体 CN", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            TaskButton.ForeColor = Color.White;
            TaskButton.ImageAlign = ContentAlignment.MiddleLeft;
            TaskButton.Location = new Point(-16, -22);
            TaskButton.Margin = new Padding(4);
            TaskButton.Name = "TaskButton";
            TaskButton.Padding = new Padding(30, 0, 0, 0);
            TaskButton.Size = new Size(272, 93);
            TaskButton.TabIndex = 1;
            TaskButton.Text = "任务";
            TaskButton.UseVisualStyleBackColor = false;
            TaskButton.Click += TaskButton_Click;
            // 
            // UserTaskButton
            // 
            UserTaskButton.BackColor = SystemColors.AppWorkspace;
            UserTaskButton.CausesValidation = false;
            UserTaskButton.Cursor = Cursors.Hand;
            UserTaskButton.FlatAppearance.BorderColor = Color.White;
            UserTaskButton.FlatAppearance.BorderSize = 0;
            UserTaskButton.FlatAppearance.MouseDownBackColor = Color.White;
            UserTaskButton.FlatAppearance.MouseOverBackColor = Color.White;
            UserTaskButton.FlatStyle = FlatStyle.Flat;
            UserTaskButton.Font = new Font("思源黑体 CN", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            UserTaskButton.ForeColor = Color.White;
            UserTaskButton.Image = Properties.Resources.正确;
            UserTaskButton.ImageAlign = ContentAlignment.MiddleLeft;
            UserTaskButton.Location = new Point(-16, 139);
            UserTaskButton.Margin = new Padding(4);
            UserTaskButton.Name = "UserTaskButton";
            UserTaskButton.Padding = new Padding(30, 0, 0, 0);
            UserTaskButton.Size = new Size(272, 41);
            UserTaskButton.TabIndex = 2;
            UserTaskButton.Text = "个人任务";
            UserTaskButton.UseVisualStyleBackColor = false;
            // 
            // TeamTaskButton
            // 
            TeamTaskButton.BackColor = SystemColors.AppWorkspace;
            TeamTaskButton.CausesValidation = false;
            TeamTaskButton.Cursor = Cursors.Hand;
            TeamTaskButton.FlatAppearance.BorderColor = Color.White;
            TeamTaskButton.FlatAppearance.BorderSize = 0;
            TeamTaskButton.FlatAppearance.MouseDownBackColor = Color.White;
            TeamTaskButton.FlatAppearance.MouseOverBackColor = Color.White;
            TeamTaskButton.FlatStyle = FlatStyle.Flat;
            TeamTaskButton.Font = new Font("思源黑体 CN", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            TeamTaskButton.ForeColor = Color.White;
            TeamTaskButton.Image = Properties.Resources.正确;
            TeamTaskButton.ImageAlign = ContentAlignment.MiddleLeft;
            TeamTaskButton.Location = new Point(-16, 101);
            TeamTaskButton.Margin = new Padding(4);
            TeamTaskButton.Name = "TeamTaskButton";
            TeamTaskButton.Padding = new Padding(30, 0, 0, 0);
            TeamTaskButton.Size = new Size(272, 41);
            TeamTaskButton.TabIndex = 2;
            TeamTaskButton.Text = "团队任务";
            TeamTaskButton.UseVisualStyleBackColor = false;
            // 
            // PersonContainer
            // 
            PersonContainer.Controls.Add(PersonButton);
            PersonContainer.Controls.Add(UserInfoUpdateButton);
            PersonContainer.Location = new Point(0, 539);
            PersonContainer.MaximumSize = new Size(244, 117);
            PersonContainer.MinimumSize = new Size(244, 67);
            PersonContainer.Name = "PersonContainer";
            PersonContainer.Size = new Size(244, 67);
            PersonContainer.TabIndex = 2;
            // 
            // PersonButton
            // 
            PersonButton.BackColor = Color.FromArgb(30, 40, 35);
            PersonButton.CausesValidation = false;
            PersonButton.Cursor = Cursors.Hand;
            PersonButton.FlatAppearance.BorderColor = Color.White;
            PersonButton.FlatAppearance.BorderSize = 0;
            PersonButton.FlatAppearance.MouseDownBackColor = Color.White;
            PersonButton.FlatAppearance.MouseOverBackColor = Color.White;
            PersonButton.FlatStyle = FlatStyle.Popup;
            PersonButton.Font = new Font("思源黑体 CN", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            PersonButton.ForeColor = Color.White;
            PersonButton.ImageAlign = ContentAlignment.MiddleLeft;
            PersonButton.Location = new Point(-21, -10);
            PersonButton.Margin = new Padding(4);
            PersonButton.Name = "PersonButton";
            PersonButton.Padding = new Padding(30, 0, 0, 0);
            PersonButton.Size = new Size(272, 93);
            PersonButton.TabIndex = 1;
            PersonButton.Text = "个人";
            PersonButton.UseVisualStyleBackColor = false;
            PersonButton.Click += PersonButton_Click;
            // 
            // UserInfoUpdateButton
            // 
            UserInfoUpdateButton.BackColor = SystemColors.AppWorkspace;
            UserInfoUpdateButton.CausesValidation = false;
            UserInfoUpdateButton.Cursor = Cursors.Hand;
            UserInfoUpdateButton.FlatAppearance.BorderColor = Color.White;
            UserInfoUpdateButton.FlatAppearance.BorderSize = 0;
            UserInfoUpdateButton.FlatAppearance.MouseDownBackColor = Color.White;
            UserInfoUpdateButton.FlatAppearance.MouseOverBackColor = Color.White;
            UserInfoUpdateButton.FlatStyle = FlatStyle.Flat;
            UserInfoUpdateButton.Font = new Font("思源黑体 CN", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            UserInfoUpdateButton.ForeColor = Color.White;
            UserInfoUpdateButton.Image = Properties.Resources.团队40;
            UserInfoUpdateButton.ImageAlign = ContentAlignment.MiddleLeft;
            UserInfoUpdateButton.Location = new Point(-16, 78);
            UserInfoUpdateButton.Margin = new Padding(4);
            UserInfoUpdateButton.Name = "UserInfoUpdateButton";
            UserInfoUpdateButton.Padding = new Padding(30, 0, 0, 0);
            UserInfoUpdateButton.Size = new Size(272, 41);
            UserInfoUpdateButton.TabIndex = 3;
            UserInfoUpdateButton.Text = "修改个人信息";
            UserInfoUpdateButton.UseVisualStyleBackColor = false;
            UserInfoUpdateButton.Click += UserInfoUpdateButton_Click;
            // 
            // TeamContainer
            // 
            TeamContainer.Controls.Add(UserTeamButton);
            TeamContainer.Controls.Add(TeamInviteMemberButton);
            TeamContainer.Controls.Add(TeamInfoButton);
            TeamContainer.Controls.Add(SearchTeamButton);
            TeamContainer.Controls.Add(CreateTeamButton);
            TeamContainer.Controls.Add(TeamButton);
            TeamContainer.Location = new Point(0, 72);
            TeamContainer.MaximumSize = new Size(244, 270);
            TeamContainer.MinimumSize = new Size(244, 62);
            TeamContainer.Name = "TeamContainer";
            TeamContainer.Size = new Size(244, 62);
            TeamContainer.TabIndex = 0;
            // 
            // UserTeamButton
            // 
            UserTeamButton.BackColor = SystemColors.AppWorkspace;
            UserTeamButton.CausesValidation = false;
            UserTeamButton.Cursor = Cursors.Hand;
            UserTeamButton.FlatAppearance.BorderColor = Color.White;
            UserTeamButton.FlatAppearance.BorderSize = 0;
            UserTeamButton.FlatAppearance.MouseDownBackColor = Color.White;
            UserTeamButton.FlatAppearance.MouseOverBackColor = Color.White;
            UserTeamButton.FlatStyle = FlatStyle.Flat;
            UserTeamButton.Font = new Font("思源黑体 CN", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            UserTeamButton.ForeColor = Color.White;
            UserTeamButton.Image = Properties.Resources.团队40;
            UserTeamButton.ImageAlign = ContentAlignment.MiddleLeft;
            UserTeamButton.Location = new Point(-17, 227);
            UserTeamButton.Margin = new Padding(4);
            UserTeamButton.Name = "UserTeamButton";
            UserTeamButton.Padding = new Padding(30, 0, 0, 0);
            UserTeamButton.Size = new Size(272, 41);
            UserTeamButton.TabIndex = 5;
            UserTeamButton.Text = "已有团队";
            UserTeamButton.UseVisualStyleBackColor = false;
            // 
            // TeamInviteMemberButton
            // 
            TeamInviteMemberButton.BackColor = SystemColors.AppWorkspace;
            TeamInviteMemberButton.CausesValidation = false;
            TeamInviteMemberButton.Cursor = Cursors.Hand;
            TeamInviteMemberButton.FlatAppearance.BorderColor = Color.White;
            TeamInviteMemberButton.FlatAppearance.BorderSize = 0;
            TeamInviteMemberButton.FlatAppearance.MouseDownBackColor = Color.White;
            TeamInviteMemberButton.FlatAppearance.MouseOverBackColor = Color.White;
            TeamInviteMemberButton.FlatStyle = FlatStyle.Flat;
            TeamInviteMemberButton.Font = new Font("思源黑体 CN", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            TeamInviteMemberButton.ForeColor = Color.White;
            TeamInviteMemberButton.Image = Properties.Resources.团队40;
            TeamInviteMemberButton.ImageAlign = ContentAlignment.MiddleLeft;
            TeamInviteMemberButton.Location = new Point(-17, 187);
            TeamInviteMemberButton.Margin = new Padding(4);
            TeamInviteMemberButton.Name = "TeamInviteMemberButton";
            TeamInviteMemberButton.Padding = new Padding(30, 0, 0, 0);
            TeamInviteMemberButton.Size = new Size(272, 41);
            TeamInviteMemberButton.TabIndex = 4;
            TeamInviteMemberButton.Text = "邀请成员";
            TeamInviteMemberButton.UseVisualStyleBackColor = false;
            // 
            // TeamInfoButton
            // 
            TeamInfoButton.BackColor = SystemColors.AppWorkspace;
            TeamInfoButton.CausesValidation = false;
            TeamInfoButton.Cursor = Cursors.Hand;
            TeamInfoButton.FlatAppearance.BorderColor = Color.White;
            TeamInfoButton.FlatAppearance.BorderSize = 0;
            TeamInfoButton.FlatAppearance.MouseDownBackColor = Color.White;
            TeamInfoButton.FlatAppearance.MouseOverBackColor = Color.White;
            TeamInfoButton.FlatStyle = FlatStyle.Flat;
            TeamInfoButton.Font = new Font("思源黑体 CN", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            TeamInfoButton.ForeColor = Color.White;
            TeamInfoButton.Image = Properties.Resources.团队40;
            TeamInfoButton.ImageAlign = ContentAlignment.MiddleLeft;
            TeamInfoButton.Location = new Point(-17, 147);
            TeamInfoButton.Margin = new Padding(4);
            TeamInfoButton.Name = "TeamInfoButton";
            TeamInfoButton.Padding = new Padding(30, 0, 0, 0);
            TeamInfoButton.Size = new Size(272, 41);
            TeamInfoButton.TabIndex = 3;
            TeamInfoButton.Text = "团队信息";
            TeamInfoButton.UseVisualStyleBackColor = false;
            // 
            // SearchTeamButton
            // 
            SearchTeamButton.BackColor = SystemColors.AppWorkspace;
            SearchTeamButton.CausesValidation = false;
            SearchTeamButton.Cursor = Cursors.Hand;
            SearchTeamButton.FlatAppearance.BorderColor = Color.White;
            SearchTeamButton.FlatAppearance.BorderSize = 0;
            SearchTeamButton.FlatAppearance.MouseDownBackColor = Color.White;
            SearchTeamButton.FlatAppearance.MouseOverBackColor = Color.White;
            SearchTeamButton.FlatStyle = FlatStyle.Flat;
            SearchTeamButton.Font = new Font("思源黑体 CN", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            SearchTeamButton.ForeColor = Color.White;
            SearchTeamButton.Image = Properties.Resources.团队40;
            SearchTeamButton.ImageAlign = ContentAlignment.MiddleLeft;
            SearchTeamButton.Location = new Point(-16, 107);
            SearchTeamButton.Margin = new Padding(4);
            SearchTeamButton.Name = "SearchTeamButton";
            SearchTeamButton.Padding = new Padding(30, 0, 0, 0);
            SearchTeamButton.Size = new Size(272, 41);
            SearchTeamButton.TabIndex = 2;
            SearchTeamButton.Text = "搜索团队";
            SearchTeamButton.UseVisualStyleBackColor = false;
            // 
            // CreateTeamButton
            // 
            CreateTeamButton.BackColor = SystemColors.AppWorkspace;
            CreateTeamButton.CausesValidation = false;
            CreateTeamButton.Cursor = Cursors.Hand;
            CreateTeamButton.FlatAppearance.BorderColor = Color.White;
            CreateTeamButton.FlatAppearance.BorderSize = 0;
            CreateTeamButton.FlatAppearance.MouseDownBackColor = Color.White;
            CreateTeamButton.FlatAppearance.MouseOverBackColor = Color.White;
            CreateTeamButton.FlatStyle = FlatStyle.Flat;
            CreateTeamButton.Font = new Font("思源黑体 CN", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            CreateTeamButton.ForeColor = Color.White;
            CreateTeamButton.Image = Properties.Resources.团队40;
            CreateTeamButton.ImageAlign = ContentAlignment.MiddleLeft;
            CreateTeamButton.Location = new Point(-16, 66);
            CreateTeamButton.Margin = new Padding(4);
            CreateTeamButton.Name = "CreateTeamButton";
            CreateTeamButton.Padding = new Padding(30, 0, 0, 0);
            CreateTeamButton.Size = new Size(272, 41);
            CreateTeamButton.TabIndex = 1;
            CreateTeamButton.Text = "创建团队";
            CreateTeamButton.UseVisualStyleBackColor = false;
            CreateTeamButton.Click += CreateTeamButton_Click;
            // 
            // TeamButton
            // 
            TeamButton.BackColor = Color.FromArgb(30, 40, 35);
            TeamButton.CausesValidation = false;
            TeamButton.Cursor = Cursors.Hand;
            TeamButton.FlatAppearance.BorderColor = Color.White;
            TeamButton.FlatAppearance.BorderSize = 0;
            TeamButton.FlatAppearance.MouseDownBackColor = Color.White;
            TeamButton.FlatAppearance.MouseOverBackColor = Color.White;
            TeamButton.FlatStyle = FlatStyle.Popup;
            TeamButton.Font = new Font("思源黑体 CN", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            TeamButton.ForeColor = Color.White;
            TeamButton.ImageAlign = ContentAlignment.MiddleLeft;
            TeamButton.Location = new Point(-16, -17);
            TeamButton.Margin = new Padding(4);
            TeamButton.Name = "TeamButton";
            TeamButton.Padding = new Padding(30, 0, 0, 0);
            TeamButton.Size = new Size(272, 93);
            TeamButton.TabIndex = 0;
            TeamButton.Text = "团队";
            TeamButton.UseVisualStyleBackColor = false;
            TeamButton.Click += button1_Click_1;
            // 
            // HeaderPanel
            // 
            HeaderPanel.Controls.Add(NextButton);
            HeaderPanel.Controls.Add(ForwardButton);
            HeaderPanel.Dock = DockStyle.Top;
            HeaderPanel.Location = new Point(244, 0);
            HeaderPanel.Margin = new Padding(4);
            HeaderPanel.Name = "HeaderPanel";
            HeaderPanel.Size = new Size(1100, 48);
            HeaderPanel.TabIndex = 9;
            HeaderPanel.Paint += HeaderPanel_Paint;
            // 
            // NextButton
            // 
            NextButton.Image = Properties.Resources.向右;
            NextButton.Location = new Point(56, 2);
            NextButton.Margin = new Padding(4);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(44, 43);
            NextButton.TabIndex = 3;
            NextButton.UseVisualStyleBackColor = true;
            // 
            // ForwardButton
            // 
            ForwardButton.Image = Properties.Resources.向左;
            ForwardButton.Location = new Point(6, 2);
            ForwardButton.Margin = new Padding(4);
            ForwardButton.Name = "ForwardButton";
            ForwardButton.Size = new Size(44, 43);
            ForwardButton.TabIndex = 2;
            ForwardButton.UseVisualStyleBackColor = true;
            // 
            // MainPanel
            // 
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.ForeColor = Color.Black;
            MainPanel.Location = new Point(244, 48);
            MainPanel.Margin = new Padding(0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1100, 615);
            MainPanel.TabIndex = 10;
            // 
            // TeamTimer
            // 
            TeamTimer.Interval = 10;
            TeamTimer.Tick += TeamTimer_Tick;
            // 
            // TaskTimer
            // 
            TaskTimer.Interval = 10;
            TaskTimer.Tick += TaskTimer_Tick;
            // 
            // PersonTimer
            // 
            PersonTimer.Interval = 10;
            PersonTimer.Tick += PersonTimer_Tick;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1344, 663);
            Controls.Add(MainPanel);
            Controls.Add(HeaderPanel);
            Controls.Add(SIderPanel);
            IsMdiContainer = true;
            Margin = new Padding(4);
            Name = "Home";
            Text = "Home";
            FormClosed += Home_FormClosed;
            Load += Home_Load;
            SIderPanel.ResumeLayout(false);
            SIderPanel.PerformLayout();
            TaskContainer.ResumeLayout(false);
            PersonContainer.ResumeLayout(false);
            TeamContainer.ResumeLayout(false);
            HeaderPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel TaskContainer;
        private Panel SIderPanel;
        private Panel HeaderPanel;
        private Panel MainPanel;
        private Button ForwardButton;
        private Button NextButton;
        private Button TeamButton;
        private Panel TeamContainer;
        private Button PersonButton;
        private Button TaskButton;
        private Panel PersonContainer;
        private Button CreateTeamButton;
        private Button UserTeamButton;
        private Button TeamInviteMemberButton;
        private Button TeamInfoButton;
        private Button SearchTeamButton;
        private Button CreateTaskButton;
        private Button UserTaskButton;
        private Button TeamTaskButton;
        private Button UserInfoUpdateButton;
        private System.Windows.Forms.Timer TeamTimer;
        private System.Windows.Forms.Timer TaskTimer;
        private System.Windows.Forms.Timer PersonTimer;
        private Label label1;
    }
}