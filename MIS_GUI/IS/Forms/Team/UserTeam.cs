namespace IS.Forms.Team;

public partial class UserTeam : Form
{
    private readonly Services.Team team = new();
    private readonly int Uid = 1;

    public UserTeam(int uid)
    {
        InitializeComponent();
        Uid = uid;
    }

    public UserTeam()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
    }

    // 检测滚动条是否出现，根据行数来判断
    private void ScrollBarDetection()
    {
        if (dataGridView1.Rows.Count < 10)
            dataGridView1.Columns[1].Width = dataGridView1.Width - 370;
        else
            dataGridView1.Columns[1].Width = dataGridView1.Width - 390;
    }

    /// <summary>
    /// 加载数据
    /// </summary>
    private void LoadData()
    {

        var data = team.GetTeams(Uid);
        if (data is null)
        {
            ScrollBarDetection();
            return;
        }

        dataGridView1.Rows.Clear();

        // 添加行数据
        foreach (var item in data)
        {
            var index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[0].Value = item[1];
            dataGridView1.Rows[index].Cells[1].Value = item[2];
            dataGridView1.Rows[index].Cells[2].Value = item[3];
            dataGridView1.Rows[index].Cells[6].Value = item[0]; // 隐藏的tid列
            dataGridView1.Rows[index].Cells[7].Value = item[4]; // 隐藏的role列
            var btn = new DataGridViewButtonCell();
            btn.Value = "查看";
            var btn1 = new DataGridViewButtonCell();
            btn1.Value = "进入";
            var btn2 = new DataGridViewButtonCell();
            btn2.Value = "置顶";
            dataGridView1.Rows[index].Cells[3] = btn;
            dataGridView1.Rows[index].Cells[4] = btn1;
            dataGridView1.Rows[index].Cells[5] = btn2;
        }

        // 滚动条检测
        ScrollBarDetection();

        // 取消选择的第一行
        dataGridView1.Rows[0].Selected = false;
    }

    /// <summary>
    /// 根据筛选条件加载数据
    /// </summary>
    private void LoadData(string filter)
    {
        var data = team.GetTeams(Uid);
        if (data is null)
        {
            ScrollBarDetection();
            return;
        }

        dataGridView1.Rows.Clear();

        // 添加行数据
        foreach (var item in data)
        {
            if (item[4] != filter) continue; // 跳过不满足条件的项
            var index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[0].Value = item[1];
            dataGridView1.Rows[index].Cells[1].Value = item[2];
            dataGridView1.Rows[index].Cells[2].Value = item[3];
            dataGridView1.Rows[index].Cells[6].Value = item[0]; // 隐藏的tid列
            dataGridView1.Rows[index].Cells[7].Value = item[4]; // 隐藏的role列
            var btn = new DataGridViewButtonCell();
            btn.Value = "查看";
            var btn1 = new DataGridViewButtonCell();
            btn1.Value = "进入";
            var btn2 = new DataGridViewButtonCell();
            btn2.Value = "置顶";
            dataGridView1.Rows[index].Cells[3] = btn;
            dataGridView1.Rows[index].Cells[4] = btn1;
            dataGridView1.Rows[index].Cells[5] = btn2;
        }

        // 滚动条检测
        ScrollBarDetection();

        // 取消选择的第一行
        dataGridView1.Rows[0].Selected = false;
    }

    private void UserTeam_Load(object sender, EventArgs e)
    {
        // 先添加列
        var columns = new List<string> { "名称", "介绍", "人数", "查看", "进入", "置顶", "tid", "role" };
        foreach (var column in columns) dataGridView1.Columns.Add(column, column);

        dataGridView1.ScrollBars = ScrollBars.Vertical;

        // 设置列宽
        var width = dataGridView1.Width;
        dataGridView1.Columns[0].Width = 120;
        dataGridView1.Columns[1].Width = width - 370 - 20;
        dataGridView1.Columns[2].Width = 50;
        dataGridView1.Columns[3].Width = 50;
        dataGridView1.Columns[4].Width = 50;
        dataGridView1.Columns[5].Width = 100;
        dataGridView1.Columns[6].Width = 0;

        // 设置为只读
        dataGridView1.ReadOnly = true;
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.RowHeadersVisible = false;
        dataGridView1.AllowUserToResizeRows = false;
        dataGridView1.AllowUserToResizeColumns = false;

        // 加载数据
        LoadData();

        // 设置初始筛选条件---无
        this.radioButton4.Checked = true;
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // 判断是否点击到了表格
        //点击button按钮事件
        if (dataGridView1.Columns[e.ColumnIndex].Name == "查看")
        {
            var f = this.Parent.Parent as Home; // parent是panel，因此这里要Parent.Parent
            // 传入tid和用户身份
            var t = new TeamInfo(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value),
                Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[7].Value) ?? "");
            var teamName = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value) ?? "";
            f.AddHeaderLabel(teamName, t);
            f.SetMainPanel(t);
        }
    }

    private void button4_Click(object sender, EventArgs e)
    {
        new CreateTeam().ShowDialog();
        this.LoadData();
    }

    /// <summary>
    /// 退出登录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button7_Click(object sender, EventArgs e)
    {
        new Login().Show();
        this.Close();
    }

    /// <summary>
    /// 重新加载
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button6_Click(object sender, EventArgs e)
    {
        this.LoadData();
    }

    /// <summary>
    /// 筛选按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button5_Click(object sender, EventArgs e)
    {
        string filter = "无";
        // 先获取筛选条件
        foreach (Control ctr in groupBox1.Controls)
        {
            if (ctr is RadioButton rb && rb.Checked)
            {
                filter = ctr.Text;
            }
        }

        dataGridView1.Rows.Clear();

        switch (filter)
        {
            case "无":
                LoadData();
                break;
            case "我为创建者":
                LoadData("Owner");
                break;
            case "我为管理员":
                LoadData("Admin");
                break;
            case "我为成员":
                LoadData("Member");
                break;
        }
    }

    /// <summary>
    /// 批量删除或者退出所选
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button3_Click(object sender, EventArgs e)
    {
        var selectedCellCount =
        dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
        if (selectedCellCount == 0)
        {
            MessageBox.Show("请选择要删除的团队!");
            return;
        }

        var sb = new System.Text.StringBuilder("你已选择以下团队:\n");
        var tids = new List<int>();

        for (int i = 0; i < selectedCellCount; i++)
        {
            var row = dataGridView1.SelectedCells[i].RowIndex;
            sb.Append(dataGridView1.Rows[row].Cells[0].Value);
            tids.Add(Convert.ToInt32(dataGridView1.Rows[row].Cells[6].Value));
            sb.Append(Environment.NewLine);
        }

        sb.Append("共" + selectedCellCount.ToString() + "个团队\n");
        sb.Append("提示：如果你退出了你所创建的团队，则该团队会被删除！");
        var r = MessageBox.Show(sb.ToString(), "你确定删除所选团队吗？", MessageBoxButtons.OKCancel);
        if (r == DialogResult.OK)
        {
            foreach (var tid in tids)
            {
                team.QuitTeam(tid, Main.uid);
            }
            LoadData();
            MessageBox.Show("操作完成");
        }
    }

    private void UserTeam_FormClosed(object sender, FormClosedEventArgs e)
    {
        Application.Exit();
    }

    /// <summary>
    /// 创建团队
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CreateTeamButton_Click(object sender, EventArgs e)
    {
        var f = this.Parent.Parent as Home;
        var t = new CreateTeam();
        f.AddHeaderLabel("创建团队", t);
        f.SetMainPanel(t);
    }

    private void SearchTeamButton_Click(object sender, EventArgs e)
    {
        var f = this.Parent.Parent as Home;
        var t = new SearchTeam();
        f.AddHeaderLabel("搜索团队", t);
        f.SetMainPanel(t);
    }
}