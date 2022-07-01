using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using te.Models;
using te.ViewModels;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace te.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetUser([DataSourceRequest] DataSourceRequest request)
        {
           
            var userlist = db.tblusers.ToList();
            return Json(userlist.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public void AddEmployee(tbluser emp)
        {
            db.tblusers.Add(emp);
            db.SaveChanges();

           
        }
        [HttpPost]
        public void UpdateEmployee(tbluser emp)
        {
            tbluser obj = db.tblusers.FirstOrDefault(x=>x.userid==emp.userid);

            obj.userid = emp.userid;
            obj.email = emp.email;
            obj.mobile = emp.mobile;
            obj.password = emp.password;
            obj.dob = emp.dob;
            db.Entry(obj).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteEmployee(tbluser emp)
        {
            var data = db.tblusers.Find(emp.userid);
            db.tblusers.Remove(data);
            db.SaveChanges();
        }
    }
}