using Demo_HR_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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



        //public IActionResult SearchEmployee(int id)
        //{

        //    // step-1 fetch single record from db
        //     var data = db.Employees.Where(Model => Model.EmpId == id).FirstOrDefault();


        //    //var data = db.Employees.ToList();

        //   // var data = db.Employees.FirstOrDefault();



        //    return View(data);
        // }


        
        public IActionResult SearchEmployee()
        {

            var data = db.Employees.ToList();

            return View();
        }



        //// Search employee by EmpId

        //        [HttpPost]
        //        public IActionResult SearchEmployee(int empId)
        //        {
        //            var employee = db.Employees.Where(e => e.EmpId == empId).ToList();
        //            return View(employee);




        //        }



        //[HttpPost]
        //public IActionResult SearchEmployee(int? empId, string empName)
        //{
        //    // Initialize the query
        //    var query = db.Employees.AsQueryable();

        //    // Apply filters based on provided parameters
        //    if (empId.HasValue)
        //    {
        //        query = query.Where(e => e.EmpId == empId.Value);
        //    }

        //    if (!string.IsNullOrEmpty(empName))
        //    {
        //        query = query.Where(e => e.EmpName.Contains(empName));
        //    }

        //    // Execute the query and convert to list
        //    var employees = query.ToList();

        //    // Return the view with the filtered employees
        //    return View(employees);
        //}



        //[HttpPost]
        //public IActionResult SearchEmployee(string searchTerm)
        //{
        //    // Initialize the query
        //    var query = db.Employees.AsQueryable();

        //    // Check if the search term is a number (for Employee ID)
        //    if (int.TryParse(searchTerm, out int empId))
        //    {
        //        // Search by Employee ID
        //        query = query.Where(e => e.EmpId == empId);
        //    }
        //    else
        //    {
        //        // Search by Employee Name (partial match)
        //        query = query.Where(e => e.EmpName.Contains(searchTerm));
        //    }

        //    // Materialize the query by converting it to a list
        //    var employees = query.ToList();

        //    // Return the view with the filtered employees
        //    return View(employees);
        //}


        [HttpPost]
        public IActionResult SearchEmployee(string searchTerm)
        {
            // Initialize the query
            var query = db.Employees.AsQueryable();

            // Check if the search term is a number (for Employee ID)
            if (int.TryParse(searchTerm, out int empId))
            {
                // Search by Employee ID
                query = query.Where(e => e.EmpId == empId);
            }
            else
            {
                // Search by Employee Name (starting with the search term)
                query = query.Where(e => e.EmpName.StartsWith(searchTerm));
            }

            // Materialize the query by converting it to a list
            var employees = query.ToList();

            // Return the view with the filtered employees
            return View(employees);
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

        public IActionResult DeleteEmployee(int id)
        {
            // step-1 fetch single record from db
            var data = db.Employees.Where(Model => Model.EmpId == id).FirstOrDefault();

            db.Employees.Remove(data); // to remove data from db

            db.SaveChanges(); // to save changes to db

            return View();

        }

        public IActionResult EditSuccess(string txtEmpId, string txtEmpName, string txtEmpMobile, string txtEmpEmail, string txtEmpCity, string txtEmpDesignation, string txtEmpSalary)
        {
            // step-1 fetch single record from db
            var data = db.Employees.Where(Model => Model.EmpId ==Convert.ToInt32(txtEmpId)).FirstOrDefault();

            // step-2 assign new values to the fetched record

            data.EmpId = Convert.ToInt32(txtEmpId);
            data.EmpName= txtEmpName;
            data.EmpMobile = txtEmpMobile;
            data.EmpEmail = txtEmpEmail;
            data.EmpCity = txtEmpCity;
            data.EmpDesignation = txtEmpDesignation;
            data.EmpSalary = txtEmpSalary;


            // save the changes to db
            db.SaveChanges();

            return View();
        }


     



    }
}
