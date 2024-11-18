namespace WebApplication2.Repositories
{
    public interface IRepository<T>
    {
        public List<T> GetAll();
        public T GetById(string ID);
        public string GetLastID();
        public bool Create(T model);
        public bool Update(T model);
        public bool Delete(string ID);
    }
}
