namespace Univali.Api.Models;

public class CustomerWithAddressesForCreationDto : CustomerForManipulationDto {
    public List<AddressDto> Addresses { get; set; } = new List<AddressDto>();
}
