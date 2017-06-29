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
        DataSet[] ds = null; //存储
        String path = null; //存储路径

        public DataSet[] Ds { get => ds; set => ds = value; }
        public string Path { get => path; set => path = value; }

        MyData(){ //构造函数
            Ds[0] = new DataSet();//根据情况修改 看分配多少块dataset   我想的是 所有医生一个dataset 所有病人一个datesete 这样
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
