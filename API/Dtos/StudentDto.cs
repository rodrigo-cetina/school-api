using Core.Enums;

namespace API.Dtos
{
  public class StudentDto
  {
        public string Code { get; set; }
        public PersonDto Person { get; set; }
  }
}