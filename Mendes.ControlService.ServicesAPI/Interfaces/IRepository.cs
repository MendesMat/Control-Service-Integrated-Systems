namespace Mendes.ControlService.ManagementAPI.Interfaces;

public interface IRepository<T> where T : class
{
    void Post(T entity);

    T? Get(int id);
    IQueryable<T> GetAll();

    void Put(T entity);
    void Delete(T entity);
}
