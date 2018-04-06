using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSubmission.DataAccess.Entity;

namespace TicketSubmission.DataAccess
{
   public interface IDbContext
    {
        IQueryable<T> Get<T>() where T : class;

        TKey Post<T, TKey>(T Model) where T : class, IEntity<TKey>;

        T Put<T, TKey>(T Model) where T : class, IEntity<TKey>;

        IDbSet<T> Set<T, TKey>(T Model) where T : class, IEntity<TKey>;

        int SaveChanges();

    }
}
