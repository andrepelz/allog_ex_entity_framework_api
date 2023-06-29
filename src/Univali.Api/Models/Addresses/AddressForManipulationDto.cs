using System.ComponentModel.DataAnnotations;

namespace Univali.Api.Models;

public abstract class AddressForManipulationDto {
    [Required(ErrorMessage = "You should fill out a Street")]
    [MaxLength(50, ErrorMessage = "The Street shouldn't have more than 50 characters")]
    public string Street { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "You should fill out a City")]
    [MaxLength(50, ErrorMessage = "The City shouldn't have more than 50 characters")]
    public string City { get; set; } = string.Empty;
}
