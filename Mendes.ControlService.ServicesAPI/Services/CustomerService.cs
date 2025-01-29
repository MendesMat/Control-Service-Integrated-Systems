using AutoMapper;
using Mendes.ControlService.ManagementAPI.Abstracts;
using Mendes.ControlService.ManagementAPI.Interfaces;

namespace Mendes.ControlService.ManagementAPI.Services;

public class CustomerService<TCustomer, TCreateDto, TReadDto, TUpdateDto>
    : ICustomerService<TCustomer, TCreateDto, TReadDto, TUpdateDto>
    where TCustomer : CustomerBase
{
    private readonly IRepository<TCustomer> _customersRepository;
    private readonly IMapper _mapper;


    // Query pagination
    private int skip = 0;
    private int take = 50;

    public CustomerService(IRepository<TCustomer> customersRepository, IMapper mapper)
    {
        _customersRepository = customersRepository;
        _mapper = mapper;
    }

    public TReadDto Post(TCreateDto dto)
    {
        var customer = _mapper.Map<TCustomer>(dto);
        _customersRepository.Post(customer);

        return _mapper.Map<TReadDto>(customer);
    }

    public TReadDto Get(int id)
    {
        var customer = _customersRepository.Get(id);

        if (customer == null)
            throw new KeyNotFoundException($"Customer with ID {id} not found.");

        var result = _mapper.Map<TReadDto>(customer);

        return result;
    }

    public IEnumerable<TReadDto> GetAll()
    {
        var customers = _customersRepository.GetAll(skip, take).ToList();
        var result = _mapper.Map<IEnumerable<TReadDto>>(customers);

        return result;
    }

    public TReadDto Put(int id, TUpdateDto dto)
    {
        var customer = _customersRepository.Get(id);

        if (customer == null)
            throw new KeyNotFoundException($"Customer with ID {id} not found.");

        _mapper.Map(dto, customer);
        _customersRepository.Put(customer);

        return _mapper.Map<TReadDto>(customer);
    }

    public void Delete(int id)
    {
        var customer = _customersRepository.Get(id);

        if(customer == null)
            throw new KeyNotFoundException($"Customer with ID {id} not found.");

        _customersRepository.Delete(customer);
    }
}
