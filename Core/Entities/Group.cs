using Core.Enums;

namespace Core.Entities
{
  public class Group: BaseEntity
  {
    public int CareerId { get; set; }
    public int SubjectId { get; set; }
    public string Code { get; set; }
    public int TeacherId { get; set; }
    public Career Career { get; set; }
    public Subject Subject { get; set; }
    public Teacher Teacher { get; set; }
  }
}