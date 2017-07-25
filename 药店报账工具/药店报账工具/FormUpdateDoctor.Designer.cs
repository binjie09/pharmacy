namespace 药店报账工具
{
    partial class FormupdateDoctor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxFee = new System.Windows.Forms.TextBox();
            this.textBoxRemark = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.buttonConsole = new System.Windows.Forms.Button();
            this.buttonComfire = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.doctorName = new System.Windows.Forms.Label();
            this.UpdateName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "诊费：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "备注：";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(140, 51);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 25);
            this.textBoxName.TabIndex = 3;
            // 
            // textBoxFee
            // 
            this.textBoxFee.Location = new System.Drawing.Point(139, 135);
            this.textBoxFee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxFee.Name = "textBoxFee";
            this.textBoxFee.Size = new System.Drawing.Size(100, 25);
            this.textBoxFee.TabIndex = 4;
            // 
            // textBoxRemark
            // 
            this.textBoxRemark.Location = new System.Drawing.Point(139, 219);
            this.textBoxRemark.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxRemark.Name = "textBoxRemark";
            this.textBoxRemark.Size = new System.Drawing.Size(100, 25);
            this.textBoxRemark.TabIndex = 5;
            // 
            // buttonConsole
            // 
            this.buttonConsole.Location = new System.Drawing.Point(49, 313);
            this.buttonConsole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonConsole.Name = "buttonConsole";
            this.buttonConsole.Size = new System.Drawing.Size(75, 30);
            this.buttonConsole.TabIndex = 6;
            this.buttonConsole.Text = "取消";
            this.buttonConsole.UseVisualStyleBackColor = true;
            this.buttonConsole.Click += new System.EventHandler(this.buttonConsole_Click);
            // 
            // buttonComfire
            // 
            this.buttonComfire.Location = new System.Drawing.Point(197, 313);
            this.buttonComfire.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonComfire.Name = "buttonComfire";
            this.buttonComfire.Size = new System.Drawing.Size(75, 29);
            this.buttonComfire.TabIndex = 7;
            this.buttonComfire.Text = "确定";
            this.buttonComfire.UseVisualStyleBackColor = true;
            this.buttonComfire.Click += new System.EventHandler(this.buttonComfire_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(15, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "被修改医生的：";
            // 
            // doctorName
            // 
            this.doctorName.AutoSize = true;
            this.doctorName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.doctorName.Location = new System.Drawing.Point(137, 11);
            this.doctorName.Name = "doctorName";
            this.doctorName.Size = new System.Drawing.Size(0, 20);
            this.doctorName.TabIndex = 9;
            // 
            // UpdateName
            // 
            this.UpdateName.AutoSize = true;
            this.UpdateName.Location = new System.Drawing.Point(181, 16);
            this.UpdateName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UpdateName.Name = "UpdateName";
            this.UpdateName.Size = new System.Drawing.Size(0, 15);
            this.UpdateName.TabIndex = 10;
            // 
            // FormupdateDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 386);
            this.Controls.Add(this.UpdateName);
            this.Controls.Add(this.doctorName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonComfire);
            this.Controls.Add(this.buttonConsole);
            this.Controls.Add(this.textBoxRemark);
            this.Controls.Add(this.textBoxFee);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormupdateDoctor";
            this.Text = "修改医生信息";
            this.Load += new System.EventHandler(this.FormUpdateDoctor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxFee;
        private System.Windows.Forms.TextBox textBoxRemark;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button buttonConsole;
        private System.Windows.Forms.Button buttonComfire;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label doctorName;
        private System.Windows.Forms.Label UpdateName;
    }
}