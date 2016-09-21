using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallLogic
{
   public class CommonLogic
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="picString"></param>
        /// <returns></returns>
        public static bool UploadFile(string picString, out string msg)
        {
            msg = string.Empty;
            var bytes = Convert.FromBase64String(picString);
            string filePath = "c:\\a.xlsx"; //文件路径
            FileStream fstream = File.Create(filePath, bytes.Length);
            try
            {
                fstream.Write(bytes, 0, bytes.Length); //二进制转换成文件
                fstream.Close();
                ExcelToDS(filePath);
                msg = "上传成功";
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                fstream.Close();
            }
            finally
            {
                
            }
            return false;
        }

        public static void ExcelToDS(string Path)
        {
            string strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=0'";
            //string strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=d:/成绩表2013.xlsx;Extended Properties='Excel 12.0;HDR=YES;IMEX=0'";
            OleDbConnection myConn = new OleDbConnection(strCon);
            string strCom = "SELECT * FROM [Goods$]";
            myConn.Open();
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(strCom, myConn);
            DataSet myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet, "[Goods$]");
            myConn.Close();
            DataTable dt = myDataSet.Tables[0]; //初始化DataTable实例
            new BusinessLogic().InsertData(dt);
        } 
    }
}
