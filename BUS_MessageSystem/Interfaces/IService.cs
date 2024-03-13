namespace BUS_MessageSystem.Interfaces
{
    public interface IService<T> where T : class
    {
        public T? GetById(int id);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(int id);
        public List<T> GetAll();
        public void Save();
    }
}
