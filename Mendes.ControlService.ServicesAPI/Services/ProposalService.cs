using AutoMapper;
using Mendes.ControlService.ManagementAPI.Abstracts;
using Mendes.ControlService.ManagementAPI.Data.Dtos.Proposal;
using Mendes.ControlService.ManagementAPI.Interfaces;
using Mendes.ControlService.ManagementAPI.Models;

namespace Mendes.ControlService.ManagementAPI.Services;

public class ProposalService<TProposal, CreateDto, ReadDto, UpdateDto>
    : ServiceBase<TProposal, CreateDto, ReadDto, UpdateDto>
    where TProposal : Proposal
    where UpdateDto : UpdateProposalDto
{
    public ProposalService(IRepository<TProposal> repository, IMapper mapper) 
        : base(repository, mapper)
    {
    }

    public override ReadDto Put(int id, UpdateDto dto)
    {
        var entity = _repository.Get(id);

        if (entity != null)
            dto.CustomerId = entity.CustomerId;

        return base.Put(id, dto);
    }
}
