using System.Collections.Generic;
namespace Domain.Entities
{
  public class Subject
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int TeacherId { get; set; }
    public User Teacher { get; set; }
    public int TutorId { get; set; }
    public User Tutor { get; set; }
    public IEnumerable<Inscription> Inscriptions { get; set; }
  }
}