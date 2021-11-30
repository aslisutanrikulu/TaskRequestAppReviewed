using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskRequestApp.Models;

namespace TaskRequestApp.Repository
{
    public class EmployeeRepository
    {
        private readonly TaskAppDbContext _db;
        public EmployeeRepository()
        {
            _db = new TaskAppDbContext();
        }
        public void Add(Employee employee)
        {
            _db.Employees.Add(employee);
            _db.SaveChanges();
        }
        public Employee Find(string id)
        {
            return _db.Employees.Find(id);
        }
        public List<Employee> List()
        {
            return _db.Employees.ToList();
        }
        public void Update(Employee employee)
        {
            _db.Employees.Update(employee);
            _db.SaveChanges();
        }
    }
}
