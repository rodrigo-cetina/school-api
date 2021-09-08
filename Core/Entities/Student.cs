using Core.Enums;

namespace Core.Entities
{
  public class Student: BaseEntity
  {
    public string Code { get; set; }
    public Person Person { get; set; }
  }
}