using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSubmission.DataAccess.Entity
{
    [Table("TicketPriority")]
    public class TicketPriority : IEntity<int>
    {
        [Column("PriorityId")]
        public int Id { get; set; }
        public string PriorityType { get; set; }
        public double ResponseTime { get; set; }        
    }
}
