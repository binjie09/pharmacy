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
    public partial class form1 : Form
    {
        MyData md;
        public form1()
        {
            InitializeComponent();
            md = new MyData();
            Init();
        }
        private void BindCombobox()
        {
            comboBoxDoctor.DataSource = md.Ds.Tables["Doctor"];
            comboBoxDoctor.DisplayMember = "Name";
            comboBoxDoctor.ValueMember = "Name";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            HSSFWorkbook workbook2003 = new HSSFWorkbook(); //新建xls工作簿
            workbook2003.CreateSheet("Sheet1");  //新建3个Sheet工作表
            workbook2003.CreateSheet("Sheet2");
            workbook2003.CreateSheet("Sheet3");
            FileStream file2003 = new FileStream(@"D:\Excel2003.xls", FileMode.Create);
            workbook2003.Write(file2003);
            file2003.Close();  //关闭文件流
            workbook2003.Close();

            XSSFWorkbook workbook2007 = new XSSFWorkbook();  //新建xlsx工作簿
            workbook2007.CreateSheet("Sheet1");
            workbook2007.CreateSheet("Sheet2");
            workbook2007.CreateSheet("Sheet3");
            FileStream file2007 = new FileStream(@"D:\Excel2007.xlsx", FileMode.Create);
            workbook2007.Write(file2007);
            file2007.Close();
            workbook2007.Close();
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

        private void FreshPrise()//更新所有价格
        {
            if (shishoujine.Text == "" || comboBoxDoctor.Text == "" || yaojia.Text == "")
            {
                return;
            }
            double _fees = md.GetDoctorFeesByName(comboBoxDoctor.Text);
            fees.Text = _fees.ToString();
            double _total = (Convert.ToDouble(yaojia.Text) + _fees);
            zhaoling.Text = (Convert.ToDouble(shishoujine.Text) - _total).ToString();
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
            if (_name == "")
            {
                MessageBox.Show("请选择医生");
                return;
            }
            else if (Convert.ToDouble(zhaoling.Text) < 0)
            {
                MessageBox.Show("实收金额低于总价，请检查");
                return;
            }

            Form2 from2 = new Form2(comboBoxDoctor.Text,
               Convert.ToDouble(yaojia.Text),
               Convert.ToDouble(fees.Text),
               0.0,
               0.0,
               Convert.ToDouble(shishoujine.Text) - Convert.ToDouble(zhaoling.Text),
               "现金",
               textRemark.Text);
            from2.ShowDialog();

           

            Init();
        }
        private void Init()
        {
            yaojia.Text = "";
            shishoujine.Text = "";
            zhaoling.Text = "";
            total.Text = "";
        }
    }
}