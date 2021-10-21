using System.Collections.Generic;
namespace Domain.Entities
{
    public class Inscription
    {
    public int Id { get; set; }
    public int StudentId {get;set;}
    public User Student {get;set;}
    public int SubjectId {get;set;}
    public Subject Subject {get;set;}
    public IEnumerable<Progress> Progreses { get; set; }
    }
}