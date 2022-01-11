using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EmployeeManagementWithApi.Models;

namespace EmployeeManagementWithApi.Controllers
{
    public class EmployeeServiceController : ApiController
    {
        private EmpDBEntities db = new EmpDBEntities();

        public IQueryable<Employee> GetEmployees()
        {
            return db.Employees.Where(x =>x.IsDeleted == false);
        }

        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(long Id)
        {
            Employee emp = db.Employees.Find(Id);
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }
        [ResponseType(typeof(Employee))]
        public IHttpActionResult AddEmployee(Employee model)
        {
           
            db.Employees.Add(model);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = model.ID }, model);
        }

        bool IsExist(long id)
        {
            var record = db.Employees.Any(x => x.ID.Equals(id));
            if (record)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    
        public IHttpActionResult PutEmployee(long id, Employee model)
        {
            if (id != model.ID)
            {
                return BadRequest();
            }

            Employee emp = new Employee();
            emp.ID = model.ID;
            emp.Name = model.Name;
            emp.Salary = model.Salary;
            emp.Department = model.Department;
            emp.Designation = model.Designation;
            emp.Status = model.Status;
            emp.ModifiedDate = DateTime.Now;
            emp.ModifiedBy = 1;
            emp.IsDeleted = false;

           db.Entry(emp).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IsExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
               
            }
           

            return StatusCode(HttpStatusCode.NoContent);
        }






        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(long Id)
        {
            Employee emp = db.Employees.Find(Id);
            if (emp == null)
            {
                return NotFound();
            }
            emp.IsDeleted = true;
            db.SaveChanges();
            return Ok(emp);


        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
