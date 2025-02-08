using Demo_HR_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_HR_Management_System.Controllers
{
    public class AdminController : Controller
    {


        private readonly DemoHrManagementSystemContext db;
        public AdminController(DemoHrManagementSystemContext context)
        {
            db = context;

        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(int txtEmpId,string txtEmpName,string txtEmpMobile,string txtEmpEmail, string txtEmpCity, string txtEmpDesignation , string txtEmpSalary)
        {

            Employee obj1 = new Employee();
            obj1.EmpId = txtEmpId;
            obj1.EmpName = txtEmpName;
            obj1.EmpMobile = txtEmpMobile;
            obj1.EmpEmail = txtEmpEmail;
            obj1.EmpCity = txtEmpCity;
            obj1.EmpDesignation = txtEmpDesignation;
            obj1.EmpSalary = txtEmpSalary;
            db.Employees.Add(obj1);
            db.SaveChanges();

            ViewBag.message = "Employee added successfully";


            return View();
        }

        public IActionResult ShowEmployee()
        {

            var data = db.Employees.ToList();

            return View(data);
        }

        public IActionResult SearchEmployee()
        {
            return View();
        }

        public IActionResult LogoutEmployee()
        {
            return View();
        }

        public IActionResult EditEmployee(int id)
        {

            var data = db.Employees.Where(Model => Model.EmpId == id).FirstOrDefault();
            return View(data);
        }

        public IActionResult DeleteEmployee()
        {
            return View();
        }

        public IActionResult EditSuccess()
        {
            return View();
        }

    }
}
