using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        { 

            var a = ViewState["data"];
            var b = Session["data"];
            var c = Application["data"];

            Label1.Text = a == null ? "0" : a.ToString();
            Label2.Text = b == null ? "0" : b.ToString();
            Label3.Text = c == null ? "0" : c.ToString();
        }
    }
}