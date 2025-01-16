using Mendes.ControlService.ManagementAPI.Data.Context;
using Mendes.ControlService.ManagementAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mendes.ControlService.ManagementAPI.Repositories;

public class CustomersRepository<T> : IRepository<T>
    where T : class
{
    private readonly ManagementContext _context;
    private readonly DbSet<T> _dbSet;

    public CustomersRepository(ManagementContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public void Post(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    public T? Get(int id) => _dbSet.Find(id);

    public IQueryable<T> GetAll() => _dbSet.AsQueryable();

    public void Put(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }
}

