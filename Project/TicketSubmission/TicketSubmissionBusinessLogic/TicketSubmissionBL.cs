using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSubmission.DataAccess;
using TicketSubmission.DataAccess.Entity;
using TicketSubmission.Repository;
using System.Net.Mail;
using System.Text;

namespace TicketSubmissionBusinessLogic
{
    public class TicketSubmissionBL
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITicketPriorityRepository _ticketPriorityRepository;
        private readonly ITicketJournalRepository _ticketJournalRepository;
        public TicketSubmissionBL(ICustomerRepository customerRepository,ITicketPriorityRepository ticketPriorityRepository, ITicketJournalRepository ticketJournalRepository)
        {
            _customerRepository = customerRepository;
            _ticketPriorityRepository = ticketPriorityRepository;
            _ticketJournalRepository = ticketJournalRepository;
        }
        public IEnumerable<Customer> GetCustomerDetails()
        {
            return _customerRepository.GetAll();
        }
        public IEnumerable<Ticket> GetSubmittedTicket()
        {
            return _ticketJournalRepository.GetAllSubmittedTicket();
        }

        public IEnumerable<TicketPriority> GetTicketPriority()
        {
            return _ticketPriorityRepository.GetAll();
        }

        public int CreateCustomer(Customer customerDetails)
        {
            return _customerRepository.Post(customerDetails);
        }

        public string PostTicket(Ticket ticket)
        {
            ticket.AlertResponse = AlertResponse(ticket.PriorityId);
            ticket.PriorityId = ticket.PriorityId == 0 ? null : ticket.PriorityId;          
            ticket.DateCaptured = DateTime.Now;
            ticket.TicketStatus = "New";            
            _ticketJournalRepository.Post(ticket);
            //SendEmail(ticket);
            return ticket.AlertResponse;
        }

        private string AlertResponse(int? priorityId)
        {
            var responseTime = _ticketPriorityRepository.GetById(priorityId);
            var AlertResponse = "";
            if (responseTime != null)
            {
                var dt = DateTime.Now.AddHours(responseTime.ResponseTime);
                AlertResponse = "Your Ticket Submitted Successfully. You will get Response from customer support by " + dt;
            }
            else
            {
                AlertResponse = "Your Ticket Submitted Successfully.";
            }
            return AlertResponse;
        }

        public IEnumerable<TicketJournal> GetTicketJournalDetails()
        {
            return _ticketJournalRepository.GetAll();
        }

        public int CreateTicketJournal(TicketJournal ticketJournalDetails)
        {
           return _ticketJournalRepository.Post(ticketJournalDetails);
        }

        //private void SendEmail(Ticket ticket)
        //{
        //    SmtpClient client = new SmtpClient();
        //    client.Port = 587;
        //    client.Host = "smtp.gmail.com";
        //    client.EnableSsl = true;
        //    client.Timeout = 10000;
        //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    client.UseDefaultCredentials = false;
        //    client.Credentials = new System.Net.NetworkCredential("armr.supp987@gmail.com", "password");

        //    MailMessage mm = new MailMessage("armr.supp987@gmail.com", ticket.Customer.EmailAddress, ticket.TicketSubject, ticket.AlertResponse);
        //    mm.BodyEncoding = UTF8Encoding.UTF8;
        //    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

        //    client.Send(mm);
        //}
    }
}
