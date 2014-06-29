using System;
using System.Collections;
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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Teacher t;
            
            NHibernateHelper helper = new NHibernateHelper();
            string hql = "From Teacher t where t.TeacherNo='" + txtUserName.Text.Trim() + "'";
            IList list = helper.Query(hql);
            if (list.Count > 0)
            {
                t = list[0] as Teacher;
                if (!string.Equals(t.Pwd, txtPassword.Text.Trim(), StringComparison.CurrentCultureIgnoreCase))
                {
                    MessageBox.Show(this, "密码错误，请重新输入");
                    return;
                }
                SysUser user = new SysUser();
                user.Id = t.TeacherNo;
                user.LoginName = t.TeacherNo;
                user.UserName = t.Name;
                user.UserType = 0;
                user.Password = t.Pwd;
                user.Phone = t.Phone;

                string strUser = Serialize.Encrypt<SysUser>(user);
                //写入票据
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1, user.LoginName, DateTime.Now, DateTime.Now.AddMinutes(20), false, strUser);
                //加密票据
                string strTicket = FormsAuthentication.Encrypt(ticket);
                //写入cookies
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, strTicket);
                this.Response.Cookies.Add(cookie);
                //string requestUrl = FormsAuthentication.GetRedirectUrl(FormsAuthentication.FormsCookieName, false);
                //不要使用FormsAuthentication.RedirectFromLoginPage方法,因为这个方法会重写cookie
                // MessageBox.ShowAndRedirect("登录成功！", "Index.aspx");
                Response.Redirect("Index.aspx");
                return;
            }
            MessageBox.Show(this, "用户不存在，请重新输入");
            return;

        }
    }
}