namespace IS.Forms.Team;

public partial class TeamInfo : Form
{
    private readonly int Tid;

    private readonly List<string> JoinCodeRight = new()
    {
        "允许所有人查看",
        "只允许管理员查看",
        "禁止所有人查看"
    };

    private readonly List<string> JoinRight = new()
    {
        "允许所有方式",
        "禁止搜索加入",
        "禁止加入码加入"
    };

    private readonly Services.Team team = new();

    /// <summary>
    ///     测试用函数
    /// </summary>
    public TeamInfo()
    {
        InitializeComponent();
        Tid = 1;
    }

    public TeamInfo(int tid)
    {
        InitializeComponent();
        Tid = tid;
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
    }

    private void TeamInfo_Load(object sender, EventArgs e)
    {
        // 应当先判断用户是否足够的权限来访问团队信息
        // 暂时先不做

        // 获取团队信息
        var teamInfo = team.GetTeamInfo(Tid);
        if (teamInfo is null) return;

        // 更新信息
        TeamNameTextBox.Text = teamInfo[0];
        TeamDescriptionTextBox.Text = teamInfo[1];
        TeamPeopleNumberLabel.Text = teamInfo[2]; // 团队人数
        TeamJoinCodeLabel.Text = teamInfo[3];
        TeamOwnerLabel.Text = teamInfo[5]; // username

        // 复选框数据
        JoinRightComboBox.Text = JoinRight[0];
        JoinCodeRigthComboBox.Text = JoinCodeRight[0];
        // 复选框禁止编辑
        JoinRightComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        JoinCodeRigthComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

        this.TeamNameTextBox.SelectionLength = 0;
    }

    // 更新按钮
    private void UpdateButton_Click(object sender, EventArgs e)
    {
        // 更新数据库内容
        if (team.UpdateTeamInfo(Tid, TeamNameTextBox.Text,
                TeamDescriptionTextBox.Text,
                JoinRight.IndexOf(JoinRightComboBox.Text),
                JoinCodeRight.IndexOf(JoinCodeRigthComboBox.Text)) == "ok")
            MessageBox.Show("更新成功");
        else
            MessageBox.Show("更新失败");
    }
}