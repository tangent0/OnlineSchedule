using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace WebStation.Utility
{
    [Serializable]
    public class User
    {
        string sql = string.Empty;
        public User()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public User(DataRow dr)
        {
            _uID = Convert.ToInt32(dr["userID"]);
            _loginName = dr["loginName"].ToString();
            _userName = dr["userName"].ToString();
            _password = dr["pwd"].ToString();
            _userType = Convert.ToInt32(dr["userType"]);
        }

        private int _uID;
        /// <summary>用户编号
        /// 
        /// </summary>
        public int UID
        {
            get { return _uID; }
            set { _uID = value; }
        }
        private string _loginName;
        /// <summary>用户登录名
        /// 
        /// </summary>
        public string LoginName
        {
            get { return _loginName; }
            set { _loginName = value; }
        }
        private string _userName;
        /// <summary>用户名
        /// 
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        private string _password;
        /// <summary>用户密码
        /// 
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        private int _userType;
        /// <summary>用户类型
        /// 
        /// </summary>
        public int UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }
        /// <summary>添加用户
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Add(User user)
        {
            //sql = "INSERT INTO USERS (loginName,userName,password,userType) VALUES(@loginName,@userName,@password,@userType)";
            sql = "INSERT INTO USERS (loginName,pwd,userName,userType) VALUES(@loginName,@pwd,@userName,@userType)";
            OleDbParameter[] paras = new OleDbParameter[] { 
            new OleDbParameter("@loginName",user.LoginName),
            new OleDbParameter("@pwd",user.Password),
            new OleDbParameter("@userName",user.UserName),
            new OleDbParameter("@userType",user.UserType)
        };
            int res = SQLHelper.ExecuteSql(sql, paras);
            if (res > 0) return true;
            return false;
        }
        /// <summary>编辑用户
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Edit(User user)
        {
            sql = "UPDATE USERS SET loginName=@loginName,userName=@userName,pwd=@pwd,userType=@userType WHERE uID=@uID";
            OleDbParameter[] paras = new OleDbParameter[] { 
            new OleDbParameter("@loginName",user.LoginName),
            new OleDbParameter("@userName",user.UserName),
            //new OleDbParameter("@pwd",StringOP.MD5EncryptOne(user.Password)),
            new OleDbParameter("@pwd",user.Password),
            new OleDbParameter("@userType",user.UserType),
            new OleDbParameter("@uID",user.UID)
        };
            int res = SQLHelper.ExecuteSql(sql, paras);
            if (res > 0) return true;
            return false;
        }
        /// <summary>得到用户列表
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet GetList(string where)
        {
            sql = "SELECT * FROM USERS";
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
        /// <summary>用户登录
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool Login(User user, out User userInfo)
        {
            sql = "SELECT COUNT(1) FROM USERS WHERE loginName=@loginName AND pwd=@pwd ";
            OleDbParameter[] paras = new OleDbParameter[] { 
            new OleDbParameter("@loginName",user.LoginName),
             new OleDbParameter("@pwd",user.Password)
            //new OleDbParameter("@pwd",StringOP.MD5EncryptOne(user.Password))
        };
            string res = (SQLHelper.GetSingle(sql, paras)).ToString();
            if (res == "1")
            {
                userInfo = GetInfo(user.LoginName);
                return true;
            }
            userInfo = null;
            return false;
        }
        /// <summary>得到指定用户名的用户信息
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User GetInfo(string loginname)
        {
            sql = "SELECT * FROM USERS WHERE loginName=@loginName";
            OleDbParameter[] paras = new OleDbParameter[] { 
            new OleDbParameter("@loginName",loginname)
        };
            DataSet ds = SQLHelper.Query(sql, paras);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return new User(ds.Tables[0].Rows[0]);
            }
            return null;
        }
        /// <summary>得到指定用户名编号的用户信息
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User GetInfo(int uID)
        {
            sql = "SELECT * FROM USERS WHERE userid=@userid";
            OleDbParameter[] paras = new OleDbParameter[] { 
            new OleDbParameter("@userid",uID)
        };
            DataSet ds = SQLHelper.Query(sql, paras);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return new User(ds.Tables[0].Rows[0]);
            }
            return null;
        }
        /// <summary>删除用户
        /// 
        /// </summary>
        /// <param name="uID"></param>
        /// <returns></returns>
        public bool Del(int uID)
        {
            sql = "DELETE FROM USERS WHERE userID=@userID";
            OleDbParameter[] paras = new OleDbParameter[] { 
            new OleDbParameter("@userID",uID)
        };
            int res = SQLHelper.ExecuteSql(sql, paras);
            if (res > 0) return true;
            return false;
        }
        /// <summary>用户修改个人信息
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool ReUserInfo(User user)
        {
            sql = "UPDATE USERS SET userName=@userName WHERE userID=@userid";
            OleDbParameter[] paras = new OleDbParameter[] { 
            new OleDbParameter("@userName",user.UserName),
            new OleDbParameter("@userid",user.UID)
        };
            int res = SQLHelper.ExecuteSql(sql, paras);
            if (res > 0) return true;
            return false;
        }
        /// <summary>修改用户密码
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public bool RePwd(int uid, string pwd)
        {
            sql = "UPDATE USERS SET pwd=@pwd WHERE userID=@uID";
            OleDbParameter[] paras = new OleDbParameter[] { 
            new OleDbParameter("@pwd",pwd),
            new OleDbParameter("@uID",uid)
        };
            int res = SQLHelper.ExecuteSql(sql, paras);
            if (res > 0) return true;
            return false;
        }
    }
}