﻿using System;
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
    /// 更新医生窗口
    /// </summary>
    public partial class FormUpdateDoctor : Form
    {
        public FormCreateDoctor form;
        public FormUpdateDoctor()
        {
            InitializeComponent();
            
            
        }
        /// <summary>
        /// 不建议这样 建议这里要用DataRow就用构造函数传DataRow
        /// </summary>
        /// <param name="myForm"></param>
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
