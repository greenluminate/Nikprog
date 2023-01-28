namespace NikprogServerClient.Logic
{
    public interface ICRUDLogic<TEntity> where TEntity : class
    {
        void Create(TEntity obj);
        void Delete(string id);
        TEntity Read(string id);
        IEnumerable<TEntity> ReadAll();
        void Update(TEntity obj);
    }
}