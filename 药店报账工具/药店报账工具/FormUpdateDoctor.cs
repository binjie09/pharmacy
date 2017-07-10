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
    public partial class FormUpdateDoctor : Form
    {
        public FormCreateDoctor form;
        public FormUpdateDoctor()
        {
            InitializeComponent();
            
            
        }
        public FormUpdateDoctor(FormCreateDoctor myForm)
        {
            InitializeComponent();
            this.form = myForm;

        }

        private void FormUpdateDoctor_Load(object sender, EventArgs e)
        {
            this.form = (FormCreateDoctor)this.Owner;
            UpdateName.Text = form.tempRow["Name"].ToString();
        }

        private void buttonComfire_Click(object sender, EventArgs e)
        {
            form.tempRow["Name"] = textBoxName.Text;
            form.tempRow["Free"] = textBoxFee.Text;
            form.tempRow["Remark"] = textBoxRemark.Text;

            this.Close();
        }

        private void buttonConsole_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
