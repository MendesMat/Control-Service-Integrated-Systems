namespace Mendes.ControlService.ManagementAPI.Interfaces;

public interface ICustomerService<TCustomer, TCreateDto, TReadDto, TUpdateDto, TDeleteDto>
{
    TReadDto Post(TCreateDto dto);
    TReadDto Get(int id);
    IEnumerable<TReadDto> GetAll();
    TReadDto Put(int id, TUpdateDto dto);
    void Delete(int id);
}
