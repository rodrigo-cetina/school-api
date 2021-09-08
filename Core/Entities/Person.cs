using Core.Enums;
using System.Text.Json.Serialization;

namespace Core.Entities
{
  public class Person: BaseEntity
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender? Gender { get; set; }
    public string PictureUrl { get; set; }
    public Role Role { get; set; }
    public string Email { get; set; }
    [JsonIgnore]
    public string PasswordHash { get; set; }
    public Administrator Administrator { get; set; }
    public Student Student { get; set; }
    public Teacher Teacher { get; set; }
  }
}