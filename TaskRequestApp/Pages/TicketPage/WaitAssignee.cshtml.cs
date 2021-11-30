using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskRequestApp.Models;
using TaskRequestApp.Repository;
using TaskRequestApp.Services;

namespace TaskRequestApp.Pages.TicketPage
{
    public class WaitAssigneeModel : PageModel
    {

        private readonly TicketRepository _tRepo;
        private readonly CustomerRepository _cRepo;
        private readonly TicketServices _tServices;
        private readonly EmployeeRepository _eRepo;

        [BindProperty]
        public List<Ticket> TicketInput { get; set; } = new List<Ticket>();

        public List<SelectListItem> SelectListItems { get; set; } = new List<SelectListItem>();

        [BindProperty]
        public List<Ticket> Tickets { get; set; }

        [BindProperty]
        public Ticket Ticket { get; set; } = new Ticket();

        [BindProperty]
        public Employee EmployeeInput { get; set; }

        [BindProperty]
        public string Id { get; set; }

        [BindProperty]
        public string TicketId { get; set; }

        public WaitAssigneeModel(TicketRepository tRepo, CustomerRepository cRepo, TicketServices ticketService, EmployeeRepository eRepo)
        {
            _tRepo = tRepo;
            _cRepo = cRepo;
            _tServices = ticketService;
            _eRepo = eRepo;
        }
        public void OnGet()
        {
            var Employees = _eRepo.List();

            SelectListItems = Employees.Select(a => new SelectListItem { Value = a.Id, Text = a.Name }).ToList();
            Tickets = _tRepo.List();
            if (Tickets.Count != 0)
            {
                foreach (var item in Tickets)
                {
                    if (item.TicketType == TicketType.ReadyForAssigned)
                    {
                        TicketInput.Add(item);
                    }
                }
            }
        }
        public void OnPostSave(string Id, string TicketId)
        {
            Id = Id;

            TicketId = TicketId;
            Ticket = _tRepo.Find(Id);
            Ticket.TicketType = TicketType.Assigned;
            Ticket.employeeId = Id;
            Ticket.AssigneeDate = DateTime.Now.Date;
            _tRepo.Update(Ticket);
            _tServices.AssignedTicket(ticket: Ticket, empId: EmployeeInput.Id, emp: EmployeeInput);
            _tServices.SetWorkShift(Emp: EmployeeInput, ticket: Ticket);
        }
    }
}
