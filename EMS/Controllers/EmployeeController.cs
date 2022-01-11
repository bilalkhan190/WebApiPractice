using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EMS.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<MVCEmpModel> emplist;
            HttpResponseMessage response = GlobalVariables.httpClient.GetAsync("EmployeeService").Result;
            //convert result in ienumrable 
            emplist = response.Content.ReadAsAsync<IEnumerable<MVCEmpModel>>().Result;
            return View(emplist);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id==0)
                return View(new MVCEmpModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.httpClient.GetAsync("EmployeeService/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MVCEmpModel>().Result);
            }
                

        }

        [HttpPost]
        public ActionResult AddOrEdit(MVCEmpModel model)
        {
            if (model.ID == 0)
            {
                model.Status = true;
                model.CreatedDate = DateTime.Now;
                HttpResponseMessage response = GlobalVariables.httpClient.PostAsJsonAsync("EmployeeService", model).Result;
                return RedirectToAction("Index");
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.httpClient.PutAsJsonAsync("EmployeeService/"+model.ID, model).Result;
                return RedirectToAction("Index");
            }
           
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.httpClient.DeleteAsync("EmployeeService"+id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}