namespace IS.Forms;

public partial class Main : Form
{
    // 全局变量区域
    public static int uid = 1;

    public static readonly List<string> JoinRight = new()
    {
        "允许所有方式",
        "禁止搜索加入",
        "禁止加入码加入"
    };

    public static readonly List<string> JoinCodeRight = new()
    {
        "允许所有人查看",
        "只允许管理员查看",
        "禁止所有人查看"
    };
    // 全局变量定义结束

    public Main()
    {
        InitializeComponent();
    }

    private void Main_Load(object sender, EventArgs e)
    {
        // 登录窗体
        var login = new Login();
        login.Show();
        // 这个窗体是主窗体，不显示
        BeginInvoke(() =>
        {
            Hide();
            Opacity = 1;
        });
    }
}