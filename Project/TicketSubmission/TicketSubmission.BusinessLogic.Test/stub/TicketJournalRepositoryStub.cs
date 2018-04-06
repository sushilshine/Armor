using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSubmission.DataAccess.Entity;
using TicketSubmission.Repository;

namespace TicketSubmission.BusinessLogic.Test.stub
{
   public class TicketJournalRepositoryStub : ITicketJournalRepository
    {
        private readonly Ticket _ticket;

        public TicketJournalRepositoryStub(Ticket ticket)
        {
            _ticket = ticket;
        }
        public List<TicketJournal> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetAllSubmittedTicket()
        {
            throw new NotImplementedException();
        }

        public int Post(Ticket TicketJournal)
        {
            throw new NotImplementedException();
        }

        public int Post(TicketJournal Ticket)
        {
            throw new NotImplementedException();
        }
    }
}
