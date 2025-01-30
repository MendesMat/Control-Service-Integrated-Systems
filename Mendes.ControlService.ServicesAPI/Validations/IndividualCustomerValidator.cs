using FluentValidation;
using Mendes.ControlService.ManagementAPI.Models.Customers;

namespace Mendes.ControlService.ManagementAPI.Validations;

public class IndividualCustomerValidator : AbstractValidator<IndividualCustomer>
{
    public IndividualCustomerValidator()
    {
        Include(new CustomerBaseValidator());

        RuleFor(c => c.Cpf)
            .NotEmpty().WithMessage("O CPF é obrigatório.")
            .Matches(@"^\d{11}$").WithMessage("O CPF deve conter exatamente 11 dígitos numéricos.");
    }
}
