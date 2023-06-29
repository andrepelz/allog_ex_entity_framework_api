using AutoMapper;
using Univali.Api.Entities;
using Univali.Api.Features.Customers.Commands.CreateCustomer;
using Univali.Api.Features.Customers.Commands.CreateCustomerWithAddresses;
using Univali.Api.Features.Customers.Queries.GetCustomerByCpf;
using Univali.Api.Features.Customers.Queries.GetCustomerDetail;
using Univali.Api.Features.Customers.Queries.GetCustomerWithAddresses;
using Univali.Api.Models;

namespace Univali.Api.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile ()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<Customer, CustomerWithAddressesDto>();
        CreateMap<Customer, CustomerForPatchDto>();

        CreateMap<CustomerForUpdateDto, Customer>();
        CreateMap<CustomerForPatchDto, Customer>();

        CreateMap<CustomerForCreationDto, Customer>();
        CreateMap<CustomerWithAddressesForCreationDto, Customer>();
        CreateMap<CustomerDto, Customer>();


        // CQRS
        CreateMap<Customer, GetCustomerDetailDto>();
        CreateMap<Customer, GetCustomerWithAddressesDto>();
        CreateMap<Customer, GetCustomerByCpfDto>();
        CreateMap<Customer, CreateCustomerDto>();
        CreateMap<Customer, CreateCustomerWithAddressesDto>();
    }
}