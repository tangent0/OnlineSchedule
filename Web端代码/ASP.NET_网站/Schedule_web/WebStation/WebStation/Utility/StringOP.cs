using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace WebStation.Utility
{
    public class StringOP
    {

        #region 切割字符串
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="len"></param>
        /// <param name="Ellipsis"></param>
        /// <returns></returns>
        public static string CutString(string inputString, int len, bool Ellipsis)
        {

            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }

                try
                {
                    tempString += inputString.Substring(i, 1);
                }
                catch
                {
                    break;
                }

                if (tempLen > len)
                    break;
            }
            //如果截过则加上半个省略号
            byte[] mybyte = System.Text.Encoding.Default.GetBytes(inputString);
            if (mybyte.Length > len && Ellipsis)
                tempString += "……";

            return tempString;
        }
        #endregion

        #region 替换html中的特殊字符
        /// <summary>
        /// 替换html中的特殊字符
        /// </summary>
        /// <param name="theString">需要进行替换的文本。</param>
        /// <returns>替换完的文本。</returns>
        public static string HtmlEncode(string theString)
        {
            theString = theString.Replace(">", "&gt;");
            theString = theString.Replace("<", "&lt;");
            theString = theString.Replace(" ", "&nbsp;");
            theString = theString.Replace(" ", "&nbsp;");
            theString = theString.Replace("\"", "&quot;");
            theString = theString.Replace("\'", "'");
            theString = theString.Replace("\n", "<br/> ");
            return theString;
        }
        #endregion

        #region 恢复html中的特殊字符
        /// <summary>
        /// 恢复html中的特殊字符
        /// </summary>
        /// <param name="theString">需要恢复的文本。</param>
        /// <returns>恢复好的文本。</returns>
        public static string HtmlDiscode(string theString)
        {
            theString = theString.Replace("&gt;", ">");
            theString = theString.Replace("&lt;", "<");
            theString = theString.Replace("&nbsp;", " ");
            theString = theString.Replace("&nbsp;", " ");
            theString = theString.Replace("&quot;", "\"");
            theString = theString.Replace("'", "\'");
            theString = theString.Replace("<br/> ", "\n");
            return theString;
        }
        #endregion

        #region md5加密
        /// <summary>
        /// md5一次加密
        /// </summary>
        /// <param name="strPsswd"></param>
        /// <returns></returns>
        public static string MD5EncryptOne(string strPsswd)
        {
            strPsswd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strPsswd, "MD5");
            return strPsswd;
        }
        /// <summary>
        /// md5多次加密
        /// </summary>
        /// <param name="n"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static string MD5EncryptM(int n, string strPsswd)
        {
            for (int i = 1; i <= n; i++)
            {
                strPsswd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strPsswd, "MD5");
            }
            return strPsswd;
        }
        #endregion

        #region 生成静态页面
        /// <summary>
        /// 传入URL返回网页的html代码
        /// </summary>
        /// <param name="Url">URL</param>
        /// <returns></returns>
        public static string getUrltoHtml(string Url)
        {
            string errorMsg = "";
            try
            {
                System.Net.WebRequest wReq = System.Net.WebRequest.Create(Url);
                // Get the response instance.
                System.Net.WebResponse wResp = wReq.GetResponse();
                System.IO.Stream respStream = wResp.GetResponseStream();
                // Dim reader As StreamReader = New StreamReader(respStream)
                System.IO.StreamReader reader = new System.IO.StreamReader(respStream, System.Text.Encoding.GetEncoding("gb2312"));
                return reader.ReadToEnd();

            }
            catch (System.Exception ex)
            {
                errorMsg = ex.Message;
            }
            return "";
        }
        #endregion

        #region 输入url生成静态页
        /// <summary>
        /// 静态生成页面的方法
        /// </summary>
        /// <param name='strPageUrl'>生成源</param>
        /// <param name='strFileName'>生成到</param>
        public static bool MakePage(string strPageUrl, string strFileName)
        {
            string strDir, strFilePage;
            strDir = @"~/";//更新到的文件夹
            strFilePage = System.Web.HttpContext.Current.Server.MapPath(strDir + strFileName);
            //string msg = string.Empty;
            StreamWriter sw = null;
            //获得aspx的静态html
            try
            {
                if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(strDir)))
                {
                    Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(strDir));
                }
                if (File.Exists(strFilePage))
                {
                    File.Delete(strFilePage);
                }
                sw = new StreamWriter(strFilePage, false, System.Text.Encoding.GetEncoding("GB2312"));
                System.Web.HttpContext.Current.Server.Execute(strPageUrl, sw);
            }
            catch (Exception)
            {
                return false;//生成到出错
            }
            finally
            {
                sw.Flush();
                sw.Close();
                sw = null;
            }
            return true;
        }

        #endregion

        #region 判断是否数字
        public static bool IsNumber(string TheChar)
        {
            bool flag = false;
            Regex reg = new Regex("^[0-9]+$");
            Match ma = reg.Match(TheChar);
            if (ma.Success)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }
        #endregion

        #region htmlToText
        public static string HtmlToTxt(string html)
        {
            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" no[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex6 = new System.Text.RegularExpressions.Regex(@"\<img[^\>]+\>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex7 = new System.Text.RegularExpressions.Regex(@"</p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex8 = new System.Text.RegularExpressions.Regex(@"<p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex9 = new System.Text.RegularExpressions.Regex(@"<[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex1.Replace(html, ""); //过滤<script></script>标记 
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性 
            html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件 
            html = regex4.Replace(html, ""); //过滤iframe 
            html = regex5.Replace(html, ""); //过滤frameset 
            html = regex6.Replace(html, ""); //过滤frameset 
            html = regex7.Replace(html, ""); //过滤frameset 
            html = regex8.Replace(html, ""); //过滤frameset 
            html = regex9.Replace(html, "");
            html = html.Replace(" ", "");
            html = html.Replace("</strong>", "");
            html = html.Replace("<strong>", "");
            return html;
        }
        #endregion

        /// <summary>
        /// 取得随机文件名
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string GetRandomFileName(string filename)
        {
            string[] files = filename.Split('.');
            string exfilename = "." + files.GetValue(files.Length - 1);

            char[] s = new char[]{'0','1', '2','3','4','5','6','7','8','9','A' 
          ,'B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q' 
          ,'R','S','T','U','V','W','X','Y','Z'};
            string num = "";
            Random r = new Random();
            for (int i = 0; i < 4; i++)
                num += s[r.Next(0, s.Length)].ToString();//51&aspx
            DateTime time = DateTime.Now;
            StringBuilder name = new StringBuilder();
            name.Append(time.Year.ToString())
                .Append(time.Month.ToString().PadLeft(2, '0'))
                .Append(time.Day.ToString().PadLeft(2, '0'))
                .Append(time.Hour.ToString().PadLeft(2, '0'))
                .Append(time.Minute.ToString().PadLeft(2, '0'))
                .Append(time.Second.ToString().PadLeft(2, '0'))
                .Append(num + exfilename);
            return name.ToString();
        }

        public class Validate
        {
            public static bool CheckEmail(string email)
            {
                return Regex.IsMatch(email, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            }
        }
    }
}