using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSubmission.DataAccess.Entity;
using TicketSubmission.Repository;

namespace TicketSubmission.BusinessLogic.Test.stub
{
   public class CustomerRepositoryStub : ICustomerRepository
    {
        private readonly List<Customer> _customers;

        public CustomerRepositoryStub(List<Customer> customer)
        {
            _customers = customer;
        }
        public List<Customer> GetAll()
        {
            return _customers;
        }

        public int Post(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
