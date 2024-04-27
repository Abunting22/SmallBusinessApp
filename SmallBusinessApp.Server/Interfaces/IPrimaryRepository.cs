namespace SmallBusinessApp.Server.Interfaces
{
    public interface IPrimaryRepository<T> where T : class
    {
        public Task<List<T>> GetAll();
        public Task<bool> Add(T type);
        public Task<bool> Update(T type);
        public Task<bool> Delete(int id);
        public Task<T> GetById(int id);
    }
}
  