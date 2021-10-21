
using System.ComponentModel.DataAnnotations;
namespace Domain.Entities
{
    public class Progress
    {
    public int Id { get; set; }
    public int? InscriptionId { get; set; } 
    public Inscription Inscription { get; set; } 
    public int? ActivityId { get; set; }
    public Activity Activity { get; set; }
    public State State { get; set; }
    }
}