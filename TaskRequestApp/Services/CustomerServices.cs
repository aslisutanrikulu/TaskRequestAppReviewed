using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskRequestApp.Models;
using TaskRequestApp.Repository;

namespace TaskRequestApp.Services
{
    public class CustomerServices
    {
        CustomerRepository _customerRepository;

        public CustomerServices(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public void AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new Exception("customer boş geçilemez");
            }

            if (string.IsNullOrEmpty(customer.Name))
            {
                throw new Exception("customer ismi boş geçilemez");
            }

            customer.Name = customer.Name.Trim();

            _customerRepository.Add(customer);
        }

    }
}

