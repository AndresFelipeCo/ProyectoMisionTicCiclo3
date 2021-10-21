using System.Collections.Generic;
using Domain.Entities;

namespace Persistence
{
  public interface IRepositoryRecommendation
  {
    IEnumerable<Recommendation> All();
    Recommendation Add(Recommendation recommendation);
    Recommendation Update(Recommendation recommendation);
    void Delete(int idRecommendation);
    Recommendation Get(int idRecommendation);
  }
}