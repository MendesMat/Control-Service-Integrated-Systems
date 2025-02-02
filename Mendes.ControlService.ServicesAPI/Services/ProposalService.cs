using AutoMapper;
using FluentValidation;
using Mendes.ControlService.ManagementAPI.Abstracts;
using Mendes.ControlService.ManagementAPI.Data.Dtos.Proposal;
using Mendes.ControlService.ManagementAPI.Interfaces;
using Mendes.ControlService.ManagementAPI.Models;

namespace Mendes.ControlService.ManagementAPI.Services;

public class ProposalService<TProposal, TCreateDto, TReadDto, TUpdateDto>
    : ServiceBase<TProposal, TCreateDto, TReadDto, TUpdateDto>
    where TProposal : Proposal
    where TUpdateDto : UpdateProposalDto
{
    private readonly IValidator<TProposal> _validator;

    public ProposalService(
        IRepository<TProposal> repository, 
        IMapper mapper,
        IValidator<Proposal> validator) 
        : base(repository, mapper)
    {
        _validator = validator;
    }

    public override TReadDto Post(TCreateDto dto)
    {
        var proposal = _mapper.Map<TProposal>(dto);
        if(proposal != null) ValidateProposal(proposal);

        return base.Post(dto);
    }

    public override TReadDto Put(int id, TUpdateDto dto)
    {
        var proposal = _repository.Get(id);
        if(proposal != null) ValidateProposal(proposal);

        return base.Put(id, dto);
    }

    private void ValidateProposal(TProposal proposal)
    {
        var validationResult = _validator.Validate(proposal);

        if (!validationResult.IsValid)
        {
            var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new ValidationException($"Erro de validação: {errors}");
        }
    }
}