using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

namespace 药店报账工具
{
    /// <summary>
    /// 主窗口
    /// </summary>
    public partial class form1 : Form
    {
        MyData md;
        public form1()
        {
            InitializeComponent();
            md = new MyData();
            Init();
        }
        /// <summary>
        /// 绑定comboBox数据源
        /// </summary>
        private void BindCombobox()
        {
            comboBoxDoctor.DataSource = md.Ds.Tables["Doctor"];
            comboBoxDoctor.DisplayMember = "Name";
            comboBoxDoctor.ValueMember = "Name";
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            BindCombobox();
            FreshPrise();
        }

        private void 添加医生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCreateDoctor f = new FormCreateDoctor();
            f.ShowDialog();
            FreshPrise();
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void 选择医生(object sender, EventArgs e)
        {
            FreshPrise();
        }
        /// <summary>
        /// 更新所有价格
        /// </summary>
        private void FreshPrise()
        {
            try
            {
                double _fees = md.GetDoctorFeesByName(comboBoxDoctor.Text);
                if (comboBoxDoctor.Text != "")
                {
                    fees.Text = _fees.ToString();
                }
                double _total = 0;
                if (yaojia.Text != "")
                {
                    _total = (Convert.ToDouble(yaojia.Text) + _fees);
                    total.Text = _total.ToString();
                }
                if (shishoujine.Text != "")
                {
                    zhaoling.Text = (Convert.ToDouble(shishoujine.Text) - _total).ToString();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("请输入正确的数字格式");
            }




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
            string _name = comboBoxDoctor.Text; //医生姓名
            try
            {
                if (_name == "")
                {
                    MessageBox.Show("请选择医生");
                    return;
                }
                else if (total.Text == "")
                {
                    MessageBox.Show("请输入总药价");
                    return;
                }
                else if (shishoujine.Text == "")
                {
                    MessageBox.Show("请输入实收金额");
                    return;
                }
                else if (Convert.ToDouble(zhaoling.Text) < 0)
                {
                    MessageBox.Show("实收金额低于总价，请检查");
                    return;
                }
                System.DateTime currentTime = new System.DateTime(); //当前时间
                currentTime = System.DateTime.Now;//时间

                double _total = 0;//总价格 包括医生的诊费等
                string _remark = textRemark.Text;//备注

                _total = Convert.ToDouble(total.Text);

                Form2 from2 = new Form2(comboBoxDoctor.Text,
                   Convert.ToDouble(yaojia.Text),
                   Convert.ToDouble(fees.Text),
                   0.0,
                   0.0,
                   0.0,
                   Convert.ToDouble(shishoujine.Text) - Convert.ToDouble(zhaoling.Text),
                   "现金",
                   textRemark.Text);
                from2.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确的数字格式");
                return;
            }

            Init();
        }
        /// <summary>
        /// 初始化价格输入框
        /// </summary>
        private void Init()
        {
            yaojia.Text = "";
            shishoujine.Text = "";
            zhaoling.Text = "";
            total.Text = "";
        }
    }
}