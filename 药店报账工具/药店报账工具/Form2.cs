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
    /// 确认窗口
    /// </summary>
    public partial class Form2 : Form
    {
        
        private string text1;
        private double v1;
        private double v2;
        private double v3;
        private double v4;
        private double v5;
        private string v6;
        private string text2;
        private double fees;
        public Form2()
        {
            InitializeComponent();
        }


        public Form2(string text1, double v1,double fees, double v2, double v3, double v4, double v5, string v6, string text2)
        {
            InitializeComponent();
            this.text1 = text1;
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
            this.fees = fees;
            this.v6 = v6;
            this.text2 = text2;
 
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text += text1;
            label2.Text += v1.ToString();
            label3.Text += v2.ToString();
            label4.Text += v3.ToString();
            label5.Text += v4.ToString();
            label6.Text += v5.ToString();
            label7.Text += v6;
            label8.Text += text2;
            label9.Text = System.DateTime.Now.ToString("f");
            label10.Text += fees.ToString();
            this.AcceptButton = btnConfirm;

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DateTime Guid = MyData.InsertToTransactionRecord(text1, v1, fees, v2, v3, v4, v5, v6, text2);
            MyData.Save("normal");
            //MyData.pharmacyDS.Tables["Counter"].Rows[0];
            DataRow rows = null;
            if (MyData.pharmacyDS.Tables["TransactionRecord"].Rows[MyData.pharmacyDS.Tables["TransactionRecord"].Rows.Count-1][8].ToString().Equals(Guid.ToString()))
            {
                rows = MyData.pharmacyDS.Tables["TransactionRecord"].Rows[MyData.pharmacyDS.Tables["TransactionRecord"].Rows.Count-1];
            }
            string month = "" + Guid.Year + "年" + Guid.Month + "月";
            ExcelHelper.x2003.TableToExcelForXLS(rows, @".\file.xls", month);

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}