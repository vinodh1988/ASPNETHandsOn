using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using HiQPdf;
using MVCApp.Models;

namespace MVCApp.Controllers
{
    public class DataController : Controller
    {
        AdventureWorks2014Entities context = new AdventureWorks2014Entities();
        HrContext context1 = new HrContext();
        // GET: Data
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult People()
        {
            ViewBag.Programmers = new List<String>() {
                "John",
                "Arjun",
                "Feroz",
                "Ganesh"
            };
            return View();
        }

        public ActionResult PeopleGroup()
        {
            List<Person> plist = context.People.ToList();
            return View(plist);
        }

        public ActionResult Departments()
        {
            List<Department> dlist = context1.Departments.ToList();
            return View(dlist);
        }

        public ActionResult Edit(int id)
        {
            Department d = context1.Departments.Single(x => x.DepartmentID == id);
            return View(d);

        }

        [HttpPost]
        public ActionResult Edit(Department d)
        {
            if (ModelState.IsValid)
            {
                Department obj = context1.Departments.Single(x => x.DepartmentID == d.DepartmentID);
                obj.Name = d.Name;
                obj.GroupName = d.GroupName;
                obj.ModifiedDate = d.ModifiedDate;
                context1.SaveChanges();
                return RedirectToAction("Departments");
            }
            return View(d);

        }
        [HttpPost]
        public ActionResult Create(Department d)
        {
            if (ModelState.IsValid)
            {
                context1.Departments.Add(d);
                context1.SaveChanges();
                return RedirectToAction("Departments");
            }
            return View(d);
        }

        public ActionResult Create()
        {
            var groups = context1.Departments.Select(x => x.GroupName).Distinct().ToList<string>();
            SelectList l = new SelectList(groups);
            ViewBag.groups = l;
            return View();
        }

        public ActionResult Export()
        {

            var query = from department in context1.Departments
                        select department;
                      
            List<Department> dlist = query.ToList<Department>();
            DataTable set = ToDataTable<Department>(dlist);

            var workbook = new XLWorkbook();
            workbook.AddWorksheet(set,"Departments");


            workbook.SaveAs("D:\\Report" + DateTime.Now.Hour + "" + DateTime.Now.Millisecond + ".xlsx");
            return View();
        }


       
        public ActionResult DownloadPdf()
        {
            List<Department> dlist = context1.Departments.ToList();
            // get the HTML code of this view
            string htmlToConvert = RenderViewAsString("Departments", dlist);

            // the base URL to resolve relative images and css
            String thisPageUrl = this.ControllerContext.HttpContext.Request.Url.AbsoluteUri;
            String baseUrl =
                thisPageUrl.Substring(0, thisPageUrl.Length - "Data/DownloadPdf".Length);

            // instantiate the HiQPdf HTML to PDF converter
            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();

             PdfDocument pdf= htmlToPdfConverter.ConvertHtmlToPdfDocument(htmlToConvert,baseUrl);
            pdf.Security.OpenPassword = "vinodh";

            // render the HTML code as PDF in memory
            byte[] pdfBuffer = pdf.WriteToMemory();
                //htmlToPdfConverter.ConvertHtmlToMemory(htmlToConvert, baseUrl);
          
            // send the PDF file to browser
            FileResult fileResult = new FileContentResult(pdfBuffer, "application/pdf");
            fileResult.FileDownloadName = "Departments.pdf";

            return fileResult;
        }

        public string RenderViewAsString(string viewName, object model)
        {
            // create a string writer to receive the HTML code
            StringWriter stringWriter = new StringWriter();

            // get the view to render
            ViewEngineResult viewResult = ViewEngines.Engines.FindView(ControllerContext, viewName, null);
            // create a context to render a view based on a model
            ViewContext viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    new ViewDataDictionary(model),
                    new TempDataDictionary(),
                    stringWriter
                    );

            // render the view to a HTML code
            viewResult.View.Render(viewContext, stringWriter);

            // return the HTML code
            return stringWriter.ToString();
        }

        public DataTable ToDataTable<T>(List<T> items)

        {

            DataTable dataTable = new DataTable(typeof(T).Name);

            System.Diagnostics.Debug.WriteLine("inside This");
            //Get all the properties

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in Props)

            {

                //Setting column names as Property names

                
                dataTable.Columns.Add(prop.Name);
                System.Diagnostics.Debug.WriteLine(prop.Name);



            }

            foreach (T item in items)

            {

                var values = new object[Props.Length];

                for (int i = 0; i < Props.Length; i++)

                {

                    //inserting property values to datatable rows

                    values[i] = Props[i].GetValue(item, null);
                    System.Diagnostics.Debug.WriteLine(values[i]);
                }

                dataTable.Rows.Add(values);

            }

            //put a breakpoint here and check datatable

            return dataTable;

        }
    }
}