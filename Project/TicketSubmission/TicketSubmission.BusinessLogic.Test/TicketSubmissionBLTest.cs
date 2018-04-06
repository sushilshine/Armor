using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketSubmissionBusinessLogic;
using TicketSubmission.BusinessLogic.Test.stub;
using TicketSubmission.DataAccess.Entity;
using System.Collections.Generic;
using System.Linq;

namespace TicketSubmission.BusinessLogic.Test
{
    [TestClass]
    public class TicketSubmissionBLTest
    {
        [TestMethod]
        public void GetCustomerDetailsInvokeMethod()
        {
            var mockedCustomer = new List<Customer> { new Customer { Id = 1, LastName = "lastName", FirstName = "firstName" } };
            var customer = new Customer { Id = 1, LastName = "lastName", FirstName = "firstName" };
            var mockedTicket = new Ticket { Id = 1, Customer = customer, CustomerId = 1, AlertResponse = "Test Response", DateCaptured = DateTime.Now, PriorityId = 2, TicketDescription = "test", TicketStatus = "New", TicketSubject = "tttttt" } ;
            var target = new TicketSubmissionBL(new CustomerRepositoryStub(mockedCustomer), new TicketPriorityRepositoryStub(), new TicketJournalRepositoryStub(mockedTicket));
            var result = target.GetCustomerDetails();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() == 1);
            Assert.ReferenceEquals(mockedCustomer, result);
        }        
    }
}
