namespace IS.Forms.Team;

public partial class CreateTeam : Form
{
    private readonly Services.Team team = new();

    public CreateTeam()
    {
        InitializeComponent();
    }

    private void AffirmButton_Click(object sender, EventArgs e)
    {
        // 获取信息，创建团队
        // 参数合法化判定
        if (NameTextBox.Text == "")
        {
            MessageBox.Show("请输入团队名称");
            return;
        }

        if (DescriptionTextBox.Text == "")
        {
            MessageBox.Show("请输入团队描述");
            return;
        }

        var name = NameTextBox.Text.Trim();
        var description = DescriptionTextBox.Text.Trim();
        var joinCode = JoinCodeTextBox.Text.Trim();
        var joinRight = JoinRightComboBox.SelectedIndex;
        var joinCodeRight = JoinCodeRightComboBox.SelectedIndex;

        // 判断用户是否自定义了加入码
        if (joinCode != "" && team.CreateTeam(Main.uid, name, description, joinCode) == "")
            MessageBox.Show("创建成功");
        else if (joinCode == "" && team.CreateTeam(Main.uid, name, description) == "")
            MessageBox.Show("创建成功");
        else
            MessageBox.Show("");
    }

    private void CreateTeam_Load(object sender, EventArgs e)
    {
        JoinRightComboBox.Text = Main.JoinRight[0];
        JoinCodeRightComboBox.Text = Main.JoinCodeRight[0];
    }

    private void ClearButton_Click(object sender, EventArgs e)
    {
        // 清空
        NameTextBox.Text = "";
        DescriptionTextBox.Text = "";
        JoinCodeTextBox.Text = "";
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
        // 退出
        this.Close();
    }
}