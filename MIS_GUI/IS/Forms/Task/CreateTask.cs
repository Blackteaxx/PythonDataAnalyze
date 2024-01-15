using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.Forms.Task
{
    public partial class CreateTask : Form
    {
        private readonly int uid = 1;
        private readonly Services.Task task = new Services.Task();
        private readonly Services.Team team = new Services.Team();

        public CreateTask(int uid)
        {
            InitializeComponent();
            this.uid = uid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 根据comboBox1的选择的teamname查找teamId
            var teamId = team.GetTeamId(comboBox1.SelectedItem.ToString());

            // 判断输入的taskName与Description是否合法
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入任务名称");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("请输入任务描述");
                return;
            }

            var taskName = textBox1.Text.Trim();
            var description = textBox2.Text.Trim();

            // 创建任务
            var result = task.CreateTask(teamId, uid, taskName, description);
            if (result is null)
            {
                MessageBox.Show("创建成功");
            }
            else
            {
                MessageBox.Show(result);
            }

        }

        private void CreateTask_Load(object sender, EventArgs e)
        {
            // 根据用户查找所有team
            var data = team.GetTeams(uid);
            if (data is null)
            {
                return;
            }
            // 将data放置在comboBox中
            foreach (var item in data)
            {
                comboBox1.Items.Add(item[1]);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
