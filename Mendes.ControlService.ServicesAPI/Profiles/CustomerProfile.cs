using AutoMapper;
using Mendes.ControlService.ManagementAPI.Data.Dtos;
using Mendes.ControlService.ManagementAPI.Models;
namespace Mendes.ControlService.ManagementAPI.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        // Teste sem e veja se tem necessidade se update estiver sobrescrevendo com null
        //AllowNullDestinationValues = false;

        #region Individual Customers
        // Create Individual
        CreateMap<CreateCustomerDto, IndividualCustomer>()
            .ForMember(model => model.Cpf, opt => opt.MapFrom(dto => dto.Cpf));

        // Read Individual
        CreateMap<IndividualCustomer, ReadCustomerDto>()
            .ForMember(model => model.Cpf, opt => opt.MapFrom(dto => dto.Cpf))
            // Ignoring company properties
            .ForMember(model => model.LegalName, opt => opt.Ignore())
            .ForMember(model => model.Cnpj, opt => opt.Ignore())
            .ForMember(model => model.MunicipalRegistration, opt => opt.Ignore());

        // Update Individual
        CreateMap<UpdateCustomerDto, IndividualCustomer>()
            .ForMember(model => model.Cpf, opt => opt.MapFrom(dto => dto.Cpf));
        #endregion

        #region Company Customers
        // Create Company
        CreateMap<CreateCustomerDto, CompanyCustomer>()
            .ForMember(model => model.LegalName, opt => opt.MapFrom(dto => dto.LegalName))
            .ForMember(model => model.Cnpj, opt => opt.MapFrom(dto => dto.Cnpj))
            .ForMember(model => model.MunicipalRegistration, opt => opt.MapFrom(dto => dto.MunicipalRegistration));

        // Read Company
        CreateMap<CompanyCustomer, ReadCustomerDto>()
            .ForMember(model => model.LegalName, opt => opt.MapFrom(dto => dto.LegalName))
            .ForMember(model => model.Cnpj, opt => opt.MapFrom(dto => dto.Cnpj))
            .ForMember(model => model.MunicipalRegistration, opt => opt.MapFrom(dto => dto.MunicipalRegistration))
            // Ignoring individual properties
            .ForMember(model => model.Cpf, opt => opt.Ignore());

        // Update Company
        CreateMap<UpdateCustomerDto, CompanyCustomer>()
            .ForMember(model => model.LegalName, opt => opt.MapFrom(dto => dto.LegalName))
            .ForMember(model => model.Cnpj, opt => opt.MapFrom(dto => dto.Cnpj))
            .ForMember(model => model.MunicipalRegistration, opt => opt.MapFrom(dto => dto.MunicipalRegistration));
        #endregion
    }
}