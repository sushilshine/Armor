using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TicketSubmission.DataAccess;
using TicketSubmission.DataAccess.Entity;
using TicketSubmission.Repository;
using TicketSubmissionBusinessLogic;

namespace TicketSubmission.Controllers
{
    public class TicketPriorityController : ApiController
    {
        public IEnumerable<TicketPriority> GetTicketPriority()
        {
            TicketSubmissionBL ts = new TicketSubmissionBL(new CustomerRepository(new TicketSubmissionDbContext("TicketSubmissionConnectionString")), new TicketPriorityRepository(new TicketSubmissionDbContext("TicketSubmissionConnectionString")), new TicketJournalRepository(new TicketSubmissionDbContext("TicketSubmissionConnectionString")));
            return ts.GetTicketPriority();
        }
    }
}
