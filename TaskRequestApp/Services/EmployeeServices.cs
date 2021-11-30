using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskRequestApp.Models;
using TaskRequestApp.Repository;

namespace TaskRequestApp.Services
{
    public class EmployeeServices
    {
        EmployeeRepository _employeeRepository;
        public EmployeeServices(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void EmployeeAdd(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.Name))
            {
                throw new Exception("employee ismi boş geçilemez");
            }
            employee.Name = employee.Name.Trim();
            _employeeRepository.Add(employee);
        }
    }
}
