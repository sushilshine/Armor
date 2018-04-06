using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TicketSubmission.DataAccess;
using TicketSubmission.DataAccess.Entity;
using TicketSubmission.Mapper;
using TicketSubmission.Models;
using TicketSubmission.Repository;
using TicketSubmissionBusinessLogic;

namespace TicketSubmission.Controllers
{
    public class TicketJournalController : ApiController
    {
        public IEnumerable<TicketJournal> GetTicketJournal()
        {
            TicketSubmissionBL ts = new TicketSubmissionBL(new CustomerRepository(new TicketSubmissionDbContext("TicketSubmissionConnectionString")), new TicketPriorityRepository(new TicketSubmissionDbContext("TicketSubmissionConnectionString")), new TicketJournalRepository(new TicketSubmissionDbContext("TicketSubmissionConnectionString")));
            return ts.GetTicketJournalDetails();
        }
        
        public string PostTicket([FromBody] TicketSubmissionModel ticket)
        {
            ITicketMapper ticketMapper = new TicketMapper();
            var ticketEntity = new Ticket();
            ticketMapper.MapToEntityFromUiModel(ticket, ticketEntity);
            TicketSubmissionBL ts = new TicketSubmissionBL(new CustomerRepository(new TicketSubmissionDbContext("TicketSubmissionConnectionString")), new TicketPriorityRepository(new TicketSubmissionDbContext("TicketSubmissionConnectionString")), new TicketJournalRepository(new TicketSubmissionDbContext("TicketSubmissionConnectionString")));
            return ts.PostTicket(ticketEntity);

        }
    }
}
