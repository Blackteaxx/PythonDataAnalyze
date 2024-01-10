using Microsoft.VisualBasic.Logging;
using System.Windows.Forms;

namespace IS.Forms;

public partial class Main : Form
{
    // 全局变量区域
    public static int uid = 1;

    public static readonly List<string> JoinRight = new()
    {
        "允许所有方式",
        "禁止搜索加入",
        "禁止加入码和搜索加入"
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
        FormShow(new Login());
    }

    /// <summary>
    /// 成功登录，转到home界面
    /// </summary>
    public void LoginSuccess()
    {
        new Home().Show();
        this.Hide();
    }

    /// <summary>
    /// 展示指定的窗体
    /// </summary>
    /// <param name="f"></param>
    public void FormShow(Form f)
    {
        f.TopLevel = false;//取消非顶级窗体
        f.WindowState = FormWindowState.Maximized;//将窗体最大化
        f.FormBorderStyle = FormBorderStyle.None;//设为无边框
        f.Parent = this;//指定该窗体的父窗体
        f.Show();//展示窗体
    }
}