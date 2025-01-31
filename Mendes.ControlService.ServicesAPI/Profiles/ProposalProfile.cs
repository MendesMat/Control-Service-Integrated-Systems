using AutoMapper;
using Mendes.ControlService.ManagementAPI.Data.Dtos.Proposal;
using Mendes.ControlService.ManagementAPI.Models;

namespace Mendes.ControlService.ManagementAPI.Profiles;

/// <summary>
/// Perfil de mapeamento para as propostas.
/// Utiliza AutoMapper para definir como as entidades são convertidas entre DTOs e modelos de domínio.
/// </summary>

public class ProposalProfile : Profile
{
    public ProposalProfile()
    {
        CreateMap<Proposal, ReadProposalDto>()
            .ForMember(dto => dto.CustomerName,
            opt => opt.MapFrom(model => model.Customer.Name))

            .ForMember(dto => dto.PayingEntityName,
            opt => opt.MapFrom(model => model.PayingEntity != null 
            ? model.PayingEntity.Name : string.Empty));

        CreateMap<CreateProposalDto, Proposal>();
        CreateMap<Proposal, ReadProposalDto>();
        CreateMap<UpdateProposalDto, Proposal>();
    }
}
