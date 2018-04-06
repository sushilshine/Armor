using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSubmission.DataAccess.Entity;

namespace TicketSubmission.Repository
{
    public interface ITicketJournalRepository
    {
        List<TicketJournal> GetAll();
        int Post(TicketJournal TicketJournal);
        int Post(Ticket TicketJournal);
        List<Ticket> GetAllSubmittedTicket();
    }
}
