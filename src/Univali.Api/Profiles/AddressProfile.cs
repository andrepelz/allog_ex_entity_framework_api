using AutoMapper;
using Univali.Api.Entities;
using Univali.Api.Features.Addresses.Commands.CreateAddress;
using Univali.Api.Features.Addresses.Queries.GetAddressDetail;
using Univali.Api.Models;

namespace Univali.Api.Profiles;

public class AddressProfile : Profile {
    public AddressProfile() {
        CreateMap<Address, AddressDto>();
        CreateMap<Address, AddressForCreationDto>();
        CreateMap<Address, AddressForPatchDto>();

        CreateMap<AddressForUpdateDto, Address>();
        CreateMap<AddressForPatchDto, Address>();

        CreateMap<AddressDto, Address>();
        CreateMap<AddressForCreationDto, Address>();


        // CQRS
        CreateMap<Address, GetAddressDetailDto>();
        CreateMap<Address, CreateAddressDto>();
    }
}
