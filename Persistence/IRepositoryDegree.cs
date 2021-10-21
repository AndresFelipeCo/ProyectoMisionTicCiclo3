using System.Collections.Generic;
using Domain.Entities;

namespace Persistence
{
  public interface IRepositoryDegree
  {
    IEnumerable<Degree> All();
    Degree Add(Degree degree);
    Degree Update(Degree degree);
    void Delete(int idDegree);
    Degree Get(int idDegree);
  }
}