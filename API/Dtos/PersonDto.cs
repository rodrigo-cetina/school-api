using Core.Enums;

namespace API.Dtos
{
  public class PersonDto
  {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender? Gender { get; set; }
        public string PictureUrl { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
  }
}