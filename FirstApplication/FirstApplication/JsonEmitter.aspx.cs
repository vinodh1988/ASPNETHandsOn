using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace FirstApplication
{
    public partial class JsonEmitter : System.Web.UI.Page
    {
        AdventureWorks2014Entities context;
        protected void Page_Load(object sender, EventArgs e)
        {
            context = new AdventureWorks2014Entities();


            // var query = context.Departments.Select((x) => x.Name);
            // var json=Newtonsoft.Json.JsonConvert.SerializeObject(query.ToList());

           var temp= Request.QueryString["group"];
            var query2 = from departments in context.Departments
                         where departments.GroupName==temp
                         select new
                         {
                             departments.DepartmentID,
                             departments.Name,
                             departments.GroupName,
                             departments.ModifiedDate

                         };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(query2.ToList());

            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(json);
            Response.End();
        }
    }
}