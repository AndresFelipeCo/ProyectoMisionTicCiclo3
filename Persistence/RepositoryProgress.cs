using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Persistence.AppRepositories;
namespace Persistence
{

  public class RepositoryProgress : IRepositoryProgress
  {
    private readonly AppDbContext _appContext;
    /// <param name="appContext"><param>
    public RepositoryProgress(AppDbContext appContext)
    {
      _appContext = appContext;
    }
    public Progress Add(Progress progress)
    {
      var newProgress = _appContext.Progresses.Add(progress);
      _appContext.SaveChanges();
      return newProgress.Entity;
    }

    public void Delete(int idProgress)
    {
      var deleteProgress = _appContext.Progresses.FirstOrDefault(p => p.Id == idProgress);
      if (deleteProgress == null)
      {
        return;
      }
      _appContext.Progresses.Remove(deleteProgress);
      _appContext.SaveChanges();
    }

    public IEnumerable<Progress> All()
    {
      return _appContext.Progresses;
    }

    public Progress Get(int idProgress)
    {
      return _appContext.Progresses.FirstOrDefault(p => p.Id == idProgress);
    }

    public Progress Update(Progress progress)
    {
      var updateProgress = _appContext.Progresses.FirstOrDefault(p => p.Id == progress.Id);
      if (updateProgress != null)
      {
        updateProgress.Inscription = progress.Inscription;
        updateProgress.Activity = progress.Activity;
        updateProgress.State = progress.State;
        _appContext.SaveChanges();
        return updateProgress;
      }
      return updateProgress;
    }
  }
}