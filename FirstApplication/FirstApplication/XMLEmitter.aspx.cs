using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace FirstApplication
{
    public partial class XMLEmitter : System.Web.UI.Page
    {
        AdventureWorks2014Entities context;
        protected void Page_Load(object sender, EventArgs e)
        {
            context = new AdventureWorks2014Entities();
            XElement element = new XElement("Departments",
                (from departments in context.Departments
                 select new
                 {
                    departments.DepartmentID,
                    departments.Name,
                    departments.GroupName,
                    departments.ModifiedDate

                 }).ToList().Select(x=> 
                 new XElement("Department",new XElement("DepartmentID",x.DepartmentID),
                 new XElement("Name",x.Name),
                 new XElement("GroupName", x.GroupName),
                 new XElement("ModifiedDate", x.ModifiedDate)
                 )));

            Response.Clear();
            Response.ContentType = "application/xml; charset=utf-8";
            Response.Write(element);
            Response.End();
        }
    }
}