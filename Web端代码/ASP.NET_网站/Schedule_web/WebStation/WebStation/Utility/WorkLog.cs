using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace WebStation.Utility
{
    public class WorkLog
    {
        string sql = string.Empty;
        public WorkLog()
        {

        }

        public WorkLog(DataRow dr)
        {
            _logID = Convert.ToInt32(dr["ID"]);
            _userID = Convert.ToInt32(dr["userID"]);
            _caID = Convert.ToInt32(dr["caID"]);
            _logContent = dr["logContent"].ToString();
            _addDate = dr["addDate"].ToString();
            _title = dr["logTitle"].ToString();
            _StartTime = dr["StartTime"].ToString();
            _EndTime = dr["EndTime"].ToString();
            _logPlan = dr["logPlan"].ToString();
            _logResault = dr["logResault"].ToString();
            _workHour = dr["workHour"].ToString();
            _logWeekplan = dr["logWeekplan"].ToString();
            _workplace = dr["workplace"].ToString();
            _xiangmu_num = dr["xiangmu_num"].ToString();
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        private string _xiangmu_num;
        public string xiangmu_num
        {
            get { return _xiangmu_num; }
            set { _xiangmu_num = value; }
        }
        /// <summary>
        /// 工作地点
        /// </summary>
        private string _workplace;
        public string workplace
        {
            get { return _workplace; }
            set { _workplace = value; }
        }
        /// <summary>
        /// 周工作计划
        /// </summary>
        private string _logWeekplan;
        public string LogWeekplan
        {
            get { return _logWeekplan; }
            set { _logWeekplan = value; }
        }
        /// <summary>
        /// 用时
        /// </summary>
        private string _workHour;
        public string WorkHour
        {
            get { return _workHour; }
            set { _workHour = value; }
        }
        /// <summary>
        /// 达成效果
        /// </summary>
        private string _logResault;
        public string LogResault
        {
            get { return _logResault; }
            set { _logResault = value; }
        }
        /// <summary>
        /// 计划完成工作
        /// </summary>
        private string _logPlan;
        public string LogPlan
        {
            get { return _logPlan; }
            set { _logPlan = value; }
        }
        private int _logID;
        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartTime
        {
            get { return _StartTime; }
            set { _StartTime = value; }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndTime
        {
            get { return _EndTime; }
            set { _EndTime = value; }
        }
        /// <summary>
        /// 日志编号
        /// </summary>
        public int LogID
        {
            get { return _logID; }
            set { _logID = value; }
        }
        private int _userID;
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        private int _caID;
        /// <summary>
        /// 分类编号
        /// </summary>
        public int CaID
        {
            get { return _caID; }
            set { _caID = value; }
        }
        private string _title;
        /// <summary>文章标题
        /// 
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private string _logContent;
        public string LogContent
        {
            get { return _logContent; }
            set { _logContent = value; }
        }
        private string _addDate;
        public string AddDate
        {
            get { return _addDate; }
            set { _addDate = value; }
        }
        /// <summary>添加日志
        /// 
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public bool Add(WorkLog log)
        {
            sql = "INSERT INTO WORKLOG (userID,caID,addDate,logTitle,logContent,StartTime,EndTime,logPlan,logResault,workHour,logWeekplan,workplace,xiangmu_num) VALUES(@userID,@caID,@addDate,@title,@logContent,@StartTime,@EndTime,@logPlan,@logResault,@workHour,@logWeekplan,@workplace,@xiangmu_num)";
            OleDbParameter[] paras = new OleDbParameter[] { 
            new OleDbParameter("@userID",log.UserID),
            new OleDbParameter("@caID",log.CaID),
            new OleDbParameter("@addDate",log.AddDate.ToString()),
            new OleDbParameter("@title",log.Title),
            new OleDbParameter("@logContent",log._logContent),
            new OleDbParameter("@StartTime",log.StartTime),
            new OleDbParameter("@EndTime",log.EndTime),
            new OleDbParameter("@logPlan",log.LogPlan),
            new OleDbParameter("@logResault",log.LogResault),
            new OleDbParameter("@workHour",log.WorkHour),
            new OleDbParameter("@logWeekplan",log.LogWeekplan),
            new OleDbParameter("@workplace",log.workplace),
             new OleDbParameter("@xiangmu_num",log.xiangmu_num)
        };
            int res = SQLHelper.ExecuteSql(sql, paras);
            if (res > 0) return true;
            return false;
        }
        /// <summary>编辑日志
        /// 
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public bool Edit(WorkLog log)
        {
            //sql = "UPDATE WORKLOG SET userID=@userID,caID=@caID,logContent=@logContent,logTitle=@title,StartTime=@StartTime WHERE ID=@ID";
            //OleDbParameter[] paras = new OleDbParameter[] { 
            //    new OleDbParameter("@userID",log.UserID),
            //    new OleDbParameter("@caID",log.CaID),
            //    new OleDbParameter("@logContent",log.LogContent),
            //    new OleDbParameter("@logTitle",log.Title),
            //    new OleDbParameter("@ID",log.LogID),
            //    new OleDbParameter("@StartTime",log.StartTime),
            //    new OleDbParameter("@EndTime",log.EndTime)

            //};
            string sql;
            sql = "UPDATE WORKLOG SET userID='" + log.UserID.ToString() + "',caID='" + log.CaID.ToString() + "',logContent='" + log._logContent.ToString() + "',logTitle='" + log.Title.ToString() + "',StartTime='" + log.StartTime.ToString() + "',EndTime='" + log.EndTime.ToString() + "',logPlan='" + log.LogPlan.ToString() + "',workHour='" + log.WorkHour.ToString() + "',logWeekplan='" + log.LogWeekplan.ToString() + "',logResault='" + log.LogResault.ToString() + "',workplace='" + log.workplace.ToString() + "',xiangmu_num='" + log.xiangmu_num + "' WHERE ID=" + log.LogID + "";
            int res = SQLHelper.ExecuteSq(sql);
            if (res > 0) return true;
            return false;

        }
        /// <summary>取得日志列表
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet GetList(string where)
        {
            sql = "SELECT * FROM WORKLOG";
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
        public DataSet GetAll(string where)
        {
            string orderBy = " ORDER BY ID DESC";
            sql = @"SELECT  users.userName,LogCategory.caName, WorkLog.* FROM (LogCategory INNER JOIN WorkLog ON LogCategory.caID = WorkLog.caID) INNER JOIN users ON WorkLog.userID = users.userID";
            if (where != string.Empty)
            {
                sql += " WHERE " + where;
            }
            DataSet ds = SQLHelper.Query(sql + orderBy);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }
        /// <summary>取得指定编号的日志
        /// 
        /// </summary>
        /// <param name="logID"></param>
        /// <returns></returns>
        public WorkLog GetWorkLog(int logID)
        {
            sql = "SELECT * FROM WORKLOG WHERE ID=@logID";
            OleDbParameter[] paras = new OleDbParameter[] { 
            new OleDbParameter("@logID",logID)
        };
            DataSet ds = SQLHelper.Query(sql, paras);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return new WorkLog(ds.Tables[0].Rows[0]);
            }
            return null;
        }
        /// <summary>取得指定编号的文档信息
        /// 
        /// </summary>
        /// <param name="logID"></param>
        /// <returns></returns>
        public DataSet GetDocInfo(int logID)
        {
            sql = @"SELECT LogCategory.caName, WorkLog.*, users.userName
FROM LogCategory INNER JOIN (users INNER JOIN WorkLog ON users.userID = WorkLog.userID) ON LogCategory.caID = WorkLog.caID where ID=@ID";
            OleDbParameter[] paras = new OleDbParameter[] { 
            new OleDbParameter("@ID",logID)
            
        };
            DataSet ds = SQLHelper.Query(sql, paras);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }
        /// <summary>删除文档
        /// 
        /// </summary>
        /// <param name="uID"></param>
        /// <returns></returns>
        public bool Del(int logID)
        {
            sql = "DELETE FROM WORKLOG WHERE ID=@ID";
            OleDbParameter[] paras = new OleDbParameter[] { 
            new OleDbParameter("ID",logID)
        };
            int res = SQLHelper.ExecuteSql(sql, paras);
            if (res > 0) return true;
            return false;
        }
        /// <summary>检测指定编号用户当日是否有重复信息
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="theDate"></param>
        /// <returns>true:有重复日志，false:没有重复日志</returns>
        public bool CheckUserDate(int uid)
        {
            sql = "select  count(*) from worklog where userid=@userid and caID=1 and DATEDIFF('d', addDate, Now())=0";
            OleDbParameter[] paras = new OleDbParameter[] { 
            new OleDbParameter("@userid",uid)
        };
            string res = SQLHelper.GetSingle(sql, paras).ToString();
            if (res != "0")
            {
                return true;
            }
            return false;
        }

        public string _StartTime { get; set; }

        public int _EndtTime { get; set; }

        public string _EndTime { get; set; }

        public OleDbType EndtTime { get; set; }
    }
}