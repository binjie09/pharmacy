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

        /// <summary>
        /// 构造函数
        /// 药店的 DataSet 有几个不同的表：医生、茶方、交易记录表
        /// </summary>
        public MyData()
        { 
            // 医生表的建立：医生的姓名、诊费、备注
            // 用于保存 FormManageDoctor 中的医生信息
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

            // 茶方表的建立：茶方的名字、价格、备注
            // 用于 FormManageTeaParty 中的茶方信息
            DataColumn teaPartyNameColumn = new DataColumn("Name", typeof(string));
            DataColumn teaPartyPriceColumn = new DataColumn("Price", typeof(double));
            DataColumn teaPartyRemarkColumn = new DataColumn("Remark", typeof(string));

            DataTable teaPartyTable = new DataTable("teaParty");
            teaPartyTable.Columns.AddRange(new DataColumn[] { teaPartyNameColumn, teaPartyPriceColumn, teaPartyRemarkColumn });


            // 交易记录表的建立：交易的类型、所有者、药名、价格、诊费、管理费、包装费、代煎费、实收金额、时间、支付方式
            // 没有某一类的数据为默认值


            // 交易类型包括：中成药（PatentMedicine）、茶方（TeaParty）、医生开具药方（Doctor）
            DataColumn transactionRecordTypeColumn = new DataColumn("Type", typeof(string))
            {
                Caption = "transaction's type",
                DefaultValue = "Doctor"
            };
            // 交易的所有者：即是Doctor类型的那个医生开出的药方，默认为“无医生”
            DataColumn transactionRecordOwnerColumn = new DataColumn("Doctor", typeof(string))
            {
                Caption = "transaction's doctor",
                DefaultValue = "无医生"
            };
            // 药名，默认为空
            DataColumn transactionRecordMedicineNameColumn = new DataColumn("Name", typeof(string))
            {
                Caption = "Medicine's name",
                DefaultValue = ""
            };
            // 价格：Doctor类型为药价，其他为单价
            DataColumn transactionRecordMedicinePriceColumn = new DataColumn("Price", typeof(double))
            {
                Caption = "Medicine price",
                DefaultValue = 0.0
            };
            // 只有Doctor类型具有，默认为0
            DataColumn transactionRecordFeeColumn = new DataColumn("Fee", typeof(double))
            {
                Caption = "Doctor's fee",
                DefaultValue = 0.0
            };
            // 只有Doctor类型具有，默认为0
            DataColumn transactionRecordManagementFeeColumn = new DataColumn("ManagementFee", typeof(double))
            {
                DefaultValue = 0.0
            };
            // 只有Doctor类型具有，默认为0
            DataColumn transactionRecordPackingFeeColumn = new DataColumn("PackingFee", typeof(double))
            {
                DefaultValue = 0.0
            };
            // 只有Doctor类型具有，默认为0
            DataColumn transactionRecordReplacementFeeColumn = new DataColumn("ReplacementFee", typeof(double))
            {
                DefaultValue = 0.0
            };
            // 本次交易收取的金额
            DataColumn transactionRecordPaid_inAmountColumn = new DataColumn("Paid_inAmount", typeof(double))
            {
                Caption = "Paid-in amount",
                DefaultValue = 0.0
            };
            DataColumn transactionRecordRemarkColumn = new DataColumn("Remark", typeof(string));
            DataColumn transactionRecordDateTimeColumn = new DataColumn("DateTime", typeof(string));
            DataColumn transactionRecordPayWayColumn = new DataColumn("PayWay", typeof(string));

            DataTable transactionRecordTable = new DataTable("TransactionRecord");
            transactionRecordTable.Columns.AddRange(new DataColumn[] { transactionRecordTypeColumn, transactionRecordOwnerColumn,
                transactionRecordMedicineNameColumn, transactionRecordMedicinePriceColumn, transactionRecordFeeColumn,
                transactionRecordManagementFeeColumn, transactionRecordPackingFeeColumn, transactionRecordReplacementFeeColumn,
                transactionRecordPaid_inAmountColumn, transactionRecordRemarkColumn, transactionRecordDateTimeColumn,
                transactionRecordPayWayColumn });


            pharmacyDS.Tables.Add(doctorTable);
            pharmacyDS.Tables.Add(teaPartyTable);
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
        /// 将茶方信息插入 teaParty 中
        /// </summary>
        /// <param name="name">茶方名</param>
        /// <param name="price">单价</param>
        /// <param name="remark">备注</param>
        public static void InsertToTeaParty(string name, double price, string remark)
        {
            DataRow teapartyRow = pharmacyDS.Tables["teaParty"].NewRow();

            teapartyRow["Name"] = name;
            teapartyRow["Price"] = price;
            teapartyRow["Remark"] = remark;

            pharmacyDS.Tables["teaParty"].Rows.Add(teapartyRow);
        }

        /// <summary>
        /// 将中成药的交易信息插入到交易信息表中
        /// </summary>
        /// <param name="name">中成药名</param>
        /// <param name="price">单价</param>
        /// <param name="totalPrice">总价</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>        
        public static void InsertPatentMedicineToTR(string name, double price, double totalPrice, string payWay, string remark = "")
        {
            DataRow transactionRecordRow = null;
            string nowTime = DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月"+ DateTime.Now.Day + "日";
            transactionRecordRow = pharmacyDS.Tables["TransactionRecord"].NewRow();

            transactionRecordRow["Type"] = "PatentMedicine";
            transactionRecordRow["Name"] = name;
            transactionRecordRow["Price"] = price;
            // 不需要数量，所以不添加
            transactionRecordRow["Paid_inAmount"] = totalPrice;
            transactionRecordRow["PayWay"] = payWay;
            transactionRecordRow["DateTime"] = nowTime;
            transactionRecordRow["Remark"] = remark;

            pharmacyDS.Tables["TransactionRecord"].Rows.Add(transactionRecordRow);
        }


        /// <summary>
        /// /// 将茶方交易信息插入到交易信息表中
        /// </summary>
        /// <param name="name">茶方名</param>
        /// <param name="amount">数量</param>
        /// <param name="price"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public static void InsertToteaPartyToTR(string name, double price, double totalPrice, string payWay, string remark ="")
        {
            DataRow transactionRecordRow = null;
            string nowTime = DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day + "日";
            transactionRecordRow = pharmacyDS.Tables["TransactionRecord"].NewRow();

            transactionRecordRow["Type"] = "TeaParty";
            transactionRecordRow["Name"] = name;
            transactionRecordRow["Price"] = price;
            // 不需要数量，所以不添加
            transactionRecordRow["Paid_inAmount"] = totalPrice;
            transactionRecordRow["PayWay"] = payWay;
            transactionRecordRow["DateTime"] = nowTime;
            transactionRecordRow["Remark"] = remark;

            pharmacyDS.Tables["TransactionRecord"].Rows.Add(transactionRecordRow);
        }

        /// <summary>
        ///  /// 将医生开具的药方交易信息插入到交易记录表中中
        /// </summary>
        /// <param name="doctor">这是医生，没有医生的时候插入字符串"无医生"</param>
        /// <param name="MedicinePrice"></param>
        /// <param name="Fee"></param>
        /// <param name="ManagementFee">管理费</param>
        /// <param name="PackingFee">包装费</param>
        /// <param name="RepalcementFee">代煎费</param>
        /// <param name="Paid_inAmount">应收金额</param>
        /// <param name="payWay">支付方式 是支付宝、现金等</param>
        /// <param name="Remark"></param>
        public static void InsertDcotorToTR(string doctor, double MedicinePrice, double Fee,double ManagementFee, double PackingFee,
            double RepalcementFee, double Paid_inAmount, string payWay = "", string Remark = "")
        {
            DataRow transactionRecordRow = null;
            string nowTime = DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day + "日";
            transactionRecordRow = pharmacyDS.Tables["TransactionRecord"].NewRow();

            transactionRecordRow["Type"] = "Doctor";
            transactionRecordRow["Doctor"] = doctor;
            transactionRecordRow["Price"] = MedicinePrice;
            transactionRecordRow["Fee"] = Fee;
            transactionRecordRow["ManagementFee"] = ManagementFee;
            transactionRecordRow["PackingFee"] = PackingFee;
            transactionRecordRow["ReplacementFee"] = RepalcementFee;
            transactionRecordRow["Paid_inAmount"] = Paid_inAmount;
            transactionRecordRow["payWay"] = payWay;
            transactionRecordRow["Remark"] = Remark;
            transactionRecordRow["DateTime"] = nowTime;

            pharmacyDS.Tables["TransactionRecord"].Rows.Add(transactionRecordRow);
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
        /// <summary>
        ///  通过茶方的名字查找价格
        /// </summary>
        /// <param name="name">茶方名</param>
        /// <returns></returns>
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
