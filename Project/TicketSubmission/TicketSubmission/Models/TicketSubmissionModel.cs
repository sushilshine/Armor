using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketSubmission.Models
{
   public enum PriorityType
    {
        High=1,
        Medium=2,
        Low=3
    }
    public class TicketSubmissionModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public PriorityType PriorityId { get; set; }
        public string TicketSubject { get; set; }
        public string TicketDescription { get; set; }
        public string AlertResponse { get; set; }
    }
}