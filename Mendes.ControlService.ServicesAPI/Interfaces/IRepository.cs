using Microsoft.AspNetCore.Mvc;

namespace Mendes.ControlService.ManagementAPI.Interfaces;

public interface IRepository<T>
{
    void Post(T entity);

    T? Get(int id);
    IQueryable<T> GetAll([FromQuery] int skip, [FromQuery] int take);

    void Put(T entity);
    void Delete(T entity);
}