using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSubmission.DataAccess.Entity
{
    [Table("TicketJournal")]
    public class Ticket : IEntity<int>
    {
        [Column("TicketId")]
        public int Id { get; set; }
        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public int? PriorityId { get; set; }
        public string TicketSubject { get; set; }
        public string TicketDescription { get; set; }
        public string TicketStatus { get; set; }
        public DateTime DateCaptured { get; set; }
        public string AlertResponse { get; set; }

    }
}
