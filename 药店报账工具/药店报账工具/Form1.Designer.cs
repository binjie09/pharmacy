namespace 药店报账工具
{
    partial class form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.添加医生信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中成药ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.茶方ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDoctor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fees = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.yaojia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.shishoujine = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.zhaoling = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textRemark = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lableGuanlifei = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.textGuanli = new System.Windows.Forms.TextBox();
            this.textBaozhuang = new System.Windows.Forms.TextBox();
            this.textDaijian = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加医生信息ToolStripMenuItem,
            this.中成药ToolStripMenuItem1,
            this.茶方ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(780, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 添加医生信息ToolStripMenuItem
            // 
            this.添加医生信息ToolStripMenuItem.Name = "添加医生信息ToolStripMenuItem";
            this.添加医生信息ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.添加医生信息ToolStripMenuItem.Text = "添加医生信息";
            this.添加医生信息ToolStripMenuItem.Click += new System.EventHandler(this.添加医生信息ToolStripMenuItem_Click);
            // 
            // 中成药ToolStripMenuItem1
            // 
            this.中成药ToolStripMenuItem1.Name = "中成药ToolStripMenuItem1";
            this.中成药ToolStripMenuItem1.Size = new System.Drawing.Size(56, 21);
            this.中成药ToolStripMenuItem1.Text = "中成药";
            this.中成药ToolStripMenuItem1.Click += new System.EventHandler(this.中成药ToolStripMenuItem1_Click);
            // 
            // 茶方ToolStripMenuItem
            // 
            this.茶方ToolStripMenuItem.Name = "茶方ToolStripMenuItem";
            this.茶方ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.茶方ToolStripMenuItem.Text = "茶方";
            this.茶方ToolStripMenuItem.Click += new System.EventHandler(this.茶方ToolStripMenuItem_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(531, 500);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(460, 506);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "当前日期：";
            // 
            // comboBoxDoctor
            // 
            this.comboBoxDoctor.FormattingEnabled = true;
            this.comboBoxDoctor.Items.AddRange(new object[] {
            "王医生",
            "赵医生"});
            this.comboBoxDoctor.Location = new System.Drawing.Point(128, 59);
            this.comboBoxDoctor.Name = "comboBoxDoctor";
            this.comboBoxDoctor.Size = new System.Drawing.Size(121, 20);
            this.comboBoxDoctor.TabIndex = 3;
            this.comboBoxDoctor.SelectedIndexChanged += new System.EventHandler(this.选择医生);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "选择医生：";
            // 
            // fees
            // 
            this.fees.Location = new System.Drawing.Point(386, 59);
            this.fees.Name = "fees";
            this.fees.ReadOnly = true;
            this.fees.Size = new System.Drawing.Size(121, 21);
            this.fees.TabIndex = 5;
            this.fees.Text = "1.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "总药价：";
            // 
            // yaojia
            // 
            this.yaojia.Location = new System.Drawing.Point(128, 127);
            this.yaojia.Name = "yaojia";
            this.yaojia.Size = new System.Drawing.Size(121, 21);
            this.yaojia.TabIndex = 8;
            this.yaojia.Text = "1.0";
            this.yaojia.TextChanged += new System.EventHandler(this.输入总药价时);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(319, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "诊费：";
            this.label6.Click += new System.EventHandler(this.Label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 354);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "应收金额：";
            // 
            // total
            // 
            this.total.Location = new System.Drawing.Point(128, 354);
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Size = new System.Drawing.Size(121, 21);
            this.total.TabIndex = 12;
            this.total.Text = "1.0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(315, 354);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "实收金额：";
            // 
            // shishoujine
            // 
            this.shishoujine.Location = new System.Drawing.Point(386, 354);
            this.shishoujine.Name = "shishoujine";
            this.shishoujine.Size = new System.Drawing.Size(121, 21);
            this.shishoujine.TabIndex = 14;
            this.shishoujine.Text = "1.0";
            this.shishoujine.TextChanged += new System.EventHandler(this.输入实收金额时);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(319, 399);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "找零：";
            // 
            // zhaoling
            // 
            this.zhaoling.Location = new System.Drawing.Point(386, 396);
            this.zhaoling.Name = "zhaoling";
            this.zhaoling.ReadOnly = true;
            this.zhaoling.Size = new System.Drawing.Size(121, 21);
            this.zhaoling.TabIndex = 16;
            this.zhaoling.Text = "1.0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(602, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 57);
            this.button1.TabIndex = 18;
            this.button1.Text = "收款";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // textRemark
            // 
            this.textRemark.Location = new System.Drawing.Point(128, 455);
            this.textRemark.Name = "textRemark";
            this.textRemark.Size = new System.Drawing.Size(121, 21);
            this.textRemark.TabIndex = 19;
            this.textRemark.Text = "无";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(57, 459);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "备注：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "现金",
            "支付宝",
            "微信付款",
            "银行卡"});
            this.comboBox1.Location = new System.Drawing.Point(128, 261);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 21;
            this.comboBox1.Text = "现金";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(57, 266);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 22;
            this.label12.Text = "支付方式：";
            // 
            // lableGuanlifei
            // 
            this.lableGuanlifei.AutoSize = true;
            this.lableGuanlifei.Location = new System.Drawing.Point(319, 130);
            this.lableGuanlifei.Name = "lableGuanlifei";
            this.lableGuanlifei.Size = new System.Drawing.Size(53, 12);
            this.lableGuanlifei.TabIndex = 24;
            this.lableGuanlifei.Text = "管理费：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(57, 198);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 25;
            this.label15.Text = "包装费：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(315, 198);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 26;
            this.label16.Text = "代煎费：";
            // 
            // textGuanli
            // 
            this.textGuanli.Location = new System.Drawing.Point(386, 127);
            this.textGuanli.Name = "textGuanli";
            this.textGuanli.Size = new System.Drawing.Size(121, 21);
            this.textGuanli.TabIndex = 27;
            this.textGuanli.Text = "1";
            // 
            // textBaozhuang
            // 
            this.textBaozhuang.Location = new System.Drawing.Point(128, 195);
            this.textBaozhuang.Name = "textBaozhuang";
            this.textBaozhuang.Size = new System.Drawing.Size(121, 21);
            this.textBaozhuang.TabIndex = 28;
            this.textBaozhuang.Text = "1";
            // 
            // textDaijian
            // 
            this.textDaijian.Location = new System.Drawing.Point(386, 195);
            this.textDaijian.Name = "textDaijian";
            this.textDaijian.Size = new System.Drawing.Size(121, 21);
            this.textDaijian.TabIndex = 29;
            this.textDaijian.Text = "1";
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 557);
            this.Controls.Add(this.textDaijian);
            this.Controls.Add(this.textBaozhuang);
            this.Controls.Add(this.textGuanli);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lableGuanlifei);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textRemark);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zhaoling);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.shishoujine);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.total);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.yaojia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fees);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxDoctor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "form1";
            this.Text = "药店信息管理v0.0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripMenuItem 添加医生信息ToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDoctor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fees;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox yaojia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox total;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox shishoujine;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox zhaoling;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textRemark;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripMenuItem 中成药ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 茶方ToolStripMenuItem;
        private System.Windows.Forms.Label lableGuanlifei;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textGuanli;
        private System.Windows.Forms.TextBox textBaozhuang;
        private System.Windows.Forms.TextBox textDaijian;
    }
}

