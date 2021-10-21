using System.Collections.Generic;
using Domain.Entities;

namespace Persistence
{
  public interface IRepositorySubject
  {
    IEnumerable<Subject> All();
    Subject Add(Subject subject);
    Subject Update(Subject subject);
    void Delete(int idSubject);
    Subject Get(int idSubject);
  }
}