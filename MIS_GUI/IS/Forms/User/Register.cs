namespace IS.Forms.User;

public partial class Register : Form
{
    private readonly Services.User user = new();
    private bool exit = true;

    public Register()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // 获取输入框的值
        var loginName = textBox1.Text.Trim();
        var password = textBox2.Text.Trim();
        var passwordAgain = textBox3.Text.Trim();
        var name = textBox4.Text.Trim();

        if (password != passwordAgain)
        {
            MessageBox.Show("两次输入的密码不一致");
            return;
        }

        var r = user.Register(loginName, password, name);
        // 进行注册
        if (r.Status)
        {
            MessageBox.Show("注册成功");
            exit = false;
            var m = this.Parent as Main;
            m.FormShow(new Login(loginName));
            //new Login(loginName).Show();
            this.Hide();
            this.Close();
        }
        else
            MessageBox.Show(r.Message);
    }

    private void button3_Click(object sender, EventArgs e)
    {
        // 清空输入框
        textBox1.Text = "";
        textBox2.Text = "";
        textBox3.Text = "";
        textBox4.Text = "";
    }

    private void button2_Click(object sender, EventArgs e)
    {
        exit = false;
        var m = this.Parent as Main;
        m.FormShow(new Login());
        Close();
    }

    private void Register_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (exit) Application.Exit();
    }
}