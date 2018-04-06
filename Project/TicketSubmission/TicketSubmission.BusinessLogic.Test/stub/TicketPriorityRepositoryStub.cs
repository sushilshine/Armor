using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSubmission.DataAccess.Entity;
using TicketSubmission.Repository;

namespace TicketSubmission.BusinessLogic.Test.stub
{
   public class TicketPriorityRepositoryStub : ITicketPriorityRepository
    {
        private readonly List<TicketPriority> _ticketPriority;
        public List<TicketPriority> GetAll()
        {
            return _ticketPriority;
        }

        public TicketPriority GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public int Post(TicketPriority Ticket)
        {
            throw new NotImplementedException();
        }
    }
}
