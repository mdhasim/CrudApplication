using CrudApplication.Data;
using CrudApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _Db;
        public EmployeeController(ApplicationDbContext Db)
        {
            _Db = Db;
        }
        public IActionResult EmployeeList()
        {
            try
            {
                var empList = _Db.Employees.ToList();
                return View(empList);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public IActionResult Create(int? id) {
            if (id.HasValue)
            {
                var employeeData = _Db.Employees.Find(id);
                return View(employeeData);
            }
            else
            {
                var employeeData = new Employee() {Email="",FirstName="",PhoneNo="",Salary=null};
                return View(employeeData);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee obj) {
            try
            {
                if (ModelState.IsValid) {
                    if (obj.EmpId == 0) {
                        _Db.Employees.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }                    
                    return RedirectToAction("EmployeeList");
                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var empId = await _Db.Employees.FindAsync(id);
                if(empId != null)                {
                    _Db.Employees.Remove(empId);
                    await _Db.SaveChangesAsync();
                }
                
                return RedirectToAction("EmployeeList"); 

            }
            catch (Exception)
            {

                return RedirectToAction("EmployeeList");
            }
        }

    }
}
