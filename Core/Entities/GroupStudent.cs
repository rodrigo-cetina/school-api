using Core.Enums;

namespace Core.Entities
{
  public class GroupStudent: BaseEntity
  {
    public int GroupId { get; set; }
    public int StudentId { get; set; }
    public Group Group { get; set; }
    public Student Student { get; set; }
  }
}