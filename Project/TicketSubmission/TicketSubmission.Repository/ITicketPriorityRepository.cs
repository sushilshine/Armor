using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSubmission.DataAccess.Entity;

namespace TicketSubmission.Repository
{
    public interface ITicketPriorityRepository
    {
        List<TicketPriority> GetAll();
        int Post(TicketPriority Ticket);
        TicketPriority GetById(int? id);
    }
}
