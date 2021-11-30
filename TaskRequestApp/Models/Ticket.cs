using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskRequestApp.Models
{
    public enum TicketType
    {
        OpenTicket = 1,
        ReadyForAssigned = 2,
        Rewiew = 3,
        Completed = 4,
        Assigned = 5,
        Closed = 6,
    }
    public enum LevelOfDifficulty
    {
        VeryEasy = 1,
        Easy = 2,
        Medium = 3,
        Hard = 4,
        VeryHard = 5,
    }
    public enum LevelOfPriority
    {
        First = 1,
        Second = 2,
        Three = 3,
        Four = 4,
        Five = 5,
    }

    public class Ticket
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Subject { get; set; }
        public string Description { get; set; }
        public TicketType TicketType { get; set; }
        public LevelOfDifficulty Difficulty { get; set; }
        public LevelOfPriority Priority { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime AssigneDate { get; set; }
        public DateTime ReviewDate { get; set; }
        public DateTime CloseDate { get; set; }
        public DateTime CompleteDate { get; set; }
        public Customer customer { get; set; }
        public string customerId { get; set; }
        public Employee employee { get; set; }
        public string employeeId { get; set; }


    }
}
