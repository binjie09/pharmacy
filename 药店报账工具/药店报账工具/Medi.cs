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
    public partial class Medi : Form
    {
        public Medi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (name == "")
            {
                MessageBox.Show("请输入药名");
                return;
            }
            try
            {
                double danjia = Convert.ToDouble(textBox2.Text);
                double shuliang = Convert.ToDouble(textBox3.Text);
                double zongjia = shuliang * danjia;
                string payWay = comboBox1.Text;
                MyData.InsertPatentMedicineToTR(name, danjia, zongjia,payWay , "");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                MessageBox.Show("在转换数字的时候发生了问题。");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        /// <summary>
        /// 更新总价
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FreshZongjia(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "" && textBox3.Text != "")
                {
                    double danjia = Convert.ToDouble(textBox2.Text);
                    double shuliang = Convert.ToDouble(textBox3.Text);
                    textBox4.Text = (danjia * shuliang).ToString();
                }
            }
            catch
            {
                MessageBox.Show("请输入正确的数字格式");
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }
    }
}
