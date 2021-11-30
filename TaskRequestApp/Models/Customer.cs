
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TaskRequestApp.Models
{
    public class Customer
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Code { get; set; }
        public string Mail { get; set; }

        private HashSet<Ticket> tickets = new HashSet<Ticket>();
        public IReadOnlySet<Ticket> Tickets => tickets;
 


    }
}
