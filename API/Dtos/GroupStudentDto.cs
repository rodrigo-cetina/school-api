namespace API.Dtos
{
  public class GroupStudentDto
  {
    public int Id { get; set; }
    public int GroupId { get; set; }
    public int StudentId { get; set; }
    public GroupDto Group { get; set; }
    public StudentDto Student { get; set; }
  }
}