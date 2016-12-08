using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Ims.PM.UI
{
    public class PmUI
    {
        /// <summary>
        /// ��GridView��Ϊ�յ�ʱ�򣬽�����GridView��Div����Ϊ���ɼ�
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="div"></param>
        public static void SetGridViewDivVisible(GridView gv,HtmlGenericControl div)
        {
            if (gv.Rows.Count == 0)
                div.Visible = false;
            else
                div.Visible = true;
        }
    }
}
