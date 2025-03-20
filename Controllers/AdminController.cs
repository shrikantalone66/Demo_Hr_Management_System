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












        //[HttpPost]
        //public IActionResult AddEmployee(int txtEmpId, string txtEmpName, string txtEmpMobile, string txtEmpEmail, string txtEmpCity, string txtEmpDesignation, string txtEmpSalary )
        //{

        //    Employee obj1 = new Employee();
        //    obj1.EmpId = txtEmpId;
        //    obj1.EmpName = txtEmpName;
        //    obj1.EmpMobile = txtEmpMobile;
        //    obj1.EmpEmail = txtEmpEmail;
        //    obj1.EmpCity = txtEmpCity;
        //    obj1.EmpDesignation = txtEmpDesignation;
        //    obj1.EmpSalary = txtEmpSalary;


        //    db.Employees.Add(obj1);
        //    db.SaveChanges();

        //    ViewBag.message = "Employee added successfully";


        //    return View();
        //}


        [HttpPost]
        public IActionResult AddEmployee(int txtEmpId, string txtEmpName, string txtEmpMobile, string txtEmpEmail,
    string txtEmpCity, string txtEmpDesignation, string txtEmpSalary, IFormFile txtEmpPhoto)
        {
            string fileName = null;


            if (txtEmpPhoto != null && txtEmpPhoto.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                Directory.CreateDirectory(uploadsFolder); // Ensure the folder exists

                fileName = Guid.NewGuid().ToString() + Path.GetExtension(txtEmpPhoto.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    txtEmpPhoto.CopyTo(stream);
                }
            }
            else
            {
                Console.WriteLine("No file uploaded.");
            }

            Employee obj1 = new Employee
            {
                EmpId = txtEmpId,
                EmpName = txtEmpName,
                EmpMobile = txtEmpMobile,
                EmpEmail = txtEmpEmail,
                EmpCity = txtEmpCity,
                EmpDesignation = txtEmpDesignation,
                EmpSalary = txtEmpSalary,
                EmpPhoto = fileName // Store only the filename in the database
            };



            db.Employees.Add(obj1);
            db.SaveChanges();
            ViewBag.message = "Employee added successfully";
            return View();
        }



        //[HttpPost]
        //public IActionResult AddEmployee(int txtEmpId, string txtEmpName, string txtEmpMobile, string txtEmpEmail,
        //                         string txtEmpCity, string txtEmpDesignation, string txtEmpSalary,
        //                         IFormFile txtEmpPhoto)
        //{


        //        // Save file name in the database
        //        Employee obj1 = new Employee();
        //        obj1.EmpId = txtEmpId;
        //        obj1.EmpName = txtEmpName;
        //        obj1.EmpMobile = txtEmpMobile;
        //        obj1.EmpEmail = txtEmpEmail;
        //        obj1.EmpCity = txtEmpCity;
        //        obj1.EmpDesignation = txtEmpDesignation;
        //        obj1.EmpSalary = txtEmpSalary;
        //       // Save file name in database





        public IActionResult ShowEmployee()
        {

            var data = db.Employees.ToList();

            return View(data);
        }



    


        
        public IActionResult SearchEmployee()
        {

            var data = db.Employees.ToList();

            return View();
        }



  


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



        public IActionResult DeleteEmployee(int id)
        {
            // step-1 fetch single record from db
            var data = db.Employees.Where(Model => Model.EmpId == id).FirstOrDefault();

            db.Employees.Remove(data); // to remove data from db

            db.SaveChanges(); // to save changes to db

            return View();

        }





        public IActionResult EditEmployee(int id)
        {

            var data = db.Employees.Where(Model => Model.EmpId == id).FirstOrDefault();
            return View(data);
        }




        //public IActionResult EditSuccess(string txtEmpId, string txtEmpName, string txtEmpMobile, string txtEmpEmail, string txtEmpCity, string txtEmpDesignation, string txtEmpSalary , IFormFile txtEmpPhoto)
        //{
        //    // step-1 fetch single record from db
        //    var data = db.Employees.Where(Model => Model.EmpId ==Convert.ToInt32(txtEmpId)).FirstOrDefault();

        //    // step-2 assign new values to the fetched record

        //    data.EmpId = Convert.ToInt32(txtEmpId);
        //    data.EmpName= txtEmpName;
        //    data.EmpMobile = txtEmpMobile;
        //    data.EmpEmail = txtEmpEmail;
        //    data.EmpCity = txtEmpCity;
        //    data.EmpDesignation = txtEmpDesignation;
        //    data.EmpSalary = txtEmpSalary;


        //    // save the changes to db
        //    db.SaveChanges();

        //    return View();
        //}





        //public IActionResult EditSuccess(string txtEmpId, string txtEmpName, string txtEmpMobile, string txtEmpEmail, string txtEmpCity, string txtEmpDesignation, string txtEmpSalary)
        //{
        //    // step-1 fetch single record from db
        //    var data = db.Employees.Where(Model => Model.EmpId == Convert.ToInt32(txtEmpId)).FirstOrDefault();

        //    // step-2 assign new values to the fetched record

        //    data.EmpId = Convert.ToInt32(txtEmpId);
        //    data.EmpName = txtEmpName;
        //    data.EmpMobile = txtEmpMobile;
        //    data.EmpEmail = txtEmpEmail;
        //    data.EmpCity = txtEmpCity;
        //    data.EmpDesignation = txtEmpDesignation;
        //    data.EmpSalary = txtEmpSalary;


        //    // save the changes to db
        //    db.SaveChanges();

        //    return View();
        //}


        [HttpPost]
        public IActionResult EditSuccess(string txtEmpId, string txtEmpName, string txtEmpMobile, string txtEmpEmail,
            string txtEmpCity, string txtEmpDesignation, string txtEmpSalary, IFormFile txtEmpPhoto)
        {
            // Step-1: Fetch the existing employee record from the database
            var data = db.Employees.Where(e => e.EmpId == Convert.ToInt32(txtEmpId)).FirstOrDefault();

            if (data == null)
            {
                return NotFound(); // Return an error if the employee is not found
            }

            // Step-2: Assign new values to the fetched record
            data.EmpName = txtEmpName;
            data.EmpMobile = txtEmpMobile;
            data.EmpEmail = txtEmpEmail;
            data.EmpCity = txtEmpCity;
            data.EmpDesignation = txtEmpDesignation;
            data.EmpSalary = txtEmpSalary;

            // Step-3: Handle image upload if a new image is provided
            if (txtEmpPhoto != null && txtEmpPhoto.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                Directory.CreateDirectory(uploadsFolder); // Ensure folder exists

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(txtEmpPhoto.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    txtEmpPhoto.CopyTo(stream);
                }

                // Delete the old image if it exists
                if (!string.IsNullOrEmpty(data.EmpPhoto))
                {
                    var oldFilePath = Path.Combine(uploadsFolder, data.EmpPhoto);
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                // Save new filename to the database
                data.EmpPhoto = fileName;
            }

            // Step-4: Save the changes to the database
            db.SaveChanges();

            return RedirectToAction("ShowEmployee"); // Redirect to employee listing page
        }




    }
}
