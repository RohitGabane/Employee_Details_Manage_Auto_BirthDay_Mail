using Employee_Details_Manage_Auto_BirthDay_Mail.Models;
using Employee_Details_Manage_Auto_BirthDay_Mail.Service;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Details_Manage_Auto_BirthDay_Mail.Controllers
{
    public class EmpController : Controller
    {
        private readonly IEmployeeRepo _employeeRepo;
        public EmpController(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        public IActionResult Index()
        {
            var employee = _employeeRepo.GetAll();
            return View(employee);
        }
        public IActionResult Delete(int id) 
        {
            _employeeRepo.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName, LastName, BirthDate, Email_ID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (_employeeRepo.EmailExists(employee.Email_ID))
                    {
                        ModelState.AddModelError("Email_ID", "Email already exists");
                        return View(employee);
                    }

                    _employeeRepo.Add(employee);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    // You may want to log the exception or handle it accordingly
                    return View(employee);
                }
            }
            return View(employee);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employeeRepo.GetById(id.Value);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( Employee employee)
        {
           

            if (ModelState.IsValid)
            {
                try
                {
                    if (_employeeRepo.EmailExistsForOtherEmployee(employee.Emp_ID, employee.Email_ID))
                    {
                        ModelState.AddModelError("Email_ID", "Email already exists for another employee");
                        return View(employee);
                    }

                    _employeeRepo.Update(employee);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    // You may want to log the exception or handle it accordingly
                    return View(employee);
                }
            }
            return View(employee);
        }

    }
}
