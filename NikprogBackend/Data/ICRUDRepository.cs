namespace NikprogServerClient.Data
{
    public interface ICRUDRepository<TEntity> where TEntity : class
    {
        void Create(TEntity obj);
        void Delete(string id);
        TEntity Read(string id);
        IQueryable<TEntity> ReadAll();
        void Update(TEntity obj);
    }
}