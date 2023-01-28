using Microsoft.EntityFrameworkCore;

namespace NikprogServerClient.Data
{
    public class CRUDRepository<TEntity> : ICRUDRepository<TEntity> where TEntity : class
    {
        internal NikprogDbContext db;
        internal DbSet<TEntity> dbSet;

        public CRUDRepository(NikprogDbContext db)
        {
            this.db = db;
            dbSet = db.Set<TEntity>();
        }

        public void Create(TEntity obj)
        {
            dbSet.Add(obj);
            db.SaveChanges();
        }

        public TEntity Read(string id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<TEntity> ReadAll()
        {
            return dbSet.AsQueryable();
        }

        public void Update(TEntity obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(string id)
        {
            dbSet.Remove(Read(id));
            db.SaveChanges();
        }
    }
}
