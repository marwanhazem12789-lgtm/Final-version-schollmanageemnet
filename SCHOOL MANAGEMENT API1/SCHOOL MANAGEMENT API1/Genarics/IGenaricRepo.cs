namespace SCHOOL_MANAGEMENT_API1.Genarics
{
    public interface IGenaricRepo<T> where T : class
    {
        List<T> GetAll();
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        T GetById(int id);

    }
}
