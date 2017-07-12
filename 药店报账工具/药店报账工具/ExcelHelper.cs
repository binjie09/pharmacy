using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.POIFS.FileSystem;

using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;


namespace 药店报账工具
{
    public class ExcelHelper
    {
        public class x2003
        {
            /// <summary>
            /// 将DataTable数据导出到Excel文件中(xls)
            /// </summary>
            /// <param name="rows"></param>
            /// <param name="file"></param>
            /// <param name="month"></param>
            public static void TableToExcelForXLS(DataRow rows, string file, string month)
            {
                try
                {
                    FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite); //读取流
                    POIFSFileSystem ps = new POIFSFileSystem(fs);
                    IWorkbook workbook = new HSSFWorkbook(ps);
                    ISheet sheet = workbook.GetSheet(month);
                    IRow row;

                    if (sheet == null)
                    {
                        sheet = workbook.CreateSheet(month);
                        // 创建表头
                        row = sheet.CreateRow(0);//得到表头
                        for (int i = 0; i < MyData.pharmacyDS.Tables["TransactionRecord"].Columns.Count; i++)
                        {
                            ICell cell = row.CreateCell(i);
                            cell.SetCellValue(MyData.pharmacyDS.Tables["TransactionRecord"].Columns[i].ColumnName);
                        }
                    }
                    FileStream fout = new FileStream(file, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                    //row = sheet.CreateRow((sheet.LastRowNum + 1));//在工作表中添加一行
                    // 在最后一行插入数据
                    IRow row1 = sheet.CreateRow(sheet.LastRowNum + 1);
                    for (int j = 0; j < 10; j++)
                    {
                        ICell cell = row1.CreateCell(j);
                        cell.SetCellValue(rows[j].ToString());
                    }

                    fout.Flush();
                    workbook.Write(fout);//写入文件
                    workbook = null;
                    fout.Close();
                }
                catch(Exception e)
                {

                }
                
            }

      
            /// <summary>
            /// 获取单元格类型(xls)
            /// </summary>
            /// <param name="cell"></param>
            /// <returns></returns>
            private static object GetValueTypeForXLS(HSSFCell cell)
            {
                if (cell == null)
                    return null;
                switch (cell.CellType)
                {
                    case CellType.Blank: //BLANK:
                        return null;
                    case CellType.Boolean: //BOOLEAN:
                        return cell.BooleanCellValue;
                    case CellType.Numeric: //NUMERIC:
                        return cell.NumericCellValue;
                    case CellType.String: //STRING:
                        return cell.StringCellValue;
                    case CellType.Error: //ERROR:
                        return cell.ErrorCellValue;
                    case CellType.Formula: //FORMULA:
                    default:
                        return "=" + cell.CellFormula;
                }
            }
        }

        public class x2007
        {
            #region Excel2007
            /// <summary>
            /// 将Excel文件中的数据读出到DataTable中(xlsx)
            /// </summary>
            /// <param name="file"></param>
            /// <returns></returns>
            public static DataTable ExcelToTableForXLSX(string file)
            {
                DataTable dt = new DataTable();
                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    XSSFWorkbook xssfworkbook = new XSSFWorkbook(fs);
                    ISheet sheet = xssfworkbook.GetSheetAt(0);

                    //表头
                    IRow header = sheet.GetRow(sheet.FirstRowNum);
                    List<int> columns = new List<int>();
                    for (int i = 0; i < header.LastCellNum; i++)
                    {
                        object obj = GetValueTypeForXLSX(header.GetCell(i) as XSSFCell);
                        if (obj == null || obj.ToString() == string.Empty)
                        {
                            dt.Columns.Add(new DataColumn("Columns" + i.ToString()));
                            //continue;
                        }
                        else
                            dt.Columns.Add(new DataColumn(obj.ToString()));
                        columns.Add(i);
                    }
                    //数据
                    for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                    {
                        DataRow dr = dt.NewRow();
                        bool hasValue = false;
                        foreach (int j in columns)
                        {
                            dr[j] = GetValueTypeForXLSX(sheet.GetRow(i).GetCell(j) as XSSFCell);
                            if (dr[j] != null && dr[j].ToString() != string.Empty)
                            {
                                hasValue = true;
                            }
                        }
                        if (hasValue)
                        {
                            dt.Rows.Add(dr);
                        }
                    }
                }
                return dt;
            }

            /// <summary>
            /// 将DataTable数据导出到Excel文件中(xlsx)
            /// </summary>
            /// <param name="dt"></param>
            /// <param name="file"></param>
            public static void TableToExcelForXLSX(DataTable dt, string file)
            {
                XSSFWorkbook xssfworkbook = new XSSFWorkbook();
                ISheet sheet = xssfworkbook.CreateSheet("Test");

                //表头
                IRow row = sheet.CreateRow(0);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ICell cell = row.CreateCell(i);
                    cell.SetCellValue(dt.Columns[i].ColumnName);
                }

                //数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow row1 = sheet.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ICell cell = row1.CreateCell(j);
                        cell.SetCellValue(dt.Rows[i][j].ToString());
                    }
                }

                //转为字节数组
                MemoryStream stream = new MemoryStream();
                xssfworkbook.Write(stream);
                var buf = stream.ToArray();

                //保存为Excel文件
                using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(buf, 0, buf.Length);
                    fs.Flush();
                }
            }

            /// <summary>
            /// 获取单元格类型(xlsx)
            /// </summary>
            /// <param name="cell"></param>
            /// <returns></returns>
            private static object GetValueTypeForXLSX(XSSFCell cell)
            {
                if (cell == null)
                    return null;
                switch (cell.CellType)
                {
                    case CellType.Blank: //BLANK:
                        return null;
                    case CellType.Boolean: //BOOLEAN:
                        return cell.BooleanCellValue;
                    case CellType.Numeric: //NUMERIC:
                        return cell.NumericCellValue;
                    case CellType.String: //STRING:
                        return cell.StringCellValue;
                    case CellType.Error: //ERROR:
                        return cell.ErrorCellValue;
                    case CellType.Formula: //FORMULA:
                    default:
                        return "=" + cell.CellFormula;
                }
            }
            #endregion
        }
        class DataTableRenderToExcel
        {
            public static Stream RenderDataTableToExcel(DataTable SourceTable)
            {
                HSSFWorkbook workbook = new HSSFWorkbook();
                MemoryStream ms = new MemoryStream();
                HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet();
                HSSFRow headerRow = (HSSFRow)sheet.CreateRow(0);

                // handling header. 
                foreach (DataColumn column in SourceTable.Columns)
                    headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

                // handling value. 
                int rowIndex = 1;

                foreach (DataRow row in SourceTable.Rows)
                {
                    HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);

                    foreach (DataColumn column in SourceTable.Columns)
                    {
                        dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                    }

                    rowIndex++;
                }

                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                sheet = null;
                headerRow = null;
                workbook = null;

                return ms;
            }

            public static void RenderDataTableToExcel(DataTable SourceTable, string FileName)
            {
                MemoryStream ms = RenderDataTableToExcel(SourceTable) as MemoryStream;
                FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
                byte[] data = ms.ToArray();

                fs.Write(data, 0, data.Length);
                fs.Flush();
                fs.Close();

                data = null;
                ms = null;
                fs = null;
            }

            public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, string SheetName, int HeaderRowIndex)
            {
                HSSFWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
                HSSFSheet sheet = (HSSFSheet)workbook.GetSheet(SheetName);

                DataTable table = new DataTable();

                HSSFRow headerRow = (HSSFRow)sheet.GetRow(HeaderRowIndex);
                int cellCount = headerRow.LastCellNum;

                for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                {
                    DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                    table.Columns.Add(column);
                }

                int rowCount = sheet.LastRowNum;

                for (int i = (sheet.FirstRowNum + 1); i < sheet.LastRowNum; i++)
                {
                    HSSFRow row = (HSSFRow)sheet.GetRow(i);
                    DataRow dataRow = table.NewRow();

                    for (int j = row.FirstCellNum; j < cellCount; j++)
                        dataRow[j] = row.GetCell(j).ToString();
                }

                ExcelFileStream.Close();
                workbook = null;
                sheet = null;
                return table;
            }

            public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, int SheetIndex, int HeaderRowIndex)
            {
                HSSFWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
                HSSFSheet sheet = (HSSFSheet)workbook.GetSheetAt(SheetIndex);

                DataTable table = new DataTable();

                HSSFRow headerRow = (HSSFRow)sheet.GetRow(HeaderRowIndex);
                int cellCount = headerRow.LastCellNum;

                for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                {
                    DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                    table.Columns.Add(column);
                }

                int rowCount = sheet.LastRowNum;

                for (int i = (sheet.FirstRowNum + 1); i < sheet.LastRowNum; i++)
                {
                    HSSFRow row = (HSSFRow)sheet.GetRow(i);
                    DataRow dataRow = table.NewRow();

                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                            dataRow[j] = row.GetCell(j).ToString();
                    }

                    table.Rows.Add(dataRow);
                }

                ExcelFileStream.Close();
                workbook = null;
                sheet = null;
                return table;
            }
        }
        public static DataTable GetDataTable(string filepath)
        {
            var dt = new DataTable("xls");
            if (filepath.Last() == 's')
            {
                //dt = x2003.ExcelToTableForXLS(filepath);
            }
            else
            {
                dt = x2007.ExcelToTableForXLSX(filepath);
            }
            return dt;
        }
    }


}
