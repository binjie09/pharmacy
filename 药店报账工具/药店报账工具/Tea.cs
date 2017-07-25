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
    public partial class Tea : Form
    {
        public Tea()
        {
            InitializeComponent();
        }

        private void BindCombobox()
        {
            comboBox1.DataSource = MyData.pharmacyDS.Tables["teaParty"];
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Name";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

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
            }
        }

        private void Tea_Load(object sender, EventArgs e)
        {
            BindCombobox();
            FreshPrise();
        }

        private void FreshPrise()
        {
            double price = MyData.GetTeaPriceByName(comboBox1.Text);
            try
            {


            }
            catch (FormatException)
            {
                MessageBox.Show("请输入正确的数字格式");
            }

        }

        private void 选择茶方(object sender, EventArgs e)
        {
            FreshPrise();
        }

        private void button_queren_Click(object sender, EventArgs e)
        {

        }
    }
}
