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

    public partial class EditClass : System.Web.UI.Page
    {
        NHibernateHelper _helper;
        Tclass entity;
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
                        entity = _helper.GetObject(typeof(Tclass), strId) as Tclass;
                        break;
                    }
                }
                if (entity == null)
                {
                    entity = new Tclass();
                    fNew = true;
                }
                if (entity != null)
                {
                    if (!fNew)
                    {
                        this.tbId.ReadOnly = true;
                        this.tbId.Text = entity.Classno;
                        this.tbClassName.Text = entity.ClassName;                       
                    }
                }
            }
        }
        protected void btnDo_Click(object sender, EventArgs e)
        {
            string id = this.tbId.Text;
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show(this, "班级编号不能为空");
                return;
            }
           
            NHibernateHelper helper = new NHibernateHelper();
            Tclass obj = helper.GetObject(typeof(Tclass), id) as Tclass;
            bool fNew = false;
            if (obj == null)
            {
                fNew = true;
                obj = new Tclass();
            }
            obj.Classno = id;
            obj.ClassName = tbClassName.Text;

           
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
                MessageBox.ShowAndRedirect("保存成功", "ManageClass.aspx");
               
            }
            else
            {
                MessageBox.Show(this, "保存失败，请检查数据是否录入正确");
            }
        }
    }
}