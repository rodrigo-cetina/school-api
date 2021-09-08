using Core.Enums;

namespace Core.Entities
{
  public class ScoreRecord: BaseEntity
  {
    public int StudentId { get; set; }
    public int GroupId { get; set; }
    public decimal Score { get; set; }
    public Student Student { get; set; }
    public Group Group { get; set; }
  }
}