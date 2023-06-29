using System.ComponentModel.DataAnnotations;
using Univali.Api.ValidationAttributes;

namespace Univali.Api.Models;

public class PublisherForManipulationDto {
    [Required(ErrorMessage = "You should fill out a FirstName")]
    [MaxLength(30, ErrorMessage = "The FirstName shouldn't have more than 30 characters")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "You should fill out a LastName")]
    [MaxLength(30, ErrorMessage = "The LastName shouldn't have more than 30 characters")]
   	public string LastName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "You should fill out a Cpf")]
    [MaxLength(11, ErrorMessage = "The Cpf shouldn't have more than 11 characters")]
    [CpfMustBeValid(ErrorMessage = "The provided {0} must be valid")]
	public string Cpf { get; set; } = string.Empty;
}