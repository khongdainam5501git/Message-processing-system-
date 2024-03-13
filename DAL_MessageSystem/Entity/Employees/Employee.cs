using DAL_MessageSystem.Entity.Accounts;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DAL_MessageSystem.Enum;

namespace DAL_MessageSystem.Entity.Employees
{
    [Table("Employees")]
    public class Employee
    {
        public Employee() { }
        public Employee(string name, EmployeeType employeeType, Account account)
        {
            Name = name;
            EmployeeType = employeeType;
            Account = account;
        }

        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public Account? Account { get; set; }
        public EmployeeType? EmployeeType { get; set; }
    }
}
