using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSubmission.DataAccess;
using TicketSubmission.DataAccess.Entity;

namespace TicketSubmission.Repository
{
    public class TicketPriorityRepository : ITicketPriorityRepository
    {
        private readonly IDbContext _dbContext;
        public TicketPriorityRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TicketPriority> GetAll()
        {
            return _dbContext.Get<TicketPriority>().ToList();
        }
        public TicketPriority GetById(int? id)
        {
            return _dbContext.Get<TicketPriority>().Where(s=>s.Id==id).SingleOrDefault();
        }

        public int Post(TicketPriority ticketPriority)
        {
            return _dbContext.Post<TicketPriority, int>(ticketPriority);
        }
    }
}
