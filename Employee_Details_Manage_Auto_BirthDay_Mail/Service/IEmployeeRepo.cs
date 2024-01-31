using Employee_Details_Manage_Auto_BirthDay_Mail.Models;

namespace Employee_Details_Manage_Auto_BirthDay_Mail.Service
{
    public interface IEmployeeRepo
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
        bool EmailExists(string? email_ID);
        bool EmailExistsForOtherEmployee(int emp_ID, string? email_ID);
    }
}
