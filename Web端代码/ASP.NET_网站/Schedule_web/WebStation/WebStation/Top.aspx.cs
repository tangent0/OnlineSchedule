using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebStation.Utility;

namespace WebStation
{
    public partial class Top : UserMainPage
    {//System.Web.UI.Page
        public string UserName
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.UserInfo != null)
            {
                UserName = this.UserInfo.UserName;
                this.litUserName.Text = UserName;
            }
        }
    }
}