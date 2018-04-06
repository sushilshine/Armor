using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSubmission.DataAccess;
using TicketSubmission.DataAccess.Entity;

namespace TicketSubmission.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbContext _dbContext;
        public CustomerRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Customer> GetAll()
        {
            return _dbContext.Get<Customer>().ToList();
        }
        public Customer GetById(int id)
        {
            return _dbContext.Get<Customer>().Where(s=>s.Id==id).SingleOrDefault();
        }

        public int Post(Customer customer)
        {
            return _dbContext.Post<Customer, int>(customer);
        }
    }
}
