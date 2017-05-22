using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.IO;
using System.Text;

/// <summary>
/// ExcelExporter 的摘要说明
/// </summary>
public class ExcelExporter 
      { 
          private DataSet _dataSet = null; 
          /// <summary> 
          /// 要导出的DataSet 
          /// </summary> 
          public DataSet DataSet 
          { 
              get { return _dataSet; } 
          } 
          /// <summary> 
          /// 构造一个ExcelExporter 
          /// </summary> 
          public ExcelExporter() 
          { 
              _dataSet = new DataSet(); 
          } 
          /// <summary> 
          /// 构造一个ExcelExporter 
          /// </summary> 
          /// <param name="dataSet">要导出的DataSet</param> 
          public ExcelExporter(DataSet dataSet) 
          { 
              _dataSet = dataSet; 
          } 
          /// <summary> 
          /// 生成Excel文件 
          /// </summary> 
          /// <param name="fileName">文件名</param> 
          public void Export(string fileName) 
          { 
              if (fileName == null) 
              { 
                  throw new NullReferenceException("fileName"); 
              } 
              string excelXML = CreateExcelXML(_dataSet); 
              StreamWriter streamWriter = new StreamWriter(fileName, false, Encoding.Unicode); 
              streamWriter.Write(excelXML.ToString()); 
              streamWriter.Close(); 
          } 
          /// <summary> 
          /// 生成Excel文件 
          /// </summary> 
          /// <param name="stream">流</param> 
          public void Export(Stream stream) 
          { 
              if (stream == null) 
              { 
                  throw new NullReferenceException("stream"); 
              } 
              string excelXML = CreateExcelXML(_dataSet); 
              StreamWriter streamWriter = new StreamWriter(stream, Encoding.Unicode); 
              streamWriter.Write(excelXML.ToString()); 
              streamWriter.Close(); 
          } 
          private string CreateExcelXML(DataSet dataSet) 
          { 
              if (dataSet == null) 
              { 
                  throw new NullReferenceException("dataSet"); 
              } 
              if (dataSet.Tables.Count == 0) 
              { 
                  throw new InvalidOperationException("DataSet中至少要包含一个DataTable。"); 
              } 
              StringBuilder excelXML = new StringBuilder(); 
              // XML头 
              excelXML.AppendLine("<?xml version=\"1.0\"?>"); 
              // 工作簿 
              excelXML.AppendLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\" xmlns:html=\"http://www.w3.org/TR/REC-html40\">"); 
              // 工作表 
              foreach (DataTable dataTable in dataSet.Tables) 
              { 
                  excelXML.Append("\t"); 
                  excelXML.AppendLine("<Worksheet ss:Name=\"" + TextToXML(dataTable.TableName) + "\">"); 
                  excelXML.Append("\t\t"); 
                  excelXML.AppendLine("<Table>"); 
                  // 表头 
                  excelXML.Append("\t\t\t"); 
                  excelXML.AppendLine("<Row>"); 
                  foreach (DataColumn dataColumn in dataTable.Columns) 
                  { 
                      excelXML.Append("\t\t\t\t"); 
                      excelXML.AppendLine("<Cell>"); 
                      excelXML.Append("\t\t\t\t\t"); 
                      excelXML.AppendLine("<Data ss:Type=\"String\">" + TextToXML(dataColumn.ColumnName) + "</Data>"); 
                      excelXML.Append("\t\t\t\t"); 
                      excelXML.AppendLine("</Cell>"); 
                  } 
                  excelXML.Append("\t\t\t"); 
                  excelXML.AppendLine("</Row>"); 
                  // 表体 
                  foreach (DataRow dataRow in dataTable.Rows) 
                  { 
                      excelXML.Append("\t\t\t"); 
                      excelXML.AppendLine("<Row>"); 
                      // 单元格 
                      foreach (DataColumn dataColumn in dataTable.Columns) 
                      { 
                          excelXML.Append("\t\t\t\t"); 
                          excelXML.AppendLine("<Cell>"); 
                          excelXML.Append("\t\t\t\t\t"); 
                          excelXML.AppendLine("<Data ss:Type=\"String\">" + TextToXML(dataRow[dataColumn].ToString()) + "</Data>"); 
                          excelXML.Append("\t\t\t\t"); 
                          excelXML.AppendLine("</Cell>"); 
                      } 
                      excelXML.Append("\t\t\t"); 
                      excelXML.AppendLine("</Row>"); 
                  } 
                  excelXML.Append("\t\t"); 
                  excelXML.AppendLine("</Table>"); 
                  excelXML.Append("\t"); 
                  excelXML.AppendLine("</Worksheet>"); 
              } 
              excelXML.Append("</Workbook>"); 
              return excelXML.ToString(); 
          } 
          private string TextToXML(string value) 
          { 
              value = value.Replace("&", "&"); 
              value = value.Replace("\"", "\""); 
              value = value.Replace("<", "<"); 
              value = value.Replace(">", ">"); 
              return value; 
          } 
      } 
