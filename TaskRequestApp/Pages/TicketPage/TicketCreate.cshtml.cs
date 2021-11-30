using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskRequestApp.Models;
using TaskRequestApp.Repository;
using TaskRequestApp.Services;

namespace TaskRequestApp.Pages.TicketPage
{
    public class TicketCreateModel : PageModel
    {
        private readonly TicketRepository _tRepo;
        private readonly CustomerRepository _cRepo;
        private readonly TicketServices _tService;
        private readonly CustomerServices _cService;

        public TicketCreateModel(TicketRepository ticketRepository, CustomerRepository customerRepository, TicketServices ticketService, CustomerServices customerService)
        {
            _tRepo = ticketRepository;
            _cRepo = customerRepository;
            _tService = ticketService;
            _cService = customerService;
        }
        [BindProperty]
        public Ticket TicketInput { get; set; }

        [BindProperty]

        public string selectedcustomerýd { get; set; }

        public List<SelectListItem> SelectListItems = new List<SelectListItem>();

        public void OnGet()
        {
            var Customer = _cRepo.List();
            SelectListItems = Customer.Select(a => new SelectListItem { Value = a.Id, Text = a.Name }).ToList();
        }
        public void OnPostSave()
        {
            if (ModelState.IsValid)
            {
                _tService.AddTicket(TicketInput);

            }
            TicketInput.OpenDate = DateTime.Now;
        }
    }
}
