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

    /// <summary>
    /// 加载数据
    /// </summary>
    private void LoadData()
    {
        var data = team.GetTeams(Uid);
        if (data is null) return;

        // 添加行数据
        foreach (var item in data)
        {
            var index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[0].Value = item[1];
            dataGridView1.Rows[index].Cells[1].Value = item[2];
            dataGridView1.Rows[index].Cells[2].Value = item[3];
            dataGridView1.Rows[index].Cells[6].Value = item[0]; // 隐藏的tid列
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
    }

    private void UserTeam_Load(object sender, EventArgs e)
    {
        // 先添加列
        var columns = new List<string> { "名称", "介绍", "人数", "查看", "进入", "置顶", "tid" };
        foreach (var column in columns) dataGridView1.Columns.Add(column, column);

        dataGridView1.ScrollBars = ScrollBars.Vertical;

        // 设置列宽
        var width = dataGridView1.Width;
        dataGridView1.Columns[0].Width = 120;
        dataGridView1.Columns[1].Width = width - 370 - 20;
        dataGridView1.Columns[2].Width = 50;
        dataGridView1.Columns[3].Width = 50;
        dataGridView1.Columns[4].Width = 50;
        dataGridView1.Columns[5].Width = 50;
        dataGridView1.Columns[5].Width = 100;

        // 设置为只读
        dataGridView1.ReadOnly = true;
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.RowHeadersVisible = false;
        dataGridView1.AllowUserToResizeRows = false;

        // 加载数据
        LoadData();
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // 判断是否点击到了表格
        //点击button按钮事件
        if (dataGridView1.Columns[e.ColumnIndex].Name == "查看")
        {
            new TeamInfo(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value)).ShowDialog();
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
        //先清空数据
        this.dataGridView1.Rows.Clear();

        this.LoadData();
    }
}