using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using WebStation.Utility;
using Schedule.Data;

namespace WebStation
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(UserInfo.Id))
                {
                    Response.Redirect("Login.aspx");
                }

            }
            catch (Exception)
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected SysUser UserInfo
        {
            get
            {
                string strUser = ((FormsIdentity)this.Context.User.Identity).Ticket.UserData;
                SysUser u = new SysUser();
                return Serialize.Decrypt<SysUser>(u, strUser);
            }
        }
    }
}