using System.Collections.Generic;
namespace Domain.Entities
{
    public class Activity
    {
    public int Id { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<Progress> Progreses { get; set; }
    }
}