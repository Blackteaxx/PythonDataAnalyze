using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.Forms.Team
{
    public partial class TeamInviteMember : Form
    {
        private readonly int Tid; 

        public TeamInviteMember(int tid)
        {
            InitializeComponent();
            Tid = tid;
        }

        private void TeamInviteMember_Load(object sender, EventArgs e)
        {

        }
    }
}
