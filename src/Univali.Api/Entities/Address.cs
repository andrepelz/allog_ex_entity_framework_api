using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Univali.Api.Entities;

public class Address {
   public int AddressId { get; set; }
   public string Street { get; set; } = string.Empty;
   public string City { get; set; } = string.Empty;
   public Customer? Customer { get; set; }
   public int CustomerId { get; set; }
}
