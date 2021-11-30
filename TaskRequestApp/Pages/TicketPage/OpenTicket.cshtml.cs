using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskRequestApp.Models;
using TaskRequestApp.Repository;
using TaskRequestApp.Services;

namespace TaskRequestApp.Pages.TicketPage
{
    public class OpenTicketModel : PageModel
    {
        private readonly TicketRepository _tRepo;
        private readonly CustomerRepository _cRepo;
        private readonly TicketServices _tService;
 
        [BindProperty]
        public List <Ticket> OpenTickets{ get; set; } //tickettan openticket olanlar listeleniyor.
        public OpenTicketModel(TicketRepository ticketRepository, CustomerRepository customerRepository, TicketServices ticketService)
        {
            _tRepo = ticketRepository;
            _cRepo = customerRepository;
            _tService = ticketService;
            OpenTickets = new List<Ticket>();// her seferinde veri alabilsin diye newlendi.
        }
        [BindProperty]
        public Ticket Ticket { get; set; }
        public List <Ticket> Tickets { get; set; }
        public void OnGet()
        {
            Tickets = _tRepo.List();
            

            foreach (var item in Tickets)
            {
                if (item.TicketType == TicketType.OpenTicket)
                {
                 
                    OpenTickets.Add(item);
                }
            }
            OpenTickets=OpenTickets.OrderByDescending(x => x.OpenDate).ToList(); //tarih sýralarýna göre sýraladý.
        }

    }
}
