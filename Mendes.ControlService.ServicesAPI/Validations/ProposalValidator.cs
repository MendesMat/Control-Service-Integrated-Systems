using FluentValidation;
using Mendes.ControlService.ManagementAPI.Models;

namespace Mendes.ControlService.ManagementAPI.Validations;

public class ProposalValidator : AbstractValidator<Proposal>
{
    public ProposalValidator()
    {
        RuleFor(p => p.PayingEntityId)
            .Must((p, payingEntityId) => payingEntityId != p.CustomerId)
            .WithMessage("A praça pagadora não pode ser o próprio cliente.");
    }
}
