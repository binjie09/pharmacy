using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 药店报账工具
{
    class Doctor
    {
       
        private int fees;    //医生的诊费
        string name = "";    //医生的姓名
        string remarks = ""; //备注
        public Doctor(int Fees = 0, string Name = "", string Remarks = "") 
        {
            this.fees = Fees;
            this.name = Name;
            this.remarks = Remarks;

        }
        public void Update(int Fees, string name, string remarks)
        {
            this.fees = Fees;
            this.name = Name;
            this.remarks = Remarks;
        }
        public int Fees
        {
            get { return fees; }
            set { fees = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        
     
    }
}
