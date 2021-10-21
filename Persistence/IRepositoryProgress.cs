using System.Collections.Generic;
using Domain.Entities;

namespace Persistence
{
  public interface IRepositoryProgress
  {
    IEnumerable<Progress> All();
    Progress Add(Progress progress);
    Progress Update(Progress progress);
    void Delete(int idProgress);
    Progress Get(int idProgress);
  }
}