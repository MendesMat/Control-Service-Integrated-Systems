using FluentValidation;
using Mendes.ControlService.ManagementAPI.Models;

namespace Mendes.ControlService.ManagementAPI.Validations;

public class IndividualCustomerValidator : AbstractValidator<IndividualCustomer>
{
    public IndividualCustomerValidator()
    {
        Include(new CustomerBaseValidator());

        RuleFor(c => c.Cpf)
            .Matches(@"^\d{11}$").WithMessage("O CPF deve conter exatamente 11 dígitos numéricos.")
            .When(c => !string.IsNullOrEmpty(c.Cpf));
    }
}
