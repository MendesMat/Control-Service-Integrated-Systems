using AutoMapper;
using Mendes.ControlService.ManagementAPI.Interfaces;

namespace Mendes.ControlService.ManagementAPI.Abstracts
{

    /// <summary>
    /// Classe base para os serviços que lidam com a lógica de negócios e interações com o repositório para operações CRUD.
    /// Esta classe fornece métodos genéricos para criar, ler, atualizar e excluir entidades, além de realizar a conversão
    /// entre entidades e DTOs (Data Transfer Objects) utilizando AutoMapper.
    /// </summary>
    /// <typeparam name="TEntity">Tipo da entidade de dados que será manipulada pelo serviço.</typeparam>
    /// <typeparam name="TCreateDto">DTO utilizado para criar uma nova entidade.</typeparam>
    /// <typeparam name="TReadDto">DTO utilizado para representar a entidade ao ser retornada para o cliente.</typeparam>
    /// <typeparam name="TUpdateDto">DTO utilizado para atualizar uma entidade existente.</typeparam>

    public abstract class ServiceBase<TEntity, TCreateDto, TReadDto, TUpdateDto>
        : IService<TEntity, TCreateDto, TReadDto, TUpdateDto>
        where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        // Variáveis de paginação para consulta
        protected int skip = 0;
        protected int take = 50;

        protected ServiceBase(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Cria uma nova entidade a partir do DTO de criação e retorna um DTO de leitura com os dados da entidade criada.
        /// </summary>
        /// <param name="dto">DTO que contém os dados necessários para criar a nova entidade.</param>
        /// <returns>DTO de leitura com os dados da entidade criada.</returns>
        /// <response code="201">Retorna o DTO de leitura da entidade criada com sucesso.</response>
        /// <response code="400">Se ocorrer um erro durante a criação da entidade.</response>

        public virtual TReadDto Post(TCreateDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            _repository.Post(entity);

            var result = _mapper.Map<TReadDto>(entity);
            return result;
        }

        /// <summary>
        /// Recupera uma entidade pelo seu ID e a retorna como um DTO de leitura.
        /// </summary>
        /// <param name="id">ID da entidade que será recuperada.</param>
        /// <returns>DTO de leitura da entidade encontrada.</returns>
        /// <response code="200">Retorna o DTO de leitura da entidade encontrada.</response>
        /// <response code="404">Se a entidade não for encontrada com o ID informado.</response>

        public virtual TReadDto Get(int id)
        {
            var entity = _repository.Get(id);

            if (entity != null)
                throw new KeyNotFoundException($"Entity with ID {id} not found.");

            var result = _mapper.Map<TReadDto>(entity);
            return result;
        }

        /// <summary>
        /// Recupera uma lista de todas as entidades, com suporte a paginação.
        /// </summary>
        /// <returns>Lista de DTOs de leitura de todas as entidades.</returns>
        /// <response code="200">Retorna a lista de DTOs de leitura das entidades.</response>

        public virtual IEnumerable<TReadDto> GetAll()
        {
            var entities = _repository.GetAll(skip, take).ToList();
            var result = _mapper.Map<IEnumerable<TReadDto>>(entities);

            return result;
        }

        /// <summary>
        /// Atualiza uma entidade existente a partir de um DTO de atualização e retorna o DTO de leitura com os dados atualizados.
        /// </summary>
        /// <param name="id">ID da entidade que será atualizada.</param>
        /// <param name="dto">DTO que contém os dados de atualização da entidade.</param>
        /// <returns>DTO de leitura com os dados da entidade atualizada.</returns>
        /// <response code="200">Retorna o DTO de leitura da entidade atualizada com sucesso.</response>
        /// <response code="404">Se a entidade não for encontrada com o ID informado.</response>

        public virtual TReadDto Put(int id, TUpdateDto dto)
        {
            var entity = _repository.Get(id);

            if (entity == null)
                throw new KeyNotFoundException($"Entity with ID {id} not found.");

            _mapper.Map(dto, entity);
            _repository.Put(entity);

            var result = _mapper.Map<TReadDto>(entity);
            return result;
        }

        /// <summary>
        /// Deleta uma entidade pelo seu ID.
        /// </summary>
        /// <param name="id">ID da entidade a ser deletada.</param>
        /// <response code="204">Indica que a operação de exclusão foi realizada com sucesso.</response>
        /// <response code="404">Se a entidade não for encontrada com o ID informado.</response>

        public virtual void Delete(int id)
        {
            var entity = _repository.Get(id);

            if (entity == null)
                throw new KeyNotFoundException($"Entity with ID {id} not found.");

            _repository.Delete(entity);
        }
    }
}