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
    /// <summary>
    /// 创建医生窗口
    /// </summary>
    public partial class FormCreateDoctor : Form
    {
        private DataTable currentTable = MyData.pharmacyDS.Tables["Doctor"];

        public DataRow tempRow = null;

        public FormCreateDoctor()
        {
            InitializeComponent();
            InitDataGridView();
        }

        private void InitDataGridView()//初始化DataGridView 内的数据，绑定数据源  窗口创建时被调用
        {
            
            dataGridView1.DataSource = MyData.pharmacyDS.Tables["Doctor"];
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            string _name = "";
            double _fee = 0;
            string _remark = "";
            try
            {
                _name = textName.Text;
                _fee = Convert.ToDouble(textFee.Text);
                _remark = textRemark.Text;
                textName.Text = "";
                textFee.Text = "";
                textRemark.Text = "";
            }
            catch (System.InvalidCastException)
            {
                MessageBox.Show("诊费输入不正确！");
            }

            MyData.InsertToDoctor(_name, _fee, _remark);
            MyData.pharmacyDS.Tables["Doctor"].AcceptChanges();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] rowToDelete = MyData.pharmacyDS.Tables["Doctor"].Select(string.Format("Name='{0}'", textDeleteName.Text));
                textDeleteName.Text = "";
                if(rowToDelete.Length == 0)
                {
                    MessageBox.Show("没有找到这个医生", "输入名字错误");
                }else
                {
                    // 默认一个名字一个人
                    rowToDelete[0].Delete();
                    MyData.pharmacyDS.Tables["Doctor"].AcceptChanges();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MyData.Save("delete Doctor");
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            DataRow [] rowToupdate = MyData.pharmacyDS.Tables["Doctor"].Select(String.Format("Name='{0}'", textUpdateName.Text));
            if(rowToupdate.Length == 0)
            {
                MessageBox.Show("没有找到这个医生", "输入名字错误");
            }
            else
            {
                FormUpdateDoctor form1 = new FormUpdateDoctor()
                {
                    Owner = this
                };
                //this.AddOwnedForm(form1);
                tempRow = rowToupdate[0];
                form1.ShowDialog();
                MyData.pharmacyDS.Tables["Doctor"].AcceptChanges();
            }
            MyData.Save("alter Doctor");
        }
    }
}
