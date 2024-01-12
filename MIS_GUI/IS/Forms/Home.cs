using IS.Forms.Task;
using IS.Forms.Team;
using System.Text.RegularExpressions;

namespace IS.Forms
{
    public partial class Home : Form
    {
        private List<string> Forms = new List<string>(); // 用于存储所有的子窗体
                                                         // 通过页面的text来获取对应的子窗体

        private int CurrentFormIndex = 0; // 标识当前的子窗体index
        private List<string> HeaderLabelList = new List<string>(); // 存储header的标题
        private Dictionary<string, Form> FormNameDict = new Dictionary<string, Form>();
        private List<Button> buttons = new List<Button>();
        private List<Label> labels = new List<Label>();

        public Home()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 切换Main窗体
        /// </summary>
        /// <param name="form"></param>
        public void SetMainPanel(Form form)
        {
            form.TopLevel = false;
            form.Parent = this; // 设为子窗体，方便切换界面
            MainPanel.Controls.Clear(); // 清空原有的界面
            MainPanel.Controls.Add(form);
            form.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Home_Load(object sender, EventArgs e)
        {
            // 初始化界面
            var h = new UserTask(1);
            SetMainPanel(h);
            Forms.Add("首页");
            HeaderLabelList.Add("首页");
            FormNameDict.Add("首页", h);


            // 刚开始应该禁用前一步和下一步按钮
            ForwardButton.Enabled = false;
            NextButton.Enabled = false;

            // 测试setheader
            FlushHeader();
        }

        /// <summary>
        /// 用于绘制header栏的下边框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, HeaderPanel.ClientRectangle,
              Color.White, 0, ButtonBorderStyle.Solid, //左边
　　　　　    Color.White, 0, ButtonBorderStyle.Solid, //上边
　　　　　    Color.DimGray, 0, ButtonBorderStyle.Solid, //右边
　　　　　    Color.DimGray, 1, ButtonBorderStyle.Solid //底边
            );
        }

        /// <summary>
        /// 创建header按钮，用于分级
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private Button CreateHeaderButton(string text)
        {
            Button button = new Button();
            button.Text = text;
            // 需要根据text来计算长度，中文7，英文3。55是显示两个中文的最小宽度
            int chineseCount = 0;
            int nonChineseCount = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (Regex.IsMatch(text[i].ToString(), @"[\u4e00-\u9fa5]"))
                {
                    chineseCount++;
                }
                else
                {
                    nonChineseCount++;
                }
            }
            button.Size = new Size(50 + 8 * chineseCount + 3 * nonChineseCount, 30);
            button.ForeColor = SystemColors.HotTrack;
            button.Cursor = Cursors.Hand;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Parent = HeaderPanel;
            // button.Click = LoadMainPanel(form);
            buttons.Add(button);
            return button;
        }

        /// <summary>
        /// 生成header所需的>标签
        /// </summary>
        /// <returns></returns>
        private Label CreateHeaderLabel()
        {
            Label label = new Label();
            label.Text = ">";
            label.Font = new Font("Microsoft YaHei UI", 10);
            label.Parent = HeaderPanel;
            label.Size = new Size(26, 26);
            labels.Add(label);
            return label;
        }

        /// <summary>
        /// 刷新标题栏
        /// </summary>
        public void FlushHeader()
        {
            // 清除掉原先的子控件们
            foreach (var item in buttons)
            {
                HeaderPanel.Controls.Remove(item);
            }
            foreach (var item in labels)
            {
                HeaderPanel.Controls.Remove(item);
            }
            // 排除掉前进和后退的按钮，首页的位置为85，5
            var startPosition = 85;
            // 遍历HeaderLabelList
            for (int i = 0; i < HeaderLabelList.Count; i++)
            {
                var b = CreateHeaderButton(HeaderLabelList[i]);
                b.Location = new Point(startPosition, 5);
                b.Click += new EventHandler(HeaderButtonClicked);
                HeaderPanel.Controls.Add(b);
                startPosition += (b.Width - 5);

                if (i != HeaderLabelList.Count - 1)
                {
                    Label l = CreateHeaderLabel();
                    l.Location = new Point(startPosition, 7);
                    l.Click += new EventHandler(LabelTestMsg);
                    l.BringToFront();
                    HeaderPanel.Controls.Add(l);
                    startPosition += 20;
                }
            }
        }

        /// <summary>
        /// 添加新的form到序列的末尾
        /// </summary>
        /// <param name="text"></param>
        /// <param name="form"></param>
        public void AddHeaderLabel(string text, Form form)
        {
            HeaderLabelList.Add(text);
            if(FormNameDict.ContainsKey(text)) FormNameDict.Remove(text);
            FormNameDict.Add(text, form);
            FlushHeader();
        }

        /// <summary>
        /// 在sider切换的时候应该重置根标签
        /// </summary>
        /// <param name="text"></param>
        /// <param name="form"></param>
        public void ResetHeaderLabel(string text, Form form)
        {
            HeaderLabelList.Clear();
            HeaderLabelList.Add(text);
            if (FormNameDict.ContainsKey(text)) FormNameDict.Remove(text);
            FormNameDict.Add(text, form);
            SetMainPanel(form);
            FlushHeader();
        }

        /// <summary>
        /// 移除header的最后一个标签
        /// </summary>
        /// <param name="text"></param>
        public void RemoveHeaderLabel()
        {
            HeaderLabelList.RemoveAt(HeaderLabelList.Count - 1);
            FlushHeader();
        }

        private void HeaderButtonClicked(object sender, EventArgs e)
        {
            var b = (Button)sender;
            var name = b.Text;
            // 如果点击最后一个标签，则无反应
            if (name == HeaderLabelList[HeaderLabelList.Count() - 1]) return;

            SetMainPanel(FormNameDict[name]);
            for (int i = HeaderLabelList.Count() - 1; i >= 0; i--)
            {
                if (name == HeaderLabelList[i])
                {
                    break;
                }
                HeaderLabelList.RemoveAt(HeaderLabelList.Count - 1);
            }
            FlushHeader();
        }

        private void LabelTestMsg(object sender, EventArgs e)
        {
            var b = (Label)sender;
            MessageBox.Show(b.Location.ToString());
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ResetHeaderLabel("我的团队", new UserTeam());
        }
    }
}
