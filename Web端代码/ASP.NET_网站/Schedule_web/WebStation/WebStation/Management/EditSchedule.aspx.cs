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
    public partial class EditSchedule : System.Web.UI.Page
    {
        protected string m_strClassNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (string key in this.Request.QueryString.Keys)
            {
                if (string.Equals(key, "classno", StringComparison.CurrentCultureIgnoreCase))
                {
                    m_strClassNo = this.Request.QueryString["classno"];
                    this.labelClassNo.Text = m_strClassNo;
                    break;
                }
            }
            if (!this.IsPostBack)
            {
                cbWeek.Items.Add("星期一");
                cbWeek.Items.Add("星期二");
                cbWeek.Items.Add("星期三");
                cbWeek.Items.Add("星期四");
                cbWeek.Items.Add("星期五");
                loadCourse(1);
            }

        }
        private void loadCourse(int week)
        {
            NHibernateHelper helper = new NHibernateHelper();
            IList list = null;
            Schedule.Data.Schedule t;
            
            string hql = "From Schedule t where t.ClassNo='" + this.m_strClassNo + "' and t.Week=" + week.ToString();
            hql += " order by t.Section asc";
            list = helper.Query(hql);
            if (list == null || list.Count < 1)
            {
                list = new ArrayList();
                for (int i = 1; i < 5; i++)
                {
                    t = new Schedule.Data.Schedule();
                    t.Id = helper.GetMaxId("Schedule", "Id");
                    t.Section = i;
                    helper.Save(t);
                    list.Add(t);
                }
            }
            foreach (Schedule.Data.Schedule obj in list)
            {
                if (obj.Section == 1)
                {
                    hid1.Value = obj.Id.ToString();
                    tbCourse1.Text = obj.Course;
                    tbCourseCode1.Text = obj.CourseCode;
                    tbTeacher1.Text = obj.Teacher;
                    tbAddr1.Text = obj.Addr;
                    tbTeachingWeek1.Text = obj.TeachingWeek;
                }
                else if (obj.Section == 2)
                {
                    hid2.Value = obj.Id.ToString();
                    tbCourse2.Text = obj.Course;
                    tbCourseCode2.Text = obj.CourseCode;
                    tbTeacher2.Text = obj.Teacher;
                    tbAddr2.Text = obj.Addr;
                    tbTeachingWeek2.Text = obj.TeachingWeek;
                }
                else if (obj.Section == 3)
                {
                    hid3.Value = obj.Id.ToString();
                    tbCourse3.Text = obj.Course;
                    tbCourseCode3.Text = obj.CourseCode;
                    tbTeacher3.Text = obj.Teacher;
                    tbAddr3.Text = obj.Addr;
                    tbTeachingWeek3.Text = obj.TeachingWeek;
                }
                else if (obj.Section == 4)
                {
                    hid4.Value = obj.Id.ToString();
                    tbCourse4.Text = obj.Course;
                    tbCourseCode4.Text = obj.CourseCode;
                    tbTeacher4.Text = obj.Teacher;
                    tbAddr4.Text = obj.Addr;
                    tbTeachingWeek4.Text = obj.TeachingWeek;
                }
               
            }


        }

        protected void cbWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            int week = this.cbWeek.SelectedIndex + 1;
            this.loadCourse(week);
        }

        protected void btnDo_Click(object sender, EventArgs e)
        {
            Schedule.Data.Schedule obj;
            string sid;
            
            int id=0;
            NHibernateHelper helper = new NHibernateHelper();
            sid = hid1.Value;
            bool fok = false;
            if (!string.IsNullOrEmpty(sid))
            {
                obj = new Schedule.Data.Schedule();
                Int32.TryParse(sid, out id);
                obj.Section = 1;
                obj.Id = id;
                obj.Course = tbCourse1.Text.Trim();
                obj.CourseCode = tbCourseCode1.Text.Trim();
                obj.Teacher = tbTeacher1.Text.Trim();
                obj.Week = cbWeek.SelectedIndex + 1;
                obj.Addr = tbAddr1.Text.Trim();
                obj.ClassNo = m_strClassNo;
                obj.TeachingWeek = tbTeachingWeek1.Text.Trim();
                
                fok = helper.Update(obj);
            }
            sid = hid2.Value;
            if (!string.IsNullOrEmpty(sid))
            {
                obj = new Schedule.Data.Schedule();
                Int32.TryParse(sid, out id);
                obj.Section = 2;
                obj.Id = id;
                obj.Course = tbCourse2.Text.Trim();
                obj.CourseCode = tbCourseCode2.Text.Trim();
                obj.Teacher = tbTeacher2.Text.Trim();
                obj.Week = cbWeek.SelectedIndex + 1;
                obj.Addr = tbAddr2.Text.Trim();
                obj.ClassNo = m_strClassNo;
                obj.TeachingWeek = tbTeachingWeek2.Text.Trim();

                fok = helper.Update(obj);
            }
            sid = hid3.Value;
            if (!string.IsNullOrEmpty(sid))
            {
                obj = new Schedule.Data.Schedule();
                Int32.TryParse(sid, out id);
                obj.Section = 3;
                obj.Id = id;
                obj.Course = tbCourse3.Text.Trim();
                obj.CourseCode = tbCourseCode3.Text.Trim();
                obj.Teacher = tbTeacher3.Text.Trim();
                obj.Week = cbWeek.SelectedIndex + 1;
                obj.Addr = tbAddr3.Text.Trim();
                obj.ClassNo = m_strClassNo;
                obj.TeachingWeek = tbTeachingWeek3.Text.Trim();

                fok = helper.Update(obj);
            }
            sid = hid4.Value;
            if (!string.IsNullOrEmpty(sid))
            {
                obj = new Schedule.Data.Schedule();
                Int32.TryParse(sid, out id);
                obj.Section = 4;
                obj.Id = id;
                obj.Course = tbCourse4.Text.Trim();
                obj.CourseCode = tbCourseCode4.Text.Trim();
                obj.Teacher = tbTeacher4.Text.Trim();
                obj.Week = cbWeek.SelectedIndex + 1;
                obj.Addr = tbAddr4.Text.Trim();
                obj.ClassNo = m_strClassNo;
                obj.TeachingWeek = tbTeachingWeek4.Text.Trim();

                fok = helper.Update(obj);
            }
            if (fok)
            {
                MessageBox.Show(this, "保存成功");
            }
            else
            {
                MessageBox.Show(this, "保存失败");
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            MessageBox.GoHistory(this);
        }
    }
}