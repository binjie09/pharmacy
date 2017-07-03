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
    public partial class FormCreateDoctor : Form
    {
        public FormCreateDoctor()
        {
            InitializeComponent();
            InitDataGridView();
        }

        private void InitDataGridView()//初始化DataGridView 内的数据，绑定数据源  窗口创建时被调用
        {
            dataGridView1.DataSource = MyData.pharmacyDS;
           
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
            }
            catch (System.InvalidCastException)
            {
                MessageBox.Show("诊费输入不正确！");
            }

            MyData.InsertToDoctor(_name, _fee, _remark);//都写了Doctor类了结果没用上，不插入doctor？ 那就把doctor类删了吧
        }
        
    }
}
