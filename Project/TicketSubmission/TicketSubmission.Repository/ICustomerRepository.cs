using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSubmission.DataAccess.Entity;

namespace TicketSubmission.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        int Post(Customer customer);
    }
}
