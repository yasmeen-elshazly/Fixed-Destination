
using Microsoft.EntityFrameworkCore;
using My_Uber.Context.Context;
using My_Uber.Repositories.Contract;

namespace My_Uber.Repositories.Repository
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        MyUberDbContext uberDbContext;
        DbSet<T> dbset;
        public GenericRepository(MyUberDbContext _uberDbContext)
        {
            uberDbContext = _uberDbContext;
            dbset = uberDbContext.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return dbset;
        }
        public IQueryable<T> GetOne(int id)
        {
            return dbset;
        }
        public void Create(T Entity)
        {
            dbset.Add(Entity);
            uberDbContext.SaveChanges();

        }
        public void Update(T Entity)
        {
            dbset.Update(Entity);
            uberDbContext.SaveChanges();

        }
        public void Delete(T Entity)
        {
            dbset.Remove(Entity);
            uberDbContext.SaveChanges();

        }

    }

}
