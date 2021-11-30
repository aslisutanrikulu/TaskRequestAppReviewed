using System;
using TaskRequestApp.Models;
using TaskRequestApp.Repository;

namespace TaskRequestApp.Services
{
    public class TicketServices
    {


        TicketRepository _ticketRepository;
        EmployeeRepository _employeeRepository;
        public TicketServices(TicketRepository ticketRepository, EmployeeRepository employeeRepository)
        {
            _ticketRepository = ticketRepository;
            _employeeRepository = employeeRepository;

        }
        /// <summary>
        /// Ticket konusu boş geçilemez ve 50 karakterden fazla girilemez.Ticket açıklaması boş geçilemez ve 500 karakterden fazla girilemez.
        /// </summary>
        /// <param name="ticket"></param>
        public void AddTicket(Ticket ticket)
        {
            if (string.IsNullOrEmpty(ticket.Subject))
            {
                throw new Exception("boş geçilemez.");
            }
            if (ticket.Subject.Length > 50)
            {
                throw new Exception("subject max 50 karakter olabilir.");
            }
            if (string.IsNullOrEmpty(ticket.Description))
            {
                throw new Exception("boş geçilemez.");
            }
            if (ticket.Description.Length > 500)
            {
                throw new Exception("Description alanı max 500 karakter olabilir.");
            }
            ticket.TicketType = TicketType.OpenTicket;
            ticket.OpenDate = DateTime.Now;
            _ticketRepository.Add(ticket);

        }
        /// <summary>
        /// gelen type a göre ticket type güncellenir.
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="ticketType"></param>
        public void UpdateTicketType(Ticket ticket, TicketType ticketType)
        {
            ticket.TicketType = ticketType;
            _ticketRepository.Update(ticket);
        }
        /// <summary>
        /// çalışana iş atama yapılır
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="employeeId"></param>
        public void AssignedTicket(Ticket ticket, string empId, Employee emp)
        {
            var employee = _employeeRepository.Find(empId);

            if ((int)ticket.Difficulty == 0)
            {
                throw new Exception("zorluk derecesi boş geçilemez.");
            }
            if ((int)ticket.Priority == 0)
            {
                throw new Exception("boş geçemezsiniz.");
            }

            int count = 0;
            foreach (var item in employee.Ticket)
            {
                if (item.Difficulty == LevelOfDifficulty.Hard)
                {
                    count++;
                    if (count > 3)
                    {
                        throw new Exception("derecesi zor olan 3den fazla iş ataması yapılamaz.");
                    }
                    if (item.OpenDate > DateTime.Now.Date)
                    {
                        throw new Exception("ayda 3 zor iş ataması yapılabilir.");
                    }
                }
                if (employee.WorkShift > 160)
                {
                    throw new Exception("160 saatten fazla iş ataması yapılamaz");
                }
                employee.Ticket.Add(ticket);
                _employeeRepository.Update(employee);
            }
            ticket.employeeId = empId;
            _ticketRepository.Update(ticket);
        }
        public void SetDifficulty(Ticket ticket, LevelOfDifficulty difficulty)
        {
            ticket.Difficulty = difficulty;
            _ticketRepository.Update(ticket);
        }
        public void SetPriority(Ticket ticket, LevelOfPriority priority)
        {
            ticket.Priority = priority;
            _ticketRepository.Update(ticket);
        }

        public void SetWorkShift(Employee Emp, Ticket ticket)
        {
            int workshift;

            if ((int)ticket.Priority == 5)
            {
                workshift = 5 * 8;
            }
            if ((int)ticket.Priority == 4)
            {
                workshift = 4 * 8;
            }
            if ((int)ticket.Priority == 3)
            {
                workshift = 3 * 8;
            }
            if ((int)ticket.Priority == 2)
            {
                workshift = 2 * 8;
            }
            if ((int)ticket.Priority == 1)
            {
                workshift = 8;
            }
            workshift = Emp.WorkShift;
            _employeeRepository.Update(Emp);
        }


    }
}
