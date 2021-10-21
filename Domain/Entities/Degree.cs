using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
namespace Domain.Entities
{
  public class Degree
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<User> Students { get; set; }
  }
}