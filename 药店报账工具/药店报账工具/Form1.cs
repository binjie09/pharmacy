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
            md = new MyData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void 添加医生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCreateDoctor f = new FormCreateDoctor();
            f.ShowDialog();
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void 选择医生(object sender, EventArgs e)
        {
            FreshPrise();
        }

        private void FreshPrise()//更新所有价格
        {
            double _fees = md.GetDoctorFeesByName(comboBoxDoctor.Text);
            fees.Text = _fees.ToString();
            double _total = (Convert.ToDouble(yaojia.Text) + _fees);
            zhaoling.Text = (_total - Convert.ToDouble(shishoujine.Text)).ToString();
            total.Text = _total.ToString();
        }

        private void 输入总药价时(object sender, EventArgs e)
        {
            FreshPrise();
        }

        private void 输入实收金额时(object sender, EventArgs e)
        {
            FreshPrise();
        }

        private void Button1_Click(object sender, EventArgs e) // 收款按钮按下
        {
            System.DateTime currentTime = new System.DateTime(); //当前时间
            currentTime = System.DateTime.Now;//时间
            string _name = comboBoxDoctor.Text; //医生姓名
            double _total = Convert.ToDouble(total.Text);//总价格 包括医生的诊费等
            string _remark = textRemark.Text;//备注
            //MyData.insertTo(,, ); 发现不知道忘哪个表里插， 表还没写好
        }
    }
}
