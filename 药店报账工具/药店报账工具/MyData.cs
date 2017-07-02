using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 药店报账工具
{
    class MyData//数据直接使用excel 存储，读入和导出都用excel
    {
        DataSet pharmacyDS = null; //存储
        String path = null; //存储路径

        public DataSet Ds { get => pharmacyDS; set => pharmacyDS = value; }
        public string Path { get => path; set => path = value; }

        public MyData(){ //构造函数
                         // 药店的 DataSet 有几个不同的表：医生、中成药、茶方

            // 和医生有关的表的建立
            DataColumn doctorNameColumn = new DataColumn("DoctorName", typeof(string));
            doctorNameColumn.Caption = "Doctor Name";
            DataColumn doctorFreeColumn = new DataColumn("DoctorFree", typeof(double));
            doctorFreeColumn.Caption = "Doctor's free";
            DataColumn totalCostColumn = new DataColumn("TotalCost", typeof(double));
            totalCostColumn.Caption = "Total Drug Cost";
            DataColumn dateTimeColumn = new DataColumn("DateTime", typeof(DateTime));
             
            DataTable doctorTable = new DataTable("Doctor");
            doctorTable.Columns.AddRange(new DataColumn[] { doctorNameColumn, doctorFreeColumn, totalCostColumn,
            dateTimeColumn});

            
            // 中成药表的建立
            DataColumn patentMedicineAmountColumn = new DataColumn("Amount", typeof(int));
            DataColumn patnetMedicineTotalPriceColumn = new DataColumn("totalPrice", typeof(double));
            patnetMedicineTotalPriceColumn.Caption = "Total Price";

            DataTable patentMedicineTable = new DataTable("Chinese patent medicine");
            patentMedicineTable = new DataTable("patentMedicine");
            patentMedicineTable.Columns.AddRange(new DataColumn[] { patentMedicineAmountColumn, patnetMedicineTotalPriceColumn });


            // 茶方表的建立
            DataColumn teaPartyAmountColumn = new DataColumn("Amount", typeof(int));
            DataColumn teaPartyTotalPriceColumn = new DataColumn("totalPrice", typeof(double));
            patnetMedicineTotalPriceColumn.Caption = "Total Price";

            DataTable teaPartyTable = new DataTable("Chinese patent medicine");
            patentMedicineTable = new DataTable("patentMedicine");
            patentMedicineTable.Columns.AddRange(new DataColumn[] { patentMedicineAmountColumn, patnetMedicineTotalPriceColumn });

            pharmacyDS.Tables.Add(doctorTable);
            pharmacyDS.Tables.Add(patentMedicineTable);
            pharmacyDS.Tables.Add(teaPartyTable);



        }
       int Save(string type)//根据数据类型保存数据,type可以是医生，病人，打印的票据 等 有几种type就应该有几种保存的文件  成功保存返回0 否则返回-1
        {
            return 0;
        }
        int Load(string type ) //情况同save  
        {
            return 0;
        }

    }
}
