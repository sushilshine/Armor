using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSubmission.DataAccess;
using TicketSubmission.DataAccess.Entity;

namespace TicketSubmission.Repository
{
    public class TicketJournalRepository : ITicketJournalRepository
    {
        private readonly IDbContext _dbContext;
        public TicketJournalRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TicketJournal> GetAll()
        {
            return _dbContext.Get<TicketJournal>().ToList();
        }

        public List<Ticket> GetAllSubmittedTicket()
        {
            return _dbContext.Get<Ticket>().ToList();
        }

        public TicketPriority GetById(int id)
        {
            return _dbContext.Get<TicketPriority>().Where(s => s.Id == id).SingleOrDefault();
        }

        public int Post(Ticket ticket)
        {
            return _dbContext.Post<Ticket, int>(ticket);
        }

        public int Post(TicketJournal ticketJournal)
        {
            return _dbContext.Post<TicketJournal, int>(ticketJournal);
        }
    }
}
