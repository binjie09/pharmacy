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
    public partial class FormManageteaParty : Form
    {
        private DataTable currentTable = MyData.pharmacyDS.Tables["teaParty"];

        private DataRow tempRow = null;

        public FormManageteaParty()
        {
            InitializeComponent();
            InitDateGrodView();

        }
        private void InitDateGrodView()
        {
            dataGridView2.DataSource = MyData.pharmacyDS.Tables["teaParty"];
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            string _name = "";
            double _fee = 0;
            string _remark = "";
            try
            {
                _name = textBox_name_add.Text;
                _fee = Convert.ToDouble(textBox_price_add.Text);
                _remark = textBox_remark_add.Text;

                textBox_name_add.Text = "";
                textBox_price_add.Text = "";
                textBox_remark_add.Text = "";
            }
            catch (System.InvalidCastException)
            {
                MessageBox.Show("诊费输入不正确！");
                return;
            }
            catch (System.FormatException)
            {
                MessageBox.Show("请输入正确的格式");
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("请检查输入");
                return;
            }
            MyData.InsertToTeaParty(_name, _fee, _remark);
            MyData.pharmacyDS.Tables["teaParty"].AcceptChanges();
        }

        private void button_change_Click(object sender, EventArgs e)
        {
            DataRow[] rowToupdate = MyData.pharmacyDS.Tables["teaParty"].Select(String.Format("Name='{0}'", textBox_name_change.Text));
            if (rowToupdate.Length == 0)
            {
                MessageBox.Show("没有找到这个茶方", "输入错误");
            }
            else
            {
                tempRow = rowToupdate[0];
                FormUpdateTea form1 = new FormUpdateTea(tempRow);

                form1.ShowDialog();
                MyData.pharmacyDS.Tables["teaParty"].AcceptChanges();
            }
            MyData.Save("alter teaParty");
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] rowToDelete = MyData.pharmacyDS.Tables["teaParty"].Select(string.Format("Name='{0}'", textBox_name_delete.Text));
                textBox_name_delete.Text = "";
                if (rowToDelete.Length == 0)
                {
                    MessageBox.Show("没有找到这个茶方", "输入错误");
                }
                else
                {
                    // 默认每个茶方的名字都不同
                    rowToDelete[0].Delete();
                    MyData.pharmacyDS.Tables["teaParty"].AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MyData.Save("delete teaParty");
        }
    }
}
