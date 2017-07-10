using System;
using System.Data;

namespace 药店报账工具
{
    class MyData//数据直接使用excel 存储，读入和导出都用excel
    {
        public static DataSet pharmacyDS = new DataSet("pharmacy"); //存储
        String path = null; //存储路径

        public DataSet Ds { get => pharmacyDS; set => pharmacyDS = value; }
        public string Path { get => path; set => path = value; }

        public MyData()
        { //构造函数
          // 药店的 DataSet 有几个不同的表：医生、中成药、茶方  

            // 和医生表的建立：医生的姓名、诊费、备注
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


            // 中成药表的建立：中成药的数量、总价、备注
            DataColumn patentMedicineAmountColumn = new DataColumn("Amount", typeof(int))
            {
                Caption = "Medicne's amount"
            };
            DataColumn patentMedicineTotalPriceColumn = new DataColumn("TotalPrice", typeof(double))
            {
                Caption = "Medicine's total price"
            };
            DataColumn patentMedicineRemarkColumn = new DataColumn("Remark", typeof(string))
            {
                Caption = "Medicine remark"
            };

            DataTable patentMedicineTable = new DataTable("ChinesePatentMedicine");
            patentMedicineTable.Columns.AddRange(new DataColumn[] { patentMedicineAmountColumn, patentMedicineTotalPriceColumn, patentMedicineRemarkColumn });


            // 茶方表的建立：茶方的数量、总价、备注
            DataColumn teaPartyAmountColumn = new DataColumn("Amount", typeof(int))
            {
                Caption= "Tea's amount"
            };
            DataColumn teaPartyTotalPriceColumn = new DataColumn("TotalPrice", typeof(double))
            {
                Caption = "Tea's total price"
            };
            DataColumn teaPartyRemarkColumn = new DataColumn("Remark", typeof(string))
            {
                Caption = "Tea's remark"
            };

            DataTable teaPartyTable = new DataTable("teaParty");
            teaPartyTable.Columns.AddRange(new DataColumn[] { teaPartyAmountColumn, teaPartyTotalPriceColumn, teaPartyRemarkColumn });


            // 交易记录表的建立：交易的所有者、药价、管理费、包装费、代煎费、实收金额、时间、支付方式
            DataColumn transactionRecordOwnerColumn = new DataColumn("Owner", typeof(string))
            {
                Caption = "transaction's owner"
            };
            DataColumn transactionRecordMedicinePriceColumn = new DataColumn("Price", typeof(double))
            {
                Caption = "Medicine price"
            };
            DataColumn transactionRecordManagementFeeColumn = new DataColumn("ManagementFee", typeof(double));
            DataColumn transactionRecordPackingFeeColumn = new DataColumn("PackingFee", typeof(double));
            DataColumn transactionRecordReplacementFeeColumn = new DataColumn("ReplacementFee", typeof(double));
            DataColumn transactionRecordPaid_inAmountColumn = new DataColumn("Paid_inAmount", typeof(double))
            {
                Caption = "Paid-in amount"
            };
            DataColumn transactionRecordRemarkColumn = new DataColumn("Remark", typeof(string));
            DataColumn transactionRecordDateTimeColumn = new DataColumn("DateTime", typeof(DateTime));
            DataColumn transactionRecordPayWayColumn = new DataColumn("PayWay", typeof(string));

            DataTable transactionRecordTable = new DataTable("TransactionRecord");
            transactionRecordTable.Columns.AddRange(new DataColumn[] { transactionRecordOwnerColumn, transactionRecordMedicinePriceColumn,
                transactionRecordManagementFeeColumn, transactionRecordPackingFeeColumn, transactionRecordReplacementFeeColumn,
                transactionRecordPaid_inAmountColumn, transactionRecordRemarkColumn, transactionRecordDateTimeColumn, transactionRecordPayWayColumn});


            pharmacyDS.Tables.Add(doctorTable);
            pharmacyDS.Tables.Add(patentMedicineTable);
            pharmacyDS.Tables.Add(teaPartyTable);
            pharmacyDS.Tables.Add(transactionRecordTable);
        }
        // 将信息插入到 doctor 这张表中
        public static void InsertToDoctor(string name, double fee, string remark = "") 
        {
            DataRow doctorRow = pharmacyDS.Tables["Doctor"].NewRow();

            doctorRow["Name"] = name;
            doctorRow["Free"] = fee;
            doctorRow["Remark"] = remark;

            pharmacyDS.Tables["Doctor"].Rows.Add(doctorRow);
        }
        // 插入到 patentMedicine 中
        public static void InsertToPatentMedicine(int amount, double price, string remark = "")
        {
            DataRow patentMedicineRow = pharmacyDS.Tables["ChinesePatentMedicine"].NewRow();

            patentMedicineRow["Amount"] = amount;
            patentMedicineRow["TotalPrice"] = price;
            patentMedicineRow["Remark"] = remark;

            pharmacyDS.Tables["ChinesePatentMedicine"].Rows.Add(patentMedicineRow);
        }
        // 插入到 teaParty 中
        public static void InsertToTeaParty(int amount, double price, string remark ="")
        {
            DataRow teaPartyRow = pharmacyDS.Tables["teaParty"].NewRow();

            teaPartyRow["Amount"] = amount;
            teaPartyRow["TotalPrice"] = price;
            teaPartyRow["Remark"] = remark;

            pharmacyDS.Tables["teaParty"].Rows.Add(teaPartyRow);
        }

        // 将信息插入到 transactionRecord 中
        public static void InsertToTransactionRecord(string owner, double MedicinePrice, double ManagementFee, double PackingFee,
            double RepalcementFee, double Paid_inAmount, string payWay = "", string Remark = "")
        {
            DataRow transactionRecordRow = null;
            transactionRecordRow = pharmacyDS.Tables["TransactionRecord"].NewRow();

            transactionRecordRow["Owner"] = owner;
            transactionRecordRow["Price"] = MedicinePrice;
            transactionRecordRow["ManagementFee"] = ManagementFee;
            transactionRecordRow["PackingFee"] = PackingFee;
            transactionRecordRow["ReplacementFee"] = RepalcementFee;
            transactionRecordRow["Paid_inAmount"] = Paid_inAmount;
            transactionRecordRow["payWay"] = payWay;
            transactionRecordRow["Remark"] = Remark;

            transactionRecordRow["DateTime"] = DateTime.Now;
        }

        public int GetDoctorFeesByName(string name)//通过医生的名字获取诊费
        {
            
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
