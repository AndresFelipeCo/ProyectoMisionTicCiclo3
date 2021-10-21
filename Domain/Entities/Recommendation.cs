namespace Domain.Entities
{
  public class Recommendation
  {
    public int Id { get; set; }
    public int RecommenderId { get; set; }
    public User Recommender { get; set; }
    public int ProgressId { get; set; }
    public Progress Progress { get; set; }
    public string Text { get; set; }
  }
}