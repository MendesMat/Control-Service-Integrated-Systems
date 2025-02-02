using Mendes.ControlService.ManagementAPI.Data.Context;
using Mendes.ControlService.ManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mendes.ControlService.ManagementAPI.Repositories;

/// <summary>
/// Repositório genérico para manipulação de entidades no banco de dados.
/// Implementa os métodos básicos de CRUD (Criar, Ler, Atualizar, Deletar) para qualquer entidade que implemente <see cref="IEntity"/>.
/// </summary>
/// <typeparam name="T">O tipo da entidade a ser manipulada, que deve implementar <see cref="IEntity"/>.</typeparam>

public class EntityRepository<T> : IRepository<T>
    where T : class, IEntity
{
    private readonly ManagementContext _context;
    private readonly DbSet<T> _dbSet;

    public EntityRepository(ManagementContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    /// <summary>
    /// Adiciona uma nova entidade ao banco de dados.
    /// </summary>
    /// <param name="entity">A entidade a ser adicionada.</param>
    
    public void Post(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    /// <summary>
    /// Obtém uma entidade pelo seu ID.
    /// </summary>
    /// <param name="id">O ID da entidade a ser obtida.</param>
    /// <returns>A entidade correspondente ao ID fornecido ou <c>null</c> se não for encontrada.</returns>
    
    public T? Get(int id)
    {
        return _dbSet.FirstOrDefault(entity => entity.Id == id);
    }

    /// <summary>
    /// Obtém todas as entidades com suporte a paginação.
    /// </summary>
    /// <param name="skip">Número de registros a serem ignorados (para paginação).</param>
    /// <param name="take">Número de registros a serem retornados.</param>
    /// <returns>Uma coleção de entidades paginada.</returns>
    
    public IQueryable<T> GetAll([FromQuery] int skip, [FromQuery] int take)
    {
        return _dbSet.Skip(skip).Take(take);
    }

    /// <summary>
    /// Atualiza uma entidade existente no banco de dados.
    /// </summary>
    /// <param name="entity">A entidade com os dados atualizados.</param>
    
    public void Put(T entity)
    {
        _context.SaveChanges();
    }

    /// <summary>
    /// Remove uma entidade do banco de dados.
    /// </summary>
    /// <param name="entity">A entidade a ser removida.</param>
    
    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }
}