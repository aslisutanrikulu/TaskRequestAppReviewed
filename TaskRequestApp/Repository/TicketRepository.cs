using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskRequestApp.Models;

namespace TaskRequestApp.Repository
{
    public class TicketRepository
    {
        private readonly TaskAppDbContext _db;
          public TicketRepository()
          {
            _db = new TaskAppDbContext();
          }
        public void Add(Ticket ticket)
        {
            _db.Tickets.Add(ticket);
            _db.SaveChanges();
        }
        public Ticket Find(string id)
        {
            return _db.Tickets.Find(id);
        }
        public List<Ticket> List()
        {
            return _db.Tickets.ToList();
        }

        public void Update(Ticket ticket)
        {
            _db.Tickets.Update(ticket);
            _db.SaveChanges();
        }
    }
}
