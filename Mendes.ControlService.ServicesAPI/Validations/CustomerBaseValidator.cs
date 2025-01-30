using FluentValidation;
using Mendes.ControlService.ManagementAPI.Abstracts;

namespace Mendes.ControlService.ManagementAPI.Validations;

public class CustomerBaseValidator : AbstractValidator<CustomerBase>
{
    public CustomerBaseValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MaximumLength(100).WithMessage("O nome não pode ter mais que 100 caracteres.");

        RuleFor(c => c.Telephone1)
            .Matches(@"^\d{10,11}$").WithMessage("O telefone deve conter 10 ou 11 dígitos.")
            .When(c => !string.IsNullOrEmpty(c.Telephone1));

        RuleFor(c => c.Telephone2)
            .Matches(@"^\d{10,11}$").WithMessage("O telefone deve conter 10 ou 11 dígitos.")
            .When(c => !string.IsNullOrEmpty(c.Telephone2));

        RuleFor(c => c.Email)
            .EmailAddress().WithMessage("Email inválido.")
            .When(c => !string.IsNullOrEmpty(c.Email));

        RuleFor(c => c.Email2)
            .EmailAddress().WithMessage("Email inválido.")
            .When(c => !string.IsNullOrEmpty(c.Email2));

        RuleFor(c => c.Cep)
            .Matches(@"^\d{8}$").WithMessage("O CEP deve conter 8 dígitos.")
            .When(c => !string.IsNullOrEmpty(c.Cep));

        RuleFor(c => c.Address)
            .MinimumLength(5).WithMessage("O endereço deve ter pelo menos 5 caracteres.")
            .When(c => !string.IsNullOrEmpty(c.Address));

        RuleFor(c => c.Number)
            .GreaterThan(0).WithMessage("O número deve ser maior que zero.");
    }
}
