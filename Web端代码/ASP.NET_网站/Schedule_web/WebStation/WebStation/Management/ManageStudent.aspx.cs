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
    public partial class ManageStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindClass();
            }
        }

        protected void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
        private IList _classList;
        protected void BindClass()
        {
            NHibernateHelper helper = new NHibernateHelper();
          
            string hql = "From Tclass t ";
            _classList = helper.Query(hql);
            this.cbClass.DataSource = _classList;
            this.cbClass.DataBind();
        }
        private IList _list;
        protected void BindData()
        {
            NHibernateHelper helper = new NHibernateHelper();
            string classNo = this.cbClass.SelectedValue;
            if (string.IsNullOrEmpty(classNo))
            {
                return;
            }
            Student t;

            string hql = "From Student t where t.Classno='" + classNo + "'";
            _list = helper.Query(hql);
            this.grid.DataSource = _list;
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
            string url = "EditStudent.aspx?id=" + code;
            Response.Redirect(url);
        }

        protected void lbtnDel_Command(object sender, CommandEventArgs e)
        {
            string code = Convert.ToString(e.CommandArgument);
            NHibernateHelper helper = new NHibernateHelper();
            bool fok = false;
            if (!string.IsNullOrEmpty(code))
            {
                Student obj = helper.GetObject(typeof(Student), code) as Student;
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
            Response.Redirect("EditStudent.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}