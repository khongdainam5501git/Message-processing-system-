namespace DAL_MessageSystem.Interfaces.IRepositories
{
    public interface IRepository<T> where T : class
    {
        public T? GetById(int id);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(int id);
        public List<T> GetAll();
        public void Save();
    }
}
