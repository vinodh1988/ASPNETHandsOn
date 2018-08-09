using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace FirstApplication
{
    public partial class First : System.Web.UI.Page
    {
        AdventureWorks2014Entities context;
        bool flag = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            context = new AdventureWorks2014Entities();
            var query = from departments in context.Departments
                        select departments;
            GridView1.DataSource = query.ToList();
            GridView1.DataBind();

            var query2 = context.Departments.Select(group => group.GroupName).Distinct();
            DropDownList1.DataSource = query2.ToList();
            DropDownList1.DataBind();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = Label1.Text+"  Request Received and Data Changed";

        }
        

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var max = context.Departments.Select(x => x.DepartmentID).Max();
                //System.Diagnostics.Debug.WriteLine(max);
                //System.Diagnostics.Debug.WriteLine("is The max Value");
                // System.Diagnostics.Debug.WriteLine(max + 1);
                // System.Diagnostics.Debug.WriteLine("is The next Value");
                Department d = new Department();
                d.DepartmentID = Convert.ToInt16(max + 1);
                d.Name = TextBox1.Text;
                d.GroupName = DropDownList1.Text;
                d.ModifiedDate = DateTime.Now;
                context.Departments.Add(d);
                try
                {
                    context.SaveChanges();
                    TextBox1.Text = "";
                    var query = from departments in context.Departments
                                select departments;
                    GridView1.DataSource = query.ToList();
                    GridView1.DataBind();
                    string path = ConfigurationManager.AppSettings["DepartmentDocuments"];

                    FileUpload1.SaveAs(path + FileUpload1.FileName);
                    Label2.Text = "Last record added at " + DateTime.Now;
                    Mailer.Mailer.SendMail("Record Added for Deparments", "A New Record added to Departments @ " + d.ModifiedDate);

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                    Label2.Text = "Record Insertion Failed";
                }
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("Second.aspx");
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (FileUpload1.FileBytes.Length > (1024 * 300)) { 
                    args.IsValid = false;
                    
             }
            else
                args.IsValid = true;
        }
    }
}