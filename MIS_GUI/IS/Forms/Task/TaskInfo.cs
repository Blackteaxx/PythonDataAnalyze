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
    public partial class TaskInfo : Form
    {
        private readonly int tid = 1;
        private readonly Services.Task task = new Services.Task();
        private readonly Services.Team team = new Services.Team();

        public TaskInfo(int tid)
        {
            InitializeComponent();
            this.tid = tid;
        }

        private void TaskInfo_Load(object sender, EventArgs e)
        {
            // 根据taskid获取task信息
            var data = task.GetTask(tid);
            this.textBox1.Text = data[0];
            this.textBox2.Text = data[1];
            this.label5.Text = data[2];

            // 根据tid获取所有成员信息
            int teamId = task.GetTeamId(tid);
            // 获取team的成员信息
            var members = team.GetTeamMembers(teamId);
            //获取已加入task的成员信息
            var membersInTask = task.GetTaskMembers(tid);
            // 将未加入task的成员信息加入listbox1中
            foreach (var item in members)
            {
                this.listBox1.Items.Add(item[0]);
            }
            // 将加入task的成员信息加入listbox2中

        }
    }
}
