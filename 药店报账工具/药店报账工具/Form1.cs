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
        MyData md;
        public form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             md = new MyData();
        }

        private void 添加医生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCreateDoctor f = new FormCreateDoctor();
            f.Show();
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void 选择医生(object sender, EventArgs e)
        {

            freshPrise();
        }

        private void freshPrise()//更新所有价格
        {
            double _fees = md.getDoctorFeesByName(comboBoxDoctor.Text);
            fees.Text = _fees.ToString();
            double _total = (Convert.ToDouble(yaojia.Text) + _fees);

            total.Text = _total.ToString();
        }

        private void 输入总药价时(object sender, EventArgs e)
        {
            freshPrise();
        }

        private void 输入实收金额时(object sender, EventArgs e)
        {
            freshPrise();
        }

        private void button1_Click(object sender, EventArgs e) // 收款按钮按下
        {
            MyData.insertToDoctor(comboBoxDoctor.Text,Convert.ToDouble(total.Text), textRemark.Text);
        }
    }
}
