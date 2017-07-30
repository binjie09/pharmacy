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
            ReadFile(@".\sav.dat");
        }

        private void 添加医生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManageDoctor f = new FormManageDoctor();
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
                double guanli = 0,daijian = 0,baozhuang = 0;
                double _fees = md.GetDoctorFeesByName(comboBoxDoctor.Text);
                if(textGuanli.Text != "")
                {
                    guanli = Convert.ToDouble(textGuanli.Text);
                }
                if(textDaijian.Text != "")
                {
                    daijian = Convert.ToDouble(textDaijian.Text);
                }
                if(textBaozhuang.Text != "")
                {
                    baozhuang = Convert.ToDouble(textBaozhuang.Text);
                }
                if (comboBoxDoctor.Text != "")
                {
                    fees.Text = _fees.ToString();
                }
                double _total = 0;
                if (yaojia.Text != "")
                {
                    _total = (Convert.ToDouble(yaojia.Text) + _fees +guanli + daijian+baozhuang);
                    total.Text = _total.ToString();
                }
                if (shishoujine.Text != "")
                {
                    zhaoling.Text = (Convert.ToDouble(shishoujine.Text) - _total).ToString();
                }
            }
            catch (FormatException)
            {

                shishoujine.Text = "";
                yaojia.Text = "";
            }
           
        }
       /// <summary>
       /// 将最后一次输入的代煎费 管理费、包装费等保存在dat文件里 下次打开自动读取 这是读取文件
       /// </summary>
       /// <param name="path">文件路径</param>
        private void ReadFile(string path)
        {
            if (!File.Exists(@"./sav.dat"))
            {
                return;
            }
            FileStream fs = new FileStream(path, FileMode.Open);
            Byte[] bt = new Byte[8];
            fs.Read(bt, 0, 8);
            double guanli = BitConverter.ToDouble(bt, 0);
            fs.Read(bt, 0, 8);
            double baozhuang = BitConverter.ToDouble(bt, 0);
            fs.Read(bt, 0, 8);
            double daijian = BitConverter.ToDouble(bt, 0);
            textBaozhuang.Text = baozhuang.ToString();
            textDaijian.Text = daijian.ToString();
            textGuanli.Text = guanli.ToString();
            fs.Close();
        }
        /// <summary>
        /// 将最后一次输入的代煎费 管理费、包装费等保存在dat文件里 下次打开自动读取 这是保存文件
        /// </summary>
        /// <param name="path">文件路径</param>
        private void SaveToFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            double[] d = new double[3];
            fs.Write(BitConverter.GetBytes(Convert.ToDouble(textGuanli.Text)), 0, 8);
            fs.Write(BitConverter.GetBytes(Convert.ToDouble(textBaozhuang.Text)), 0, 8);
            fs.Write(BitConverter.GetBytes(Convert.ToDouble(textDaijian.Text)), 0, 8);
            fs.Flush();
            fs.Close();
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
                   Convert.ToDouble(textGuanli.Text),
                   Convert.ToDouble(textBaozhuang.Text),
                   Convert.ToDouble(textDaijian.Text),
                   Convert.ToDouble(shishoujine.Text) - Convert.ToDouble(zhaoling.Text),
                   comboBox1.Text,
                   textRemark.Text);
                
                DialogResult res  = from2.ShowDialog();
                if(res == DialogResult.OK)
                {
                    Init();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确的数字格式");
                return;
            }
            SaveToFile(@"./sav.dat");
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
            textRemark.Text = "";
        }

        private void 中成药ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Medi fm = new Medi();
            
            fm.ShowDialog();
            if(fm.DialogResult == DialogResult.OK)
            {
                DataRow rows = null;
                rows = MyData.pharmacyDS.Tables["TransactionRecord"].Rows[MyData.pharmacyDS.Tables["TransactionRecord"].Rows.Count - 1];
                ExcelHelper.x2003.TRTableToExcelForXLS(rows, @".\file.xls");
            } 
        }

        private void 茶方ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tea ft = new Tea();
            ft.ShowDialog();
            if (ft.DialogResult == DialogResult.OK)
            {
                DataRow rows = null;
                rows = MyData.pharmacyDS.Tables["TransactionRecord"].Rows[MyData.pharmacyDS.Tables["TransactionRecord"].Rows.Count - 1];
                ExcelHelper.x2003.TRTableToExcelForXLS(rows, @".\file.xls");
            }
        }

        private void 费用变化(object sender, EventArgs e)
        {
            FreshPrise();
        }

        private void 添加茶方ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManageteaParty f = new FormManageteaParty();
            f.ShowDialog();
        }
    }
}