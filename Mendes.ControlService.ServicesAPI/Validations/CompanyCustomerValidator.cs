using FluentValidation;
using Mendes.ControlService.ManagementAPI.Models.Customers;

namespace Mendes.ControlService.ManagementAPI.Validations;

public class CompanyCustomerValidator : AbstractValidator<CompanyCustomer>
{
    public CompanyCustomerValidator()
    {
        Include(new CustomerBaseValidator());

        RuleFor(c => c.LegalName)
            .MinimumLength(2).WithMessage("O nome da empresa deve ter pelo menos 2 caracteres.")
            .When(c => !string.IsNullOrEmpty(c.LegalName));

        RuleFor(c => c.Cnpj)
            .NotEmpty().WithMessage("O CNPJ é obrigatório.")
            .Matches(@"^\d{14}$").WithMessage("O CNPJ deve conter exatamente 14 dígitos numéricos.");
    }
}
