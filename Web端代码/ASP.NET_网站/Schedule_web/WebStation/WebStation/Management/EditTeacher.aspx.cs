using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Schedule.Data;
using WebStation.Utility;

namespace WebStation.Management
{
    public partial class EditTeacher : System.Web.UI.Page
    {
        NHibernateHelper _helper;
        Teacher entity;
        protected void Page_Load(object sender, EventArgs e)
        {
            _helper = new NHibernateHelper();

            if (!this.IsPostBack)
            {
                bool fNew = false;
                foreach (string key in this.Request.QueryString.Keys)
                {
                    if (string.Equals(key, "id", StringComparison.CurrentCultureIgnoreCase))
                    {
                        string strId = this.Request.QueryString["id"];
                        entity = _helper.GetObject(typeof(Teacher), strId) as Teacher;
                        break;
                    }
                }
                if (entity == null)
                {
                    entity = new Teacher();
                    fNew = true;
                }
                if (entity != null)
                {
                    if (!fNew)
                    {
                        this.tbId.ReadOnly = true;
                        this.tbId.Text = entity.TeacherNo;
                        this.tbName.Text = entity.Name;
                        this.tbPhone.Text = entity.Phone;
                        this.tbEmail.Text = entity.Email;
                        this.tbAddress.Text = entity.Address;
                    }
                }
            }
        }
        protected void btnDo_Click(object sender, EventArgs e)
        {
            string id = this.tbId.Text;
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show(this, "工号不能为空");
                return;
            }

            NHibernateHelper helper = new NHibernateHelper();
            Teacher obj = helper.GetObject(typeof(Teacher), id) as Teacher;
            bool fNew = false;
            if (obj == null)
            {
                fNew = true;
                obj = new Teacher();
                obj.Pwd = "12345";
            }
            obj.TeacherNo = id;
            obj.Name = tbName.Text;
            obj.Phone = tbPhone.Text;
            obj.Email = tbEmail.Text;
            obj.Address = tbAddress.Text;


            bool fok = false;
            if (fNew)
            {
                fok = helper.Save(obj);
            }
            else
            {
                fok = helper.Update(obj);
            }
            if (fok)
            {
                MessageBox.ShowAndRedirect( "保存成功", "ManageTeacher.aspx");
            }
            else
            {
                MessageBox.Show(this, "保存失败，请检查数据是否录入正确");
            }
        }
    }
}