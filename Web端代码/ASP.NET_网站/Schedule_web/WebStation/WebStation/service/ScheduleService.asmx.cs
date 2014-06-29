using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.IO;
using System.Data;
using System.Xml;
using Schedule.Data;

namespace WebStation.service
{
    /// <summary>
    /// ScheduleService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]

	//[SoapDocumentService(RoutingStyle= SoapServiceRoutingStyle.RequestElement)]
    public class ScheduleService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        //根据传入的学号、密码参数，验证该学生信息是否存在，如果存在且密码正确，则返回该学生所在的班级号
        [WebMethod]
        public string Login(string studentNo, string pwd)
        {
            string result = "";
            result = "None";
            NHibernateHelper helper = new NHibernateHelper();
            Student t;

            string hql = "From Student t  where t.StudentNo='" + studentNo + "'";
           
            IList list = helper.Query(hql);
            Student student = null;
            if (list != null && list.Count > 0)
            {
                student = list[0] as Student;
            }
            
            if (student == null)
            {
                
                return result;
            }
            else
            {
                if (string.Compare(student.Pwd, pwd, true) == 0)
                {
                    result = student.Classno;
                }
            }
            return result;
        }
//         public string Login(string studentNo, string pwd)
//         {
//             string result = "";
//             NHibernateHelper helper = new NHibernateHelper();
//             Student t;
// 
//             string hql = "From Student where t.StudentNo='" + studentNo + "'";
//             IList list = helper.Query(hql);
//             Student student = null;
//             if (list != null && list.Count > 0)
//             {
//                 student = list[0] as Student;
//             }
//             XmlDocument doc = new XmlDocument();
//             XmlNode root = null;
//             XmlNode xmlNode = doc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
//             doc.AppendChild(xmlNode);
//             root = doc.CreateElement("Login");
//             doc.AppendChild(root);
//             XmlElement item;
//             XmlElement child;
//             XmlAttribute attr;
// 
//             item = doc.CreateElement("Result");
//             if (student == null)
//             {
//                 item.InnerText = "False";
//                 root.AppendChild(item);
//             }
//             else
//             {
//                 if (string.Compare(student.Pwd, pwd, true) == 0)
//                 {
//                     item.InnerText = "True";
//                     root.AppendChild(item);
//                     item = doc.CreateElement("ClassNo");
//                     item.InnerText = student.Classno;
//                     root.AppendChild(item);
//                 }
//                 else
//                 {
//                     item.InnerText = "False";
//                     root.AppendChild(item);
//                 }
//             }
//             result = doc.InnerXml;
//             return result;
//         }

        //根据班级号从数据库中查询该班级的课程表，并将课程表信息转换为xml字符串返回给android客户端
        [WebMethod]
        public string MySchedule(string classNo)
        {
            string strXml = "";
            NHibernateHelper helper = new NHibernateHelper();
            Schedule.Data.Schedule t;

            string hql = "From Schedule t where t.ClassNo='" + classNo + "'";
            IList list = helper.Query(hql);

            //创建XML文件
            XmlDocument doc = new XmlDocument();
            XmlNode root = null;
            XmlNode xmlNode = doc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            doc.AppendChild(xmlNode);
          
            root = doc.CreateElement("Schedule");
            doc.AppendChild(root);

            XmlElement item;
            XmlElement child;
            XmlAttribute attr;
            foreach (Schedule.Data.Schedule obj in list)
            {
                item = doc.CreateElement("item");
                attr = doc.CreateAttribute("week");
                attr.Value = obj.Week.ToString();
                item.Attributes.Append(attr);
                root.AppendChild(item);
                
                child = doc.CreateElement("Section");
                child.InnerText = obj.Section.ToString();
                item.AppendChild(child);

                child = doc.CreateElement("Course");
                child.InnerText = obj.Course;
                item.AppendChild(child);

                child = doc.CreateElement("Addr");
                child.InnerText = obj.Addr;
                item.AppendChild(child);

                child = doc.CreateElement("Teacher");
                child.InnerText = obj.Teacher;
                item.AppendChild(child);

                child = doc.CreateElement("Week");
                child.InnerText = obj.Week.ToString();
                item.AppendChild(child);
            }
            strXml = doc.InnerXml;
            return strXml;
        }

        //给客户端提供重要提醒信息的获取功能
        [WebMethod]
        public string Remind(string maxRow)
        {
            string strXml = "";
            NHibernateHelper helper = new NHibernateHelper();
            Schedule.Data.Remind t;

            //从数据库中查询重要提醒并将其list列表中
            //（该查询使用的是NHibernate ORMaping库实现,Nhibernate 负责执行数据库查询并将查询结果转换为Remind实例）
            string hql = "From Remind t ";
            IList list = helper.Query(hql);

            //创建XML文件
            //以下内容为构建返回给客户端的xml字符串，遍历查询到的Remind列表，并将列表中的每个对象转换为xml的元素
            XmlDocument doc = new XmlDocument();
            XmlNode root = null;
            XmlNode xmlNode = doc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            doc.AppendChild(xmlNode);
            root = doc.CreateElement("Remind");
            doc.AppendChild(root);

            XmlElement item;
            XmlElement child;
            XmlAttribute attr;
            foreach (Schedule.Data.Remind obj in list)
            {
                item = doc.CreateElement("item");
                attr = doc.CreateAttribute("id");
                attr.Value = obj.Id.ToString();
                item.Attributes.Append(attr);
                root.AppendChild(item);
                
                child = doc.CreateElement("Id");
                child.InnerText = obj.Id.ToString();
                item.AppendChild(child);

                child = doc.CreateElement("Note");
                child.InnerText = obj.Note;
                item.AppendChild(child);

                child = doc.CreateElement("Month");
                child.InnerText = obj.Month.ToString();
                item.AppendChild(child);

                child = doc.CreateElement("Day");
                child.InnerText = obj.Day.ToString();
                item.AppendChild(child);
               
            }

            //获取转换后的xml字符串并将该串返回给客户端，供客户端进行解析
            strXml = doc.InnerXml;
            return strXml;
        }
    }
}
