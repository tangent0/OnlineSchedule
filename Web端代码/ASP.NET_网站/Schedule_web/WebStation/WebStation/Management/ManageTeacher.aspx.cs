using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Schedule.Data;
using WebStation.Utility;

namespace WebStation.Management
{
    public partial class ManageTeacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        private IList m_list;
        private void BindData()
        {
            NHibernateHelper helper = new NHibernateHelper();
            Teacher t;
            string hql = "From Teacher";
            m_list = helper.Query(hql);
            this.grid.DataSource = m_list;
            this.grid.DataBind();

        }
        protected void lbtnEdit_Command(object sender, CommandEventArgs e)
        {
            string code = Convert.ToString(e.CommandArgument);
            if (string.IsNullOrEmpty(code))
            {
                MessageBox.Show(this, "参数错误！");
                return;
            }
            string url = "EditTeacher.aspx?id=" + code;
            Response.Redirect(url);
        }

        protected void lbtnDel_Command(object sender, CommandEventArgs e)
        {
            string code = Convert.ToString(e.CommandArgument);
            NHibernateHelper helper = new NHibernateHelper();
            bool fok = false;
            if (!string.IsNullOrEmpty(code))
            {
                Teacher obj = helper.GetObject(typeof(Teacher), code) as Teacher;
                fok = helper.Delete(obj);
            }
            if (fok)
            {
                MessageBox.Show(this, "删除成功！");
                BindData();
            }
            else
            {
                MessageBox.Show(this, "出现错误，请检查您的操作！");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditTeacher.aspx");
        }
    }
}