namespace Mendes.ControlService.ManagementAPI.Interfaces;

public interface IService<TEntity, TCreateDto, TReadDto, TUpdateDto>
{
    TReadDto Post(TCreateDto dto);
    TReadDto Get(int id);
    IEnumerable<TReadDto> GetAll();
    TReadDto Put(int id, TUpdateDto dto);
    void Delete(int id);
}
