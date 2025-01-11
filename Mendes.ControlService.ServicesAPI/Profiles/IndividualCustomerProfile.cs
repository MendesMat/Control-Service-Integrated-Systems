using AutoMapper;
using Mendes.ControlService.ManagementAPI.Data.Dtos.IndividualCustomer;
using Mendes.ControlService.ManagementAPI.Models;

namespace Mendes.ControlService.ManagementAPI.Profiles;

public class IndividualCustomerProfile : Profile
{
    public IndividualCustomerProfile()
    {
        CreateMap<CreateIndividualCustomerDto, IndividualCustomer>();
        CreateMap<IndividualCustomer, ReadIndividualCustomerDto>();
        CreateMap<UpdateIndividualCustomerDto, IndividualCustomer>();
        CreateMap<DeleteIndividualCustomerDto, IndividualCustomer>();
    }
}