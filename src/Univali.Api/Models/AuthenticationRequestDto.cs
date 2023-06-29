using System.ComponentModel.DataAnnotations;

namespace Univali.Api.Models;

public class AuthenticationRequestDto {
    [Required(ErrorMessage = "You should fill out a Username")]
    [MaxLength(50, ErrorMessage = "The name shouldn't have more than 50 characters")]
    public string? Username{ get; set; }
    
    [Required(ErrorMessage = "You should fill out a Password")]
    public string? Password { get; set; }
}