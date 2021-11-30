using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskRequestApp.Models;

namespace TaskRequestApp.Repository
{
    public class CustomerRepository
    {
        private readonly TaskAppDbContext _db;
        public CustomerRepository()
        {
            _db = new TaskAppDbContext();
        }
        public void Add(Customer customer)
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();
        }
        public Customer Find(string id)
        {
            return _db.Customers.Find(id);
        }
        public List<Customer> List()
        {
            return _db.Customers.ToList();
        }
    }
}
