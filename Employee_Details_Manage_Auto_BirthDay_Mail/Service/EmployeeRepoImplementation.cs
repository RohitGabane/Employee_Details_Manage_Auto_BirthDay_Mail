using Employee_Details_Manage_Auto_BirthDay_Mail.Models;
using Employee_Details_Manage_Auto_BirthDay_Mail.Service;
namespace Employee_Details_Manage_Auto_BirthDay_Mail.Service
{ 
    public class EmployeeRepoImplementation : IEmployeeRepo
    {
        private readonly EmpDbContext _dbContext;
        public EmployeeRepoImplementation(EmpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            var Employee = _dbContext.Employee.FirstOrDefault(c => c.Emp_ID == id);
            if(Employee!=null)
            {
                _dbContext.Employee.Remove(Employee);
                _dbContext.SaveChanges();
            }
        }

        public bool EmailExists(string? email_ID)
        {
            return _dbContext.Employee.Any(c=>c.Email_ID== email_ID);
        }

        public bool EmailExistsForOtherEmployee(int emp_ID, string? email_ID)
        {
            return _dbContext.Employee.Any(e => e.Emp_ID != emp_ID && e.Email_ID == email_ID);
        }

        void IEmployeeRepo.Add(Employee employee)
        {
            if (_dbContext.Employee.Any(c => c.Email_ID == employee.Email_ID))
            {
                Console.WriteLine("Email already Exit");
                return;
            }
            _dbContext.Employee.Add(employee);
            _dbContext.SaveChanges();
        }

        IEnumerable<Employee> IEmployeeRepo.GetAll()
        {
            return _dbContext.Employee.ToList();
        }

        Employee IEmployeeRepo.GetById(int id)
        {
            return _dbContext.Employee.FirstOrDefault(c => c.Emp_ID == id);
        }

       

        void IEmployeeRepo.Update(Employee employee)
        {
            var ExistingEmp = _dbContext.Employee.FirstOrDefault(c => c.Emp_ID == employee.Emp_ID);
            if (ExistingEmp != null)
            {
                ExistingEmp.FirstName = employee.FirstName;
                ExistingEmp.LastName = employee.LastName;
                ExistingEmp.BirthDate = employee.BirthDate;
                ExistingEmp.Email_ID = employee.Email_ID;

                _dbContext.SaveChanges();
            }
        }
    }
}
