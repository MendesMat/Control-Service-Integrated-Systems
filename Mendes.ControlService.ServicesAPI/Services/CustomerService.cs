using AutoMapper;
using Mendes.ControlService.ManagementAPI.Abstracts;
using Mendes.ControlService.ManagementAPI.Interfaces;

namespace Mendes.ControlService.ManagementAPI.Services;

/// <summary>
/// Serviço genérico para gerenciamento de clientes, incluindo operações de CRUD (Criar, Ler, Atualizar, Deletar).
/// Utiliza um repositório genérico e um mapeador AutoMapper para transformar DTOs em modelos de dados e vice-versa.
/// </summary>
/// <typeparam name="TCustomer">Tipo de cliente, que deve herdar de `CustomerBase` (por exemplo, `IndividualCustomer` ou `CompanyCustomer`).</typeparam>
/// <typeparam name="TCreateDto">Tipo do DTO usado para criação de um cliente.</typeparam>
/// <typeparam name="TReadDto">Tipo do DTO usado para leitura de informações de um cliente.</typeparam>
/// <typeparam name="TUpdateDto">Tipo do DTO usado para atualização de um cliente.</typeparam>

public class CustomerService<TCustomer, TCreateDto, TReadDto, TUpdateDto>
    : ICustomerService<TCustomer, TCreateDto, TReadDto, TUpdateDto>
    where TCustomer : CustomerBase
{
    private readonly IRepository<TCustomer> _customersRepository;
    private readonly IMapper _mapper;


    // Variáveis de paginação para consulta
    private int skip = 0;
    private int take = 50;

    public CustomerService(IRepository<TCustomer> customersRepository, IMapper mapper)
    {
        _customersRepository = customersRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Cria um novo cliente e retorna um DTO com os dados do cliente criado.
    /// </summary>
    /// <param name="dto">O DTO com as informações do novo cliente.</param>
    /// <returns>O DTO representando o cliente criado.</returns>
    /// <exception cref="KeyNotFoundException">Se o cliente não for encontrado na operação de leitura.</exception>

    public TReadDto Post(TCreateDto dto)
    {
        var customer = _mapper.Map<TCustomer>(dto);
        _customersRepository.Post(customer);

        return _mapper.Map<TReadDto>(customer);
    }

    /// <summary>
    /// Obtém um cliente por seu ID e retorna um DTO com os dados do cliente.
    /// </summary>
    /// <param name="id">O ID do cliente a ser retornado.</param>
    /// <returns>O DTO com as informações do cliente.</returns>
    /// <exception cref="KeyNotFoundException">Se o cliente não for encontrado.</exception>

    public TReadDto Get(int id)
    {
        var customer = _customersRepository.Get(id);

        if (customer == null)
            throw new KeyNotFoundException($"Customer with ID {id} not found.");

        var result = _mapper.Map<TReadDto>(customer);

        return result;
    }

    /// <summary>
    /// Obtém todos os clientes com paginação.
    /// </summary>
    /// <returns>Uma lista de DTOs representando os clientes.</returns>

    public IEnumerable<TReadDto> GetAll()
    {
        var customers = _customersRepository.GetAll(skip, take).ToList();
        var result = _mapper.Map<IEnumerable<TReadDto>>(customers);

        return result;
    }

    /// <summary>
    /// Atualiza as informações de um cliente existente e retorna um DTO com os dados atualizados.
    /// </summary>
    /// <param name="id">O ID do cliente a ser atualizado.</param>
    /// <param name="dto">O DTO com as novas informações do cliente.</param>
    /// <returns>O DTO com os dados do cliente após a atualização.</returns>
    /// <exception cref="KeyNotFoundException">Se o cliente não for encontrado.</exception>

    public TReadDto Put(int id, TUpdateDto dto)
    {
        var customer = _customersRepository.Get(id);

        if (customer == null)
            throw new KeyNotFoundException($"Customer with ID {id} not found.");

        _mapper.Map(dto, customer);
        _customersRepository.Put(customer);

        return _mapper.Map<TReadDto>(customer);
    }

    /// <summary>
    /// Deleta um cliente com o ID especificado.
    /// </summary>
    /// <param name="id">O ID do cliente a ser deletado.</param>
    /// <exception cref="KeyNotFoundException">Se o cliente não for encontrado.</exception>

    public void Delete(int id)
    {
        var customer = _customersRepository.Get(id);

        if(customer == null)
            throw new KeyNotFoundException($"Customer with ID {id} not found.");

        _customersRepository.Delete(customer);
    }
}
