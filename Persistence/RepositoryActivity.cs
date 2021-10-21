using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Persistence.AppRepositories;
namespace Persistence
{

  public class RepositoryActivity : IRepositoryActivity
  {
    private readonly AppDbContext _appContext;
    /// <param name="appContext"><param>
    public RepositoryActivity(AppDbContext appContext)
    {
      _appContext = appContext;
    }
    public Activity Add(Activity activity)
    {
      var newActivity = _appContext.Activities.Add(activity);
      _appContext.SaveChanges();
      return newActivity.Entity;
    }

    public void Delete(int idActivity)
    {
      var deleteActivity = _appContext.Activities.FirstOrDefault(p => p.Id == idActivity);
      if (deleteActivity == null)
      {
        return;
      }
      _appContext.Activities.Remove(deleteActivity);
      _appContext.SaveChanges();
    }

    public IEnumerable<Activity> All()
    {
      return _appContext.Activities;
    }

    public Activity Get(int idActivity)
    {
      return _appContext.Activities.FirstOrDefault(p => p.Id == idActivity);
    }

    public Activity Update(Activity activity)
    {
      var updateActivity = _appContext.Activities.FirstOrDefault(p => p.Id == activity.Id);
      if (updateActivity != null)
      {
        updateActivity.Subject = activity.Subject;
        updateActivity.Name = activity.Name;
        updateActivity.Description = activity.Description;
        _appContext.SaveChanges();
        return updateActivity;
      }
      return updateActivity;
    }
  }
}