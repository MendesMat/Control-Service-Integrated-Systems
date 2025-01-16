using AutoMapper;
using Mendes.ControlService.ManagementAPI.Abstracts;
using Mendes.ControlService.ManagementAPI.Interfaces;

namespace Mendes.ControlService.ManagementAPI.Services;

public class CustomerService<TCustomer, TCreateDto, TReadDto, TUpdateDto, TDeleteDto>
    : ICustomerService<TCustomer, TCreateDto, TReadDto, TUpdateDto, TDeleteDto>
    where TCustomer : CustomerBase
{
    private readonly IRepository<TCustomer> _customersRepository;
    private readonly IMapper _mapper;

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
        TCustomer? customer = _customersRepository.Get(id);

        if (customer == null)
            throw new KeyNotFoundException($"Customer with ID {id} not found.");

        return _mapper.Map<TReadDto>(customer);
    }

    public IEnumerable<TReadDto> GetAll()
    {
        IQueryable<TCustomer> customers = _customersRepository.GetAll();
        return _mapper.Map<IEnumerable<TReadDto>>(customers);
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
        TCustomer? customer = _customersRepository.Get(id);

        if(customer == null)
            throw new KeyNotFoundException($"Customer with ID {id} not found.");

        _customersRepository.Delete(customer);
    }
}
