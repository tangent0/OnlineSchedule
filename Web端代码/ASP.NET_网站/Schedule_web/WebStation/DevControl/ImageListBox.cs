using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;

namespace DevControl
{
    [Serializable]
    [ToolboxData("<{0}:ImageListBox id='ImageListBox1' runat='server' AutoShowOptionPrefix='true'></{0}:ImageListBox>")]
    public class ImageListBox : ListBox
    {
        /// <summary>
        /// 选项前缀
        /// </summary>
        [Browsable(true)]
        public string OptionPrefix
        { get; set; }

        /// <summary>
        /// 是否自动每个内容项增加前缀
        /// </summary>
        [Browsable(true)]
        public bool AutoShowOptionPrefix
        { get; set; }

        protected override void RenderContents(System.Web.UI.HtmlTextWriter writer)
        {
            bool flag = false;
            ListItem item = null;
            for (int i = 0; i < Items.Count; i++)
            {
                item = Items[i];
                writer.WriteBeginTag("option");
                if (item.Enabled)
                {
                    if (item.Selected)
                    {
                        if (flag)
                        { this.VerifyMultiSelect(); }
                        flag = true;
                        writer.WriteAttribute("selected", "selected");
                    }

                    writer.WriteAttribute("value", item.Value, true);
                    writer.Write('>');
                    if (AutoShowOptionPrefix && !string.IsNullOrEmpty(OptionPrefix))
                    { writer.Write(OptionPrefix); }

                    writer.Write(item.Text);
                    writer.WriteEndTag("option");
                    writer.WriteLine();
                }
            }
        }
    }
}
