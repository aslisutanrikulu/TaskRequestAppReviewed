using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using TaskRequestApp.Models;
using TaskRequestApp.Repository;
using TaskRequestApp.Services;

namespace TaskRequestApp.Pages.TicketPage
{
    public class AssignedTicketModel : PageModel
    {
        private readonly TicketRepository _tRepo;
        private readonly CustomerRepository _cRepo;
        private readonly TicketServices _tServices;
        private readonly EmployeeRepository _eRepo;

        public AssignedTicketModel(TicketRepository tRepo, CustomerRepository cRepo, TicketServices ticketService, EmployeeRepository eRepo)
        {
            _tRepo = tRepo;
            _cRepo = cRepo;
            _tServices = ticketService;
            _eRepo = eRepo;
        }

        [BindProperty]
        public Ticket Ticket { get; set; }

        [BindProperty]
        public Employee EmployeeInput { get; set; }

        [BindProperty]
        public string selectedcustomerId { get; set; }

        [BindProperty]
        public List<Ticket> TicketInput { get; set; } = new List<Ticket>();

        [BindProperty]
        public List<Ticket> Tickets { get; set; }

        [BindProperty]
        public List<Employee> Employees { get; set; } = new List<Employee>();

        [BindProperty]
        public string Id { get; set; }

        public void OnGet()
        {
            Tickets = _tRepo.List();

            var employeeRepo = _eRepo.List();
            if (Tickets.Count != 0)
            {
                foreach (var item in Tickets)
                {
                    if (item.TicketType == TicketType.Assigned)
                    {
                        TicketInput.Add(item);
                    }
                    foreach (var item2 in employeeRepo)
                    {
                        if (item.employeeId == item2.Id)
                        {
                            Employees.Add(item2);
                        }
                    }
                }
            }

        }
    }
}
