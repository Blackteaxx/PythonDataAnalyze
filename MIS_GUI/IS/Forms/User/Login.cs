using IS.Forms;
using IS.Forms.Team;
using IS.Forms.User;
using IS.Services;

namespace IS;

public partial class Login : Form
{
    private readonly User user = new();
    private bool exit = true;

    public Login()
    {
        InitializeComponent();
    }

    /// <summary>
    ///     登录按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button1_Click(object sender, EventArgs e)
    {
        // 先从输入框获取登录名和密码
        var name = textBox1.Text.Trim();
        var pwd = textBox2.Text.Trim();
        var r = user.Login(name, pwd);
        if (r.Status)
        {
            Main.uid = Convert.ToInt32(r.Data); // 更新全局变量
            exit = false;
            new UserTeam().Show();
            Close();
        }
        else
        {
            MessageBox.Show("登录失败");
        }
    }

    /// <summary>
    ///     清空事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button3_Click(object sender, EventArgs e)
    {
        // 清空输入框
        textBox1.Text = "";
        textBox2.Text = "";
    }

    private void button2_Click(object sender, EventArgs e)
    {
        exit = false;
        var register = new Register();
        register.Show();
        Close();
    }

    private void Login_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (exit) Application.Exit();
    }
}