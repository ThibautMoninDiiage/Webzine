namespace Webzine.Business.Contracts
{
    public interface Service<T>
    {
        public void Add(T item);

        public void delete(T item);

        public T Find(int id);

        public IEnumerable<T> FindAll();

    }
}