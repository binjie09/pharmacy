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

        private void Tea_Load(object sender, EventArgs e)
        {
            BindCombobox();
            FreshPrise();
        }

        private void FreshPrise()
        {
            //double price = MyData.GetTeaPriceByName(comboBox1.Text);
            try
            {
                double price = MyData.GetTeaPriceByName(comboBox1.Text);

                textBox2.Text = price.ToString();

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
            try
            {
                string name = comboBox1.Text;
                double price = Convert.ToDouble(textBox2.Text);
                double amount = Convert.ToDouble(textBox3.Text);
                double total = Convert.ToDouble(textBox4.Text);
                MyData.InsertToteaPartyRT(name, amount, price, "");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                MessageBox.Show("插入数据时出错！");
            }
        }

        private void amout_changed(object sender, EventArgs e)
        {
            
            try
            {
                if (textBox3.Text != "")
                {
                    double total = 0;
                    int amount = Convert.ToInt32(textBox3.Text);
                    total = amount * Convert.ToDouble(textBox2.Text);
                    textBox4.Text = total.ToString();
                }
                else
                {
                    return;
                }

               
            }
            catch (FormatException)
            {
                MessageBox.Show("请输入正确的数字格式");
            }

        }
    }
}
