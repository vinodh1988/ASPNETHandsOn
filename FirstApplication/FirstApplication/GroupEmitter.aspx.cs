using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstApplication
{
    public partial class GroupEmitter : System.Web.UI.Page
    {
        AdventureWorks2014Entities context;
        protected void Page_Load(object sender, EventArgs e)
        {
            context = new AdventureWorks2014Entities();


               var query = context.Departments.Select((x) => x.GroupName).Distinct();
              var json=Newtonsoft.Json.JsonConvert.SerializeObject(query.ToList());

            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(json);
            Response.End();
        }
    }
}