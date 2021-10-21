using System.Collections.Generic;
using Domain.Entities;

namespace Persistence
{
  public interface IRepositoryActivity
  {
    IEnumerable<Activity> All();
    Activity Add(Activity activity);
    Activity Update(Activity activity);
    void Delete(int idActivity);
    Activity Get(int idActivity);
  }
}