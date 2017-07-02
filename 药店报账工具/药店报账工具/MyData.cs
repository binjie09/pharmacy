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
        static DataSet pharmacyDS = new DataSet("pharmacy"); //存储
        String path = null; //存储路径

        public DataSet Ds { get => pharmacyDS; set => pharmacyDS = value; }
        public string Path { get => path; set => path = value; }

        public MyData(){ //构造函数
                         // 药店的 DataSet 有几个不同的表：医生、中成药、茶方

            // 和医生表的建立
            DataColumn doctorNameColumn = new DataColumn("Name", typeof(string));
            doctorNameColumn.Caption = "Doctor Name";
            DataColumn doctorFreeColumn = new DataColumn("Free", typeof(double));
            doctorFreeColumn.Caption = "Doctor's free";
            DataColumn doctorRemarkColumn = new DataColumn("Remark", typeof(string));


            DataTable doctorTable = new DataTable("Doctor");
            doctorTable.Columns.AddRange(new DataColumn[] { doctorNameColumn, doctorFreeColumn, doctorRemarkColumn });

            
            // 中成药表的建立
            DataColumn patentMedicineAmountColumn = new DataColumn("Amount", typeof(int));
            DataColumn patnetMedicineTotalPriceColumn = new DataColumn("totalPrice", typeof(double));
            patnetMedicineTotalPriceColumn.Caption = "Total Price";

            DataTable patentMedicineTable = new DataTable("ChinesePatentMedicine");
            patentMedicineTable.Columns.AddRange(new DataColumn[] { patentMedicineAmountColumn, patnetMedicineTotalPriceColumn });


            // 茶方表的建立
            DataColumn teaPartyAmountColumn = new DataColumn("Amount", typeof(int));
            DataColumn teaPartyTotalPriceColumn = new DataColumn("totalPrice", typeof(double));
            patnetMedicineTotalPriceColumn.Caption = "Total Price";

            DataTable teaPartyTable = new DataTable("teaParty");
            patentMedicineTable.Columns.AddRange(new DataColumn[] { patentMedicineAmountColumn, patnetMedicineTotalPriceColumn });

            pharmacyDS.Tables.Add(doctorTable);
            pharmacyDS.Tables.Add(patentMedicineTable);
            pharmacyDS.Tables.Add(teaPartyTable);

            
        }
        // 将信息插入到 doctor 这张表中
        public static void insertToDoctor(string name, double free, string remark)
        {
            DataRow doctorRow = pharmacyDS.Tables["Doctor"].NewRow();
            doctorRow["Name"] = name;
            doctorRow["Free"] = free;
            doctorRow["remark"] = remark;

            pharmacyDS.Tables["Doctor"].Rows.Add(doctorRow);
        }
        // 插入到 patentMedicine 中
        public static void insertToPatentMedicine(int amount, double price)
        {
            DataRow patentMedicineRow = pharmacyDS.Tables["ChinesePatentMedicine"].NewRow();
            patentMedicineRow["Amount"] = amount;
            patentMedicineRow["totalPrice"] = price;
            pharmacyDS.Tables["ChinesePatentMedicine"].Rows.Add(patentMedicineRow);
        }
        // 插入到 teaParty 中
        public static void insertToTeaParty(int amount, double price)
        {
            DataRow teaPartyRow = pharmacyDS.Tables["teaParty"].NewRow();
            teaPartyRow["Amount"] = amount;
            teaPartyRow["totalPrice"] = price;
            pharmacyDS.Tables["teaParty"].Rows.Add(teaPartyRow);
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
