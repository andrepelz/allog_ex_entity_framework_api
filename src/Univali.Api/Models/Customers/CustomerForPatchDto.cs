namespace Univali.Api.Models;

public class CustomerForPatchDto : CustomerForManipulationDto {
    public List<AddressDto> Addresses { get; set; } = new List<AddressDto>();
}