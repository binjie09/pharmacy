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
        public static DataSet pharmacyDS = new DataSet("pharmacy"); //存储
        String path = null; //存储路径

        public DataSet Ds { get => pharmacyDS; set => pharmacyDS = value; }
        public string Path { get => path; set => path = value; }

        public MyData(){ //构造函数
                         // 药店的 DataSet 有几个不同的表：医生、中成药、茶方  

            // 和医生表的建立
            DataColumn doctorNameColumn = new DataColumn("Name", typeof(string))
            {
                Caption = "Doctor Name"
            };
            DataColumn doctorFreeColumn = new DataColumn("Free", typeof(double))
            {
                Caption = "Doctor's free"
            };
            DataColumn doctorRemarkColumn = new DataColumn("Remark", typeof(string))
            {
                Caption = "Doctor's remark"
            };

            DataTable doctorTable = new DataTable("Doctor");
            doctorTable.Columns.AddRange(new DataColumn[] { doctorNameColumn, doctorFreeColumn, doctorRemarkColumn });

            
            // 中成药表的建立
            DataColumn patentMedicineAmountColumn = new DataColumn("AmountMedicine", typeof(int));
            DataColumn patnetMedicineTotalPriceColumn = new DataColumn("totalPriceMedicine", typeof(double))
            {
                Caption = "Total Price"
            };
            DataTable patentMedicineTable = new DataTable("ChinesePatentMedicine");
            patentMedicineTable.Columns.AddRange(new DataColumn[] { patentMedicineAmountColumn, patnetMedicineTotalPriceColumn });


            // 茶方表的建立
            DataColumn teaPartyAmountColumn = new DataColumn("AmountTea", typeof(int));
            DataColumn teaPartyTotalPriceColumn = new DataColumn("totalPriceTea", typeof(double));
            patnetMedicineTotalPriceColumn.Caption = "Total Price";

            DataTable teaPartyTable = new DataTable("teaParty");
            patentMedicineTable.Columns.AddRange(new DataColumn[] { teaPartyAmountColumn, teaPartyTotalPriceColumn });//都不检查下能不能运行的吗 。。。。

            pharmacyDS.Tables.Add(doctorTable);
            pharmacyDS.Tables.Add(patentMedicineTable);
            pharmacyDS.Tables.Add(teaPartyTable);

            
        }
        // 将信息插入到 doctor 这张表中   （注意方法命名规范，这是java 方法首字母大写！）
        public static void InsertToDoctor(string name, double fee, string remark) 
        {
            DataRow doctorRow = pharmacyDS.Tables["Doctor"].NewRow();
            doctorRow["Name"] = name;
            doctorRow["Free"] = fee;
            doctorRow["remark"] = remark;

            pharmacyDS.Tables["Doctor"].Rows.Add(doctorRow);
        }
        // 插入到 patentMedicine 中
        public static void InsertToPatentMedicine(int amount, double price)
        {
            DataRow patentMedicineRow = pharmacyDS.Tables["ChinesePatentMedicine"].NewRow();
            patentMedicineRow["Amount"] = amount;
            patentMedicineRow["totalPrice"] = price;
            pharmacyDS.Tables["ChinesePatentMedicine"].Rows.Add(patentMedicineRow);
        }
        // 插入到 teaParty 中
        public static void InsertToTeaParty(int amount, double price)
        {
            DataRow teaPartyRow = pharmacyDS.Tables["teaParty"].NewRow();
            teaPartyRow["Amount"] = amount;
            teaPartyRow["totalPrice"] = price;
            pharmacyDS.Tables["teaParty"].Rows.Add(teaPartyRow);
        }
        public int GetDoctorFeesByName(string name)//通过医生的名字获取诊费
        {
            //pharmacyDS.Tables["Doctor"]
            return 0;
        }
        public static int Save(string type)//根据数据类型保存数据,type可以是医生，病人，打印的票据 等 有几种type就应该有几种保存的文件  成功保存返回0 否则返回-1
        {
            MyUtil.DSToExcel("c:/pharmacy/sav.xls", pharmacyDS);
            return 0;
        }
        public static int Load(string type ) //情况同save  
        {
            pharmacyDS = MyUtil.ExcelToDS("c:/pharmacy/sav.xls");
            return 0;
        }

    }
}
