using FluentValidation;
using Mendes.ControlService.ManagementAPI.Models;

namespace Mendes.ControlService.ManagementAPI.Validations;

public class CompanyCustomerValidator : AbstractValidator<CompanyCustomer>
{
    public CompanyCustomerValidator()
    {
        Include(new CustomerBaseValidator());

        RuleFor(c => c.Cnpj)
            .Matches(@"^\d{14}$").WithMessage("O CNPJ deve conter exatamente 14 dígitos numéricos.")
            .When(c => !string.IsNullOrEmpty(c.Cnpj));
    }
}
