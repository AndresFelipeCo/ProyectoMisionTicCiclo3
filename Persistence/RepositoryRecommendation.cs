using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Persistence.AppRepositories;
namespace Persistence
{

  public class RepositoryRecommendation : IRepositoryRecommendation
  {
    private readonly AppDbContext _appContext;
    /// <param name="appContext"><param>
    public RepositoryRecommendation(AppDbContext appContext)
    {
      _appContext = appContext;
    }
    public Recommendation Add(Recommendation recommendation)
    {
      var newRecommendation = _appContext.Recommendations.Add(recommendation);
      _appContext.SaveChanges();
      return newRecommendation.Entity;
    }

    public void Delete(int idRecommendation)
    {
      var deleteRecommendation = _appContext.Recommendations.FirstOrDefault(p => p.Id == idRecommendation);
      if (deleteRecommendation == null)
      {
        return;
      }
      _appContext.Recommendations.Remove(deleteRecommendation);
      _appContext.SaveChanges();
    }

    public IEnumerable<Recommendation> All()
    {
      return _appContext.Recommendations;
    }

    public Recommendation Get(int idRecommendation)
    {
      return _appContext.Recommendations.FirstOrDefault(p => p.Id == idRecommendation);
    }

    public Recommendation Update(Recommendation recommendation)
    {
      var updateRecommendation = _appContext.Recommendations.FirstOrDefault(p => p.Id == recommendation.Id);
      if (updateRecommendation != null)
      {
        updateRecommendation.Recommender = recommendation.Recommender;
        updateRecommendation.Progress = recommendation.Progress;
        updateRecommendation.Text = recommendation.Text;
        _appContext.SaveChanges();
        return updateRecommendation;
      }
      return updateRecommendation;
    }
  }
}