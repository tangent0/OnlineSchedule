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
    public partial class EditRemind : System.Web.UI.Page
    {
        NHibernateHelper _helper;
        Remind entity;
        protected void Page_Load(object sender, EventArgs e)
        {
            _helper = new NHibernateHelper();

            if (!this.IsPostBack)
            {
                this.InitDDL();
                bool fNew = false;
                foreach (string key in this.Request.QueryString.Keys)
                {
                    if (string.Equals(key, "id", StringComparison.CurrentCultureIgnoreCase))
                    {
                        string strId = this.Request.QueryString["id"];
                        int id = 0;
                        int.TryParse(strId, out id);
                        entity = _helper.GetObject(typeof(Remind), id) as Remind;
                        break;
                    }
                }
                if (entity == null)
                {
                    entity = new Remind();
                    fNew = true;
                }
                if (entity != null)
                {
                    if (!fNew)
                    {
                        this.tbId.ReadOnly = true;
                        this.tbId.Text = entity.Id.ToString();
                        this.tbEmail.Text = entity.Note ;
                        this.ddlMonth.SelectedIndex = entity.Month - 1;
                        this.ddlDay.SelectedIndex = entity.Day-1;
                    }
                }
            }
        }
        private void InitDDL()
        {
            for (int i = 1; i <= 12; i++)
            {
                string str = i.ToString() + "月";
                this.ddlMonth.Items.Add(str);
            }
            for (int i = 1; i <= 31; i++)
            {
                string str = i.ToString();
                this.ddlDay.Items.Add(str);
            }
        }
        protected void btnDo_Click(object sender, EventArgs e)
        {
            string strId = this.tbId.Text;
            int id = 0;
            int.TryParse(strId, out id);
            NHibernateHelper helper = new NHibernateHelper();
            Remind obj = helper.GetObject(typeof(Remind), id) as Remind;
            bool fNew = false;
            if (obj == null)
            {
                fNew = true;
                obj = new Remind();
                id = helper.GetMaxId("Remind", "Id");
                obj.Id = id;
            }
            obj.Id = id;
            obj.Month = ddlMonth.SelectedIndex + 1;
            obj.Day = ddlDay.SelectedIndex + 1;
            obj.Note = this.tbEmail.Text;


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
                MessageBox.ShowAndRedirect("保存成功", "ManageRemind.aspx");

            }
            else
            {
                MessageBox.Show(this, "保存失败，请检查数据是否录入正确");
            }
        }
    }
}