using Core.Enums;

namespace Core.Entities
{
  public class Administrator: BaseEntity
  {
    public Person Person { get; set; }
  }
}