using System;
using System.Data;
using System.Data.OleDb;

namespace WebStation.Utility
{
    public class LogCategory
    {
        string sql = string.Empty;
        public LogCategory()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public LogCategory(string caname, int caid)
        {
            _caName = caname;
            _caID = caid;
        }

        private int _caID;
        /// <summary>分类编号
        /// 
        /// </summary>
        public int CaID
        {
            get { return _caID; }
            set { _caID = value; }
        }
        private string _caName;
        /// <summary>分类名
        /// 
        /// </summary>
        public string CaName
        {
            get { return _caName; }
            set { _caName = value; }
        }
        private string _owner;
        // <summary>负责人
        /// 
        /// </summary>
        public string owner
        {
            get { return _owner; }
            set { _owner = value; }
        }
        private string _progress;
        // <summary>进度
        /// 
        /// </summary>
        public string progress
        {
            get { return _progress; }
            set { _progress = value; }
        }
        private string _number;
        // <summary>编号
        /// 
        /// </summary>
        public string number
        {
            get { return _number; }
            set { _number = value; }
        }
        /// <summary>添加文档类型
        /// 
        /// </summary>
        /// <param name="logCa"></param>
        /// <returns></returns>
        public bool Add(LogCategory logCa)
        {
            sql = "INSERT INTO LOGCATEGORY (caName,owner,progress,num) VALUES(@caName,@owner,@progress,@number)";
            OleDbParameter[] paras = new OleDbParameter[] { 
            new OleDbParameter("@caName",logCa.CaName),
         new OleDbParameter("@owner",logCa.owner),
         new OleDbParameter("@progress",logCa.progress),
         new OleDbParameter("@number",logCa.number)
        };
            int res = SQLHelper.ExecuteSql(sql, paras);
            if (res > 0) return true;
            return false;
        }
        /// <summary>编辑文档类型
        /// 
        /// </summary>
        /// <param name="logCa"></param>
        /// <returns></returns>
        public bool Edit(LogCategory logCa)
        {
            sql = "UPDATE LOGCATEGORY SET caName='" + logCa.CaName + "',owner='" + logCa.owner + "',progress='" + logCa.progress + "',num='" + logCa.number + "' WHERE caID=" + logCa.CaID + "";
            int res = SQLHelper.ExecuteSq(sql);
            if (res > 0) return true;
            return false;
        }
        /// <summary>取得分类列表
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet GetList(string where)
        {
            sql = "SELECT * FROM LOGCATEGORY";
            if (where != string.Empty)
            {
                sql += " WHERE " + where;
            }
            DataSet ds = SQLHelper.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }
        public DataSet GetList()  //获取整个项目表信息
        {
            sql = "SELECT * FROM LOGCATEGORY";
            DataSet ds = SQLHelper.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        /// <summary>删除文档类型
        /// 
        /// </summary>
        /// <param name="caID"></param>
        /// <returns></returns>
        public bool Del(int caID)
        {
            sql = "DELETE FROM LOGCATEGORY WHERE CAID=@CAID";
            OleDbParameter[] paras = new OleDbParameter[] { 
            new OleDbParameter("@caID",caID)
        };
            int res = SQLHelper.ExecuteSql(sql, paras);
            if (res > 0) return true;
            return false;
        }
    }
}