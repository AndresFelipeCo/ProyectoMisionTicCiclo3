using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Persistence.AppRepositories;
namespace Persistence
{

  public class RepositoryDegree : IRepositoryDegree
  {
    private readonly AppDbContext _appContext = new AppDbContext();
    /// <param name="appContext"><param>
    // public RepositoryDegree(AppDbContext appContext)
    // {
    //   _appContext = appContext;
    // }
    public Degree Add(Degree degree)
    {
      var newDegree = _appContext.Degrees.Add(degree);
      _appContext.SaveChanges();
      return newDegree.Entity;
    }

    public void Delete(int idDegree)
    {
      var deleteDegree = _appContext.Degrees.FirstOrDefault(p => p.Id == idDegree);
      if (deleteDegree == null)
      {
        return;
      }
      _appContext.Degrees.Remove(deleteDegree);
      _appContext.SaveChanges();
    }

    public IEnumerable<Degree> All()
    {
      return _appContext.Degrees;
    }

    public Degree Get(int idDegree)
    {
      return _appContext.Degrees.FirstOrDefault(p => p.Id == idDegree);
    }

    public Degree Update(Degree degree)
    {
      var updateDegree = _appContext.Degrees.FirstOrDefault(p => p.Id == degree.Id);
      if (updateDegree != null)
      {
        updateDegree.Name = degree.Name;
        _appContext.SaveChanges();
        return updateDegree;
      }
      return updateDegree;
    }
  }
}