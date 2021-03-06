namespace API.Dtos
{
  public class GroupDto
  {
    public int Id { get; set; }
    public string Code { get; set; }
    public CareerDto Career { get; set; }
    public SubjectDto Subject { get; set; }
    public TeacherDto Teacher { get; set; }
  }
}