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
    /// 更新茶方的窗口
    /// </summary>
    public partial class FormUpdateTea : Form
    {
        private DataRow tempRow = null;
        public FormUpdateTea()
        {
            InitializeComponent();
        }
        public FormUpdateTea(DataRow dr)
        {
            InitializeComponent();
            tempRow = dr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tempRow["Name"] = textBox_name.Text;
            tempRow["Price"] = textBox_price.Text;
            tempRow["Remark"] = textBox_remark.Text;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
