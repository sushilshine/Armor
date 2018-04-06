﻿using System;
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
    public class CustomerController : ApiController
    {
        public int CreateCustomer([FromBody]Customer customerDetails)
        {
            TicketSubmissionBL ts = new TicketSubmissionBL(new CustomerRepository(new TicketSubmissionDbContext("TicketSubmissionConnectionString")), new TicketPriorityRepository(new TicketSubmissionDbContext("TicketSubmissionConnectionString")), new TicketJournalRepository(new TicketSubmissionDbContext("TicketSubmissionConnectionString")));
            return ts.CreateCustomer(customerDetails);
        }

        public IEnumerable<Customer> GetCustomer()
        {
            TicketSubmissionBL ts = new TicketSubmissionBL(new CustomerRepository(new TicketSubmissionDbContext("TicketSubmissionConnectionString")), new TicketPriorityRepository(new TicketSubmissionDbContext("TicketSubmissionConnectionString")), new TicketJournalRepository(new TicketSubmissionDbContext("TicketSubmissionConnectionString")));
            return ts.GetCustomerDetails();
        }

    }
}
