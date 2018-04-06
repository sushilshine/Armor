using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSubmission.DataAccess.Entity;

namespace TicketSubmission.DataAccess
{
    public static class DbContextExtension
    {
        public static TKey Post<T, TKey>(this DbContext dbContext, T model) where T : class, IEntity<TKey>
        {
            var entity = dbContext.Set<T>();
            entity.Add(model);
            dbContext.SaveChanges();

            return model.Id;
        }

        public static T Put<T, TKey>(this DbContext dbContext, T model) where T : class, IEntity<TKey>
        {
            var entity = dbContext.Set<T>();
            var entityToUpdate = entity.Find(model.Id);

            if (entityToUpdate == null)
                throw new Exception("Unable to update object.  Object not found with ID: " + model.Id);

            dbContext.Entry(entityToUpdate).CurrentValues.SetValues(model);
            dbContext.SaveChanges();

            return entityToUpdate;
        }

        public static IQueryable<T> Get<T>(this DbContext dbContext) where T : class
        {
            return dbContext.Set<T>().AsQueryable();
        }

        public static IEnumerable<TKey> Post<T, TKey>(this DbContext dbContext, List<T> models) where T : class, IEntity<TKey>
        {
            var entity = dbContext.Set<T>();
            entity.AddRange(models);
            dbContext.SaveChanges();
            return models.Select(m => m.Id).ToList();
        }

        public static async Task<IEnumerable<T>> InvokeStoredProcedureAsync<T>(this DbContext dbContext, string procedureName, params KeyValuePair<string, object>[] parameters)
        {
            string procedureToInvoke = procedureName;
            object[] sqlParameters = CreateSqlParameters(ref procedureToInvoke, parameters);
            return await dbContext.Database.SqlQuery<T>(procedureToInvoke, sqlParameters).ToListAsync();
        }

        public static IEnumerable<T> InvokeStoredProcedure<T>(this DbContext dbContext, string procedureName, params KeyValuePair<string, object>[] parameters)
        {
            string procedureToInvoke = procedureName;
            object[] sqlParameters = CreateSqlParameters(ref procedureToInvoke, parameters);
            return dbContext.Database.SqlQuery<T>(procedureToInvoke, sqlParameters).ToList();
        }

        public static T InvokeStoredProcedureScalar<T>(this DbContext dbContext, string procedureName, params KeyValuePair<string, object>[] parameters)
        {
            string procedureToInvoke = procedureName;
            object[] sqlParameters = CreateSqlParameters(ref procedureToInvoke, parameters);
            return dbContext.Database.SqlQuery<T>(procedureToInvoke, sqlParameters).FirstOrDefault();
        }

        public static Task<List<T>> ExecuteSqlQueryAsync<T>(this DbContext dbContext, string queryString)
        {
            return dbContext.Database.SqlQuery<T>(queryString).ToListAsync();
        }

        public static List<T> ExecuteSqlQuery<T>(this DbContext dbContext, string queryString)
        {
            return dbContext.Database.SqlQuery<T>(queryString).ToList();
        }

        private static object[] CreateSqlParameters(ref string procedureToInvoke, params KeyValuePair<string, object>[] parameters)
        {
            object[] sqlParameters = parameters.Select(parameter => new SqlParameter(parameter.Key, parameter.Value)).Cast<object>().ToArray();
            string parameterString = string.Join(",", parameters.Select(parameter => parameter.Key).ToArray());
            procedureToInvoke = string.Join(" ", procedureToInvoke, parameterString);
            return sqlParameters;
        }
    }
}
