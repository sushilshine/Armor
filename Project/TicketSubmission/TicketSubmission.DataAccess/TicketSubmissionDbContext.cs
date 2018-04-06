using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSubmission.DataAccess.Entity;

namespace TicketSubmission.DataAccess
{
    public class TicketSubmissionDbContext : DbContext, IDbContext
    {
        public TicketSubmissionDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<DbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public IQueryable<T> Get<T>() where T : class => DbContextExtension.Get<T>(this);

        TKey IDbContext.Post<T, TKey>(T model) => DbContextExtension.Post<T, TKey>(this, model);

        T IDbContext.Put<T, TKey>(T model) => DbContextExtension.Put<T, TKey>(this, model);

        IDbSet<T> IDbContext.Set<T, TKey>(T Model) => base.Set<T>();

        int IDbContext.SaveChanges() => base.SaveChanges();

        public DbSet<Customer> Customer { get; set; }
        public DbSet<TicketPriority> TicketPriority { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
    }
}
