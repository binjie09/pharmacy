using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 药店报账工具
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyData md = new MyData();
        }

        private void 添加医生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCreateDoctor f = new FormCreateDoctor();
            f.Show();
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }
    }
}
