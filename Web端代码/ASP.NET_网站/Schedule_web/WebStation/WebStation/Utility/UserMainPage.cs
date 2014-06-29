using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Data;
using System.Data.OleDb;
using Schedule.Data;

namespace WebStation.Utility
{
    public class UserMainPage :System.Web.UI.Page
    {
        public UserMainPage()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        protected SysUser UserInfo
        {
            get
            {
                try
                {
                    string strUser = ((FormsIdentity)this.Context.User.Identity).Ticket.UserData;
                    SysUser u = new SysUser();
                    return Serialize.Decrypt<SysUser>(u, strUser);
                }
                catch (Exception ex)
                {
                    return new SysUser();
                }

            }
        }
    }
}