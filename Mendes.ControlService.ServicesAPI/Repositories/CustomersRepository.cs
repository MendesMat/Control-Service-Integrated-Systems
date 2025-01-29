using Mendes.ControlService.ManagementAPI.Abstracts;
using Mendes.ControlService.ManagementAPI.Data.Context;
using Mendes.ControlService.ManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mendes.ControlService.ManagementAPI.Repositories;

public class CustomersRepository<T> : IRepository<T>
    where T : CustomerBase
{
    private ManagementContext _context;
    private DbSet<CustomerBase> _customersDb => _context.Customers;


    public CustomersRepository(ManagementContext context)
    {
        _context = context;
    }

    public void Post(T customer)
    {
        _customersDb.Add(customer);
        _context.SaveChanges();
    }

    public T? Get(int id)
    {
        var result = _customersDb.FirstOrDefault(customer => customer.Id == id);

        return result as T;
    }

    public IQueryable<T> GetAll([FromQuery] int skip, [FromQuery] int take)
    {
        var result = _customersDb.Skip(skip).Take(take).Cast<T>();

        return result;
    }

    public void Put(T customer)
    {     
        _context.SaveChanges();
    }

    public void Delete(T customer)
    {
        _customersDb.Remove(customer);
        _context.SaveChanges();
    }
}
