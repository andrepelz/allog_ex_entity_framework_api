using System.ComponentModel.DataAnnotations;

namespace Univali.Api.Models;


public class AddressForUpdateDto : AddressForManipulationDto {
    [Required(ErrorMessage = "You should fill out an Id")]
    public int AddressId { get; set; }
}
