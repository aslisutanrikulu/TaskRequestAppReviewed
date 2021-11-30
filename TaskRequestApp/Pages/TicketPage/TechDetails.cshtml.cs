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
    public class TechDetailsModel : PageModel
    {
        private readonly TicketRepository _tRepo;
        private readonly TicketServices _tService;
        private readonly CustomerRepository _cRepo;
        private readonly CustomerServices _cService;
        private readonly TicketServices ticketService;
        public TechDetailsModel(TicketRepository ticketRepository, CustomerRepository customerRepository, TicketServices ticketservices)
        {
            _tRepo = ticketRepository;
            _cRepo = customerRepository;
            this.ticketService = ticketservices;
        }
        
        [BindProperty]
        public LevelOfPriority priority { get; set; }
        [BindProperty]
        public LevelOfDifficulty difficulty { get; set; }
        public Ticket TicketInput { get; set; } = new Ticket();
        [BindProperty]
        public string Id { get; set; }
        [BindProperty]
        public string CustomerName { get; set; }
        public string CustomerId { get; set; }
        [BindProperty]
        public string selectedTicketId { get; set; }

        private Array Listdifficulty = Enum.GetValues(typeof(LevelOfDifficulty));

        private Array Listpriority = Enum.GetValues(typeof(LevelOfPriority));

        public void OnGet(string id)
        {
            Id = id;
            ViewData["Id"] = id;
            TicketInput = _tRepo.Find(id);
            CustomerId = TicketInput.customerId.ToString();
        }
        public void OnPostSetDifficulty()
        {
            TicketInput = _tRepo.Find(selectedTicketId);
            ticketService.SetDifficulty(TicketInput, difficulty);
        }
        public void OnPostSetPriority()
        {
            TicketInput = _tRepo.Find(selectedTicketId);
            ticketService.SetPriority(TicketInput, priority);
        }
        public void OnPostSave(string id)
        {
            if (ModelState.IsValid)
            {
                TicketInput = _tRepo.Find(selectedTicketId);
                TicketInput.TicketType = TicketType.ReadyForAssigned;
                _tRepo.Update(TicketInput);
            }
        }
    }
}
