using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskRequestApp.Models
{
    public class Manager
    {
        public string Id { get; set; }  = Guid.NewGuid().ToString();
        public string Name { get; set; }
      
    }
}
