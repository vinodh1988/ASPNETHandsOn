using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstApplication
{
    public partial class DemoToday : System.Web.UI.Page
    {
        private int data;
        protected void Page_Load(object sender, EventArgs e)
        {
            /* if (!IsPostBack)
                 data = 144;


                data = 188;*/
            // if (data == 0)
            // data = 120;

            if (!IsPostBack) {
                //TextBox1.Text = (101).ToString();
                ViewState["data"] = 100;
                if(Session["data"]==null)
                Session["data"] = 100;
                if(Application["data"]==null)
                Application["data"] = 100;
            }

            data = Convert.ToInt32(ViewState["data"]);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            data = data + 1;
            TextBox1.Text = data.ToString();
            ViewState["data"] = data + 10;
            Session["data"] = data + 10;
            Application["data"] = data + 10;
        }
    }
}