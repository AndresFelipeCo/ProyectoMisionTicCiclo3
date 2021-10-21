using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Persistence.AppRepositories;
namespace Persistence
{

  public class RepositoryInscription : IRepositoryInscription
  {
    private readonly AppDbContext _appContext = new AppDbContext();
    public Inscription Add(Inscription inscription)
    {
      var newInscription = _appContext.Inscriptions.Add(inscription);
      _appContext.SaveChanges();
      return newInscription.Entity;
    }

    public void Delete(int idInscription)
    {
      var deleteInscription = _appContext.Inscriptions.FirstOrDefault(p => p.Id == idInscription);
      if (deleteInscription == null)
      {
        return;
      }
      _appContext.Inscriptions.Remove(deleteInscription);
      _appContext.SaveChanges();
    }

    public IEnumerable<Inscription> All()
    {
      return _appContext.Inscriptions;
    }

    public Inscription Get(int idInscription)
    {
      return _appContext.Inscriptions.FirstOrDefault(p => p.Id == idInscription);
    }

    public Inscription Update(Inscription inscription)
    {
      var updateInscription = _appContext.Inscriptions.FirstOrDefault(p => p.Id == inscription.Id);
      if (updateInscription != null)
      {
        updateInscription.Student = inscription.Student;
        updateInscription.Subject = inscription.Subject;
        _appContext.SaveChanges();
        return updateInscription;
      }
      return updateInscription;
    }
    public IEnumerable<Inscription> AllStudent(int idStudent)
    {
      return _appContext.Inscriptions.Where(i=>i.StudentId==idStudent).ToList();
    }
  }
}