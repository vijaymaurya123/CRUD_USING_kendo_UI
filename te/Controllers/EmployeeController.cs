using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using te.Models;
using te.ViewModels;

namespace te.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetEmployees(DataSourceRequest req)
        {
        
            List<Usermodel> gvms = new List<Usermodel>();
            gvms = (from a in db.tblusers                   
                    select new Usermodel()
                    {
                        userid = a.userid,
                        email = a.email,
                        mobile = a.mobile,
                        password = a.password,
                        dob=a.dob
                    }).ToList();

            return Json(gvms.ToDataSourceResult(req), JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetCategory()
        {
          
            var res = db.tblusers.Select(x => new {
                Id = x.userid,
                email = x.email,
                mobile= x.email,
                password=x.password,
                dob=x.dob
            });

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public void AddEmployee(tbluser emp)
        {
           
            db.tblusers.Add(emp);
            db.SaveChanges();
        }
        public void UpdateEmployee(tbluser emp)
        {
          
            tbluser objToUpdate = db.tblusers.Find(emp.userid);
            objToUpdate.email = emp.email;
            objToUpdate.mobile = emp.mobile;
            objToUpdate.password = emp.password;
            objToUpdate.dob = emp.dob;

            db.Entry(objToUpdate).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteEmployee(tbluser emp)
        {
          
            tbluser objToDelete = db.tblusers.Find(emp.userid);
            db.tblusers.Remove(objToDelete);
            db.SaveChanges();
        }
    }
}