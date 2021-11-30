using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskRequestApp.Models
{
    public class Employee
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Mail { get; set; }
        public int WorkShift { get; set; }
        public Manager manager { get; set; }
        public List<Ticket> Ticket { get; set; }
    }
    
}
