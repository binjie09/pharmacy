using System;
using System.Data;
using System.IO;

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








            // 中成药交易记录表的建立：中成药的名字、数量、总价、日期、备注
            DataColumn patentMedicineNameColumn = new DataColumn("Name", typeof(string))
            {
                Caption = "Medicne's name"
            };
            DataColumn patentMedicineAmountColumn = new DataColumn("Amount", typeof(double))
            {
                Caption = "Medicne's amount"
            };
            DataColumn patentMedicineTotalPriceColumn = new DataColumn("TotalPrice", typeof(double))
            {
                Caption = "Medicine's total price"
            };
            DataColumn patentMedicineDateTimeColumn = new DataColumn("DateTime", typeof(DateTime));
            DataColumn patentMedicineRemarkColumn = new DataColumn("Remark", typeof(string))
            {
                Caption = "Medicine remark"
            };

            DataTable patentMedicineTable = new DataTable("ChinesePatentMedicineRT");
            patentMedicineTable.Columns.AddRange(new DataColumn[] { patentMedicineNameColumn, patentMedicineAmountColumn,
                patentMedicineTotalPriceColumn, patentMedicineDateTimeColumn, patentMedicineRemarkColumn });

            // 茶方表的建立：茶方的名字、价格、备注
            DataColumn teaPartyNameColumn = new DataColumn("Name", typeof(string));
            DataColumn teaPartyPriceColumn = new DataColumn("Price", typeof(double));
            DataColumn teaPartyRemarkColumn = new DataColumn("Remark", typeof(string));

            DataTable teaPartyTable = new DataTable("teaParty");
            teaPartyTable.Columns.AddRange(new DataColumn[] { teaPartyNameColumn, teaPartyPriceColumn, teaPartyRemarkColumn });

            // 茶方交易记录表的建立：茶方的名字、数量、总价、日期、备注
            DataColumn teaPartyRTNameColumn = new DataColumn("Name", typeof(string))
            {
                Caption = "Tea's name"
            };
            DataColumn teaPartyRTAmountColumn = new DataColumn("Amount", typeof(double))
            {
                Caption= "Tea's amount"
            };
            DataColumn teaPartyRTTotalPriceColumn = new DataColumn("TotalPrice", typeof(double))
            {
                Caption = "Tea's total price"
            };
            DataColumn teaPartyRTDateTimeColumn = new DataColumn("DateTime", typeof(DateTime));
            DataColumn teaPartyRTRemarkColumn = new DataColumn("Remark", typeof(string))
            {
                Caption = "Tea's remark"
            };

            DataTable teaPartyRTTable = new DataTable("teaPartyRT");
            teaPartyRTTable.Columns.AddRange(new DataColumn[] { teaPartyRTNameColumn, teaPartyRTAmountColumn,
                teaPartyRTTotalPriceColumn, teaPartyRTDateTimeColumn, teaPartyRTRemarkColumn });


            // 交易记录表的建立：交易的所有者、药价、诊费、管理费、包装费、代煎费、实收金额、时间、支付方式
            DataColumn transactionRecordOwnerColumn = new DataColumn("Owner", typeof(string))
            {
                Caption = "transaction's owner"
            };
            DataColumn transactionRecordMedicinePriceColumn = new DataColumn("Price", typeof(double))
            {
                Caption = "Medicine price"
            };
            DataColumn transactionRecordFeeColumn = new DataColumn("Fee", typeof(double))
            {
                Caption = "Doctor's fee"
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
                transactionRecordFeeColumn, transactionRecordManagementFeeColumn, transactionRecordPackingFeeColumn, transactionRecordReplacementFeeColumn,
                transactionRecordPaid_inAmountColumn, transactionRecordRemarkColumn, transactionRecordDateTimeColumn, transactionRecordPayWayColumn});


            pharmacyDS.Tables.Add(doctorTable);
            pharmacyDS.Tables.Add(patentMedicineTable);
            pharmacyDS.Tables.Add(teaPartyTable);
            pharmacyDS.Tables.Add(teaPartyRTTable);
            pharmacyDS.Tables.Add(transactionRecordTable);
            Load("open");
        }
        /// <summary>
        /// 将信息插入到 doctor 这张表中
        /// </summary>
        /// <param name="name">医生的名字</param>
        /// <param name="fee"></param>
        /// <param name="remark"></param>        
        public static void InsertToDoctor(string name, double fee, string remark = "") 
        {
            DataRow doctorRow = pharmacyDS.Tables["Doctor"].NewRow();

            doctorRow["Name"] = name;
            doctorRow["Free"] = fee;
            doctorRow["Remark"] = remark;

            pharmacyDS.Tables["Doctor"].Rows.Add(doctorRow);
        }

        /// <summary>
        /// 插入到 patentMedicine 中
        /// </summary>
        /// <param name="name">茶方名</param>
        /// <param name="amount"></param>
        /// <param name="price"></param>
        /// <param name="remark"></param>
        /// <returns></returns>        
        public static DateTime InsertToPatentMedicine(string name, double amount, double price, string remark = "")
        {
            DataRow patentMedicineRow = pharmacyDS.Tables["ChinesePatentMedicineRT"].NewRow();
            DateTime retDT = DateTime.Now;

            patentMedicineRow["Name"] = name;
            patentMedicineRow["Amount"] = amount;
            patentMedicineRow["TotalPrice"] = price;
            patentMedicineRow["DateTime"] = retDT;
            patentMedicineRow["Remark"] = remark;

            pharmacyDS.Tables["ChinesePatentMedicineRT"].Rows.Add(patentMedicineRow);

            return retDT;
           
        }
        public static void InsertToTeaParty(string name, double price, string remark)
        {
            DataRow teapartyRow = pharmacyDS.Tables["teaParty"].NewRow();

            teapartyRow["Name"] = name;
            teapartyRow["Price"] = price;
            teapartyRow["Remark"] = remark;

            pharmacyDS.Tables["teaParty"].Rows.Add(teapartyRow);
        }

        /// <summary>
        /// /// 将信息插入到茶方交易记录表中
        /// </summary>
        /// <param name="name">茶方</param>
        /// <param name="amount"></param>
        /// <param name="price"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public static DateTime InsertToteaPartyRT(string name, double amount, double price, string remark ="")
        {
            DataRow teaPartyRTRow = pharmacyDS.Tables["teaPartyRT"].NewRow();
            DateTime retDT = DateTime.Now;

            teaPartyRTRow["Name"] = name;
            teaPartyRTRow["Amount"] = amount;
            teaPartyRTRow["TotalPrice"] = price;
            teaPartyRTRow["DateTime"] = retDT;
            teaPartyRTRow["Remark"] = remark;

            pharmacyDS.Tables["teaPartyRT"].Rows.Add(teaPartyRTRow);

            return retDT;
        }

        /// <summary>
        ///  /// 将信息插入到 transactionRecord 中
        /// </summary>
        /// <param name="owner">这是医生，没有医生的时候插入字符串"无医生"</param>
        /// <param name="MedicinePrice"></param>
        /// <param name="Fee"></param>
        /// <param name="ManagementFee"></param>
        /// <param name="PackingFee"></param>
        /// <param name="RepalcementFee"></param>
        /// <param name="Paid_inAmount"></param>
        /// <param name="payWay">支付方式 是支付宝、现金等</param>
        /// <param name="Remark"></param>
        public static DateTime InsertToTransactionRecord(string owner, double MedicinePrice, double Fee,double ManagementFee, double PackingFee,
            double RepalcementFee, double Paid_inAmount, string payWay = "", string Remark = "")
        {
            DataRow transactionRecordRow = null;
            DateTime retTime = DateTime.Now;
            transactionRecordRow = pharmacyDS.Tables["TransactionRecord"].NewRow();

            transactionRecordRow["Owner"] = owner;
            transactionRecordRow["Price"] = MedicinePrice;
            transactionRecordRow["Fee"] = Fee;
            transactionRecordRow["ManagementFee"] = ManagementFee;
            transactionRecordRow["PackingFee"] = PackingFee;
            transactionRecordRow["ReplacementFee"] = RepalcementFee;
            transactionRecordRow["Paid_inAmount"] = Paid_inAmount;
            transactionRecordRow["payWay"] = payWay;
            transactionRecordRow["Remark"] = Remark;
            transactionRecordRow["DateTime"] = retTime;

            pharmacyDS.Tables["TransactionRecord"].Rows.Add(transactionRecordRow);

            return retTime;


        }
        /// <summary>
        /// 通过医生的名字获取诊费
        /// </summary>
        /// <param name="name">医生姓名</param>
        /// <returns></returns>
        public double GetDoctorFeesByName(string name)
        {
            DataTable dt = Ds.Tables["Doctor"];
              DataRow[] drArr = dt.Select("Name='"+ name + "'");
            DataRow dw = null;
            if (drArr.Length != 0)
            {
                dw = (DataRow)drArr.GetValue(0);
                return (double)dw[1];
            }
            else
                return 0;
        }
        public static double GetTeaPriceByName(string name)
        {
            DataTable dt = pharmacyDS.Tables["teaParty"];
            DataRow[] drArr = dt.Select("Name='" + name + "'");
            DataRow dw = null;
            if (drArr.Length != 0)
            {
                dw = (DataRow)drArr.GetValue(0);
                return (double)dw[1];
            }
            else
                return 0;
        }
        public static int Save(string type)
        {
            pharmacyDS.WriteXml(@".\info.xml");
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int Load(string type ) //情况同save  
        {
            if(File.Exists(@".\info.xml"))
                 pharmacyDS.ReadXml(@".\info.xml");
            return 0;
        }

    }
}
