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
    public partial class ReviewTask : Form
    {
        private readonly int tid = 1;
        private readonly Services.Task task = new Services.Task();
        public ReviewTask(int tid)
        {
            InitializeComponent();
            this.tid = tid;
        }

        private void ReviewTask_Load(object sender, EventArgs e)
        {
            // label1显示任务名称
            label1.Text = task.GetTask(tid)[0];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 更改tid的status为1
            if(task.UpdateTaskStatus(tid))
            {
                MessageBox.Show("审阅通过");
            }else
            {
                MessageBox.Show("审阅失败");
            }
        }
    }
}
