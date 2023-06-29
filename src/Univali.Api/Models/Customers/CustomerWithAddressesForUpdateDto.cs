using System.ComponentModel.DataAnnotations;

namespace Univali.Api.Models;

public class CustomerWithAddressesForUpdateDto : CustomerForManipulationDto {
    [Required(ErrorMessage = "You should fill out an Id")]
    public int CustomerId { get; set; }
    public List<AddressDto> Addresses { get; set; } = new List<AddressDto>();
}
