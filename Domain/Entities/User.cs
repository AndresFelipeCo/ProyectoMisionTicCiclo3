using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Domain.Entities
{
  public class User
  {
    public int Id { get; set; }
    public Role Role { get; set; }
    public string DNI { get; set; }
    public string Password {get; set;}
    public string FirtsName { get; set; }
    [Required, StringLength(50)]
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public Gender Gender { get; set; }
    public int? DegreId { get; set; }
    public Degree Degre {get;set;}
    public IEnumerable<Inscription> Inscriptions{get;set;}
    public int? GuardianId { get; set; }
    public User Guardian {get; set;}
    public IEnumerable<Subject> SubjectsTe { get; set; }
    public IEnumerable<Subject> SubjectsTu { get; set; }
  }
}