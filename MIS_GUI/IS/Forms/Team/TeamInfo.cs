﻿using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace IS.Forms.Team;

public partial class TeamInfo : Form
{
    private readonly int Tid;
    private readonly string Role;
    private readonly Dictionary<string, string> RoleName = new()
    {
        {"Member", "成员"},
        {"Admin", "管理员"},
        {"Owner", "创建者"}
    };
    private List<List<string>> TeamMembers = new List<List<string>>();

    private readonly Services.Team team = new();

    /// <summary>
    ///     测试用函数
    /// </summary>
    public TeamInfo()
    {
        InitializeComponent();
        Tid = 1;
        Role = "Member";
    }

    public TeamInfo(int tid, string role)
    {
        InitializeComponent();
        Tid = tid;
        Role = role;
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e)
    {
    }

    private void TeamInfo_Load(object sender, EventArgs e)
    {
        // 获取团队信息
        var teamInfo = team.GetTeamInfo(Tid);

        // 应当先判断用户是否足够的权限来访问团队信息
        if (Role == "Member")
        {
            // 普通用户禁止对团队信息进行操作
            NameTextBox.Enabled = false;
            DescriptionTextBox.Enabled = false;
            JoinRightComboBox.Enabled = false;
            JoinCodeRigthComboBox.Enabled = false;
            UpdateButton.Enabled = false;
            DissolveButton.Enabled = false;
        }

        // 更新团队信息
        NameTextBox.Text = teamInfo.name;
        DescriptionTextBox.Text = teamInfo.description;
        TeamPeopleNumberLabel.Text = teamInfo.peoplenumber.ToString(); // 团队人数
        TeamJoinCodeLabel.Text = teamInfo.joinCode;
        TeamOwnerLabel.Text = teamInfo.username; // username

        // 复选框数据
        JoinRightComboBox.Text = Main.JoinRight[teamInfo.joinRight];
        JoinCodeRigthComboBox.Text = Main.JoinCodeRight[teamInfo.joinCodeRight];
        // 复选框禁止编辑
        JoinRightComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        JoinCodeRigthComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

        // 取消初始的默认选中
        this.NameTextBox.SelectionLength = 0;

        // 显示团队成员信息
        SetTeamMembersList();

        // 为按钮设置提示

    }

    /// <summary>
    /// 更新团队成员信息
    /// </summary>
    private void SetTeamMembersList()
    {
        var members = team.GetTeamMembersInfo(Tid);
        foreach (var member in members)
        {
            var index = TeamMemberList.Rows.Add();
            TeamMemberList.Rows[index].Cells[0].Value = member.name;
            TeamMemberList.Rows[index].Cells[1].Value = RoleName[member.role];
            TeamMemberList.Rows[index].Cells[2].Value = member.uid;
        }
    }

    // 更新按钮
    private void UpdateButton_Click(object sender, EventArgs e)
    {
        // 更新数据库内容
        if (team.UpdateTeamInfo(Tid, NameTextBox.Text,
                DescriptionTextBox.Text,
                Main.JoinRight.IndexOf(JoinRightComboBox.Text),
                Main.JoinCodeRight.IndexOf(JoinCodeRigthComboBox.Text)) == "ok")
            MessageBox.Show("更新成功");
        else
            MessageBox.Show("更新失败");
    }

    private void button5_Click(object sender, EventArgs e)
    {
        var r = MessageBox.Show("是否确定解散该团队", "提示", MessageBoxButtons.OKCancel);
        if (r == DialogResult.OK)
        {

            MessageBox.Show("解散成功");
        }
    }

    private void TeamMemberList_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
}