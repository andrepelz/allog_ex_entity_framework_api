using System.ComponentModel.DataAnnotations;

namespace Univali.Api.Models;

public class PublisherForUpdateDto : PublisherForManipulationDto {
    [Required(ErrorMessage = "You should fill out an Id")]
    public int PublisherId { get; set; }
}