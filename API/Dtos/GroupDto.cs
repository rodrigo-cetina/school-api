namespace API.Dtos
{
  public class GroupDto
  {
    public int Id { get; set; }
    public int CareerId { get; set; }
    public int SubjectId { get; set; }
    public string Code { get; set; }
    public int TeacherId { get; set; }
    public CareerDto Career { get; set; }
    public SubjectDto Subject { get; set; }
    public TeacherDto Teacher { get; set; }
  }
}