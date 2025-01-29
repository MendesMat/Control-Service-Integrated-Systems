using Mendes.ControlService.ManagementAPI.Abstracts;
using Mendes.ControlService.ManagementAPI.Data.Context;
using Mendes.ControlService.ManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mendes.ControlService.ManagementAPI.Repositories;

/// <summary>
/// Repositório genérico para manipulação de clientes no banco de dados.
/// Implementa os métodos básicos de CRUD (Criar, Ler, Atualizar, Deletar) para a entidade `CustomerBase`.
/// </summary>
/// <typeparam name="T">Tipo de cliente que herda de `CustomerBase`, como `IndividualCustomer` ou `CompanyCustomer`.</typeparam>

public class CustomersRepository<T> : IRepository<T>
    where T : CustomerBase
{
    private ManagementContext _context;
    private DbSet<CustomerBase> _customersDb => _context.Customers;


    public CustomersRepository(ManagementContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Adiciona um novo cliente ao banco de dados.
    /// </summary>
    /// <param name="customer">O cliente a ser adicionado.</param>
    /// <remarks>Realiza a adição de um cliente no banco de dados e realiza o commit.</remarks>

    public void Post(T customer)
    {
        _customersDb.Add(customer);
        _context.SaveChanges();
    }

    /// <summary>
    /// Obtém um cliente pelo seu ID.
    /// </summary>
    /// <param name="id">O ID do cliente a ser obtido.</param>
    /// <returns>O cliente correspondente ao ID, ou null se não encontrado.</returns>

    public T? Get(int id)
    {
        var result = _customersDb.FirstOrDefault(customer => customer.Id == id);

        return result as T;
    }

    /// <summary>
    /// Obtém todos os clientes com paginação.
    /// </summary>
    /// <param name="skip">Número de registros a serem ignorados (paginando para a próxima página).</param>
    /// <param name="take">Número de registros a serem retornados (quantidade por página).</param>
    /// <returns>Uma lista de clientes paginada.</returns>

    public IQueryable<T> GetAll([FromQuery] int skip, [FromQuery] int take)
    {
        var result = _customersDb.Skip(skip).Take(take).Cast<T>();

        return result;
    }

    /// <summary>
    /// Atualiza um cliente existente no banco de dados.
    /// </summary>
    /// <param name="customer">O cliente com as novas informações.</param>
    /// <remarks>O cliente será atualizado com os dados fornecidos, mas a mudança não será refletida no banco até o `SaveChanges`.</remarks>

    public void Put(T customer)
    {     
        _context.SaveChanges();
    }

    /// <summary>
    /// Deleta um cliente do banco de dados.
    /// </summary>
    /// <param name="customer">O cliente a ser deletado.</param>

    public void Delete(T customer)
    {
        _customersDb.Remove(customer);
        _context.SaveChanges();
    }
}
