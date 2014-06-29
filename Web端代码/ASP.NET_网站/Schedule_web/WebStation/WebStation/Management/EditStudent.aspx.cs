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
    public partial class EditStudent : System.Web.UI.Page
    {
        NHibernateHelper _helper;
        Student entity;
        protected void Page_Load(object sender, EventArgs e)
        {
            _helper = new NHibernateHelper();
            

            if (!this.IsPostBack)
            {
                BindClass();
                bool fNew = false;
                foreach (string key in this.Request.QueryString.Keys)
                {
                    if (string.Equals(key, "id", StringComparison.CurrentCultureIgnoreCase))
                    {
                        string strId = this.Request.QueryString["id"];
                        entity = _helper.GetObject(typeof(Student), strId) as Student;
                        break;
                    }
                }
                if (entity == null)
                {
                    entity = new Student();
                    fNew = true;
                }
                if (entity != null)
                {
                    if (!fNew)
                    {
                        foreach (Tclass c in _list)
                        {
                            if (string.Equals(c.Classno, entity.Classno, StringComparison.CurrentCultureIgnoreCase))
                            {
                                cbClass.SelectedText = c.ClassName;
                                cbClass.SelectedValue = c.Classno;
                            }
                        }
                        this.tbId.ReadOnly = true;
                        this.tbId.Text = entity.StudentNo;
                        this.tbName.Text = entity.Name;
                        this.tbPhone.Text = entity.Phone;
                        this.tbEmail.Text = entity.Email;
                    }
                }
            }
        }
        private IList _list;
        protected void BindClass()
        {
            string hql = "From Tclass";
            _list = _helper.Query(hql);
            this.cbClass.DataSource = _list;

            this.cbClass.DataBind();
        }
        protected void btnDo_Click(object sender, EventArgs e)
        {
            string id = this.tbId.Text;
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show(this, "学号不能为空");
                return;
            }
            string strClassNo = cbClass.SelectedValue;
            if (string.IsNullOrEmpty(strClassNo))
            {
                MessageBox.Show(this, "请选择所在班级");
                return;
            }

            NHibernateHelper helper = new NHibernateHelper();
            Student obj = helper.GetObject(typeof(Student), id) as Student;
            bool fNew = false;
            if (obj == null)
            {
                fNew = true;
                obj = new Student();
                obj.Pwd = "12345";
            }
            obj.StudentNo = id;
            obj.Name = tbName.Text;
            obj.Phone = tbPhone.Text;
            obj.Email = tbEmail.Text;
            obj.Classno = strClassNo;


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
                MessageBox.ShowAndRedirect( "保存成功", "ManageStudent.aspx");
            }
            else
            {
                MessageBox.Show(this, "保存失败，请检查数据是否录入正确");
            }
        }
    }
}