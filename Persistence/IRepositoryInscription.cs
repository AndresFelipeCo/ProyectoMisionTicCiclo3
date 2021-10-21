using System.Collections.Generic;
using Domain.Entities;

namespace Persistence
{
  public interface IRepositoryInscription
  {
    IEnumerable<Inscription> All();
    IEnumerable<Inscription> AllStudent(int idStudent);
    Inscription Add(Inscription inscription);
    Inscription Update(Inscription inscription);
    void Delete(int idInscription);
    Inscription Get(int idInscription);
  }
}