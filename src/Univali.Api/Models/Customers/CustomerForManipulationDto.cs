using System.ComponentModel.DataAnnotations;
using Univali.Api.ValidationAttributes;

namespace Univali.Api.Models;

public abstract class CustomerForManipulationDto {
    [Required(ErrorMessage = "You should fill out a Name")]
    [MaxLength(50, ErrorMessage = "The name shouldn't have more than 50 characters")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "You should fill out a Cpf")]
    [CpfMustBeValid(ErrorMessage = "The provided {0} must be valid")]
    public string Cpf { get; set; } = string.Empty;
}