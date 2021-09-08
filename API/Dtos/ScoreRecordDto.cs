namespace API.Dtos
{
  public class ScoreRecordDto
  {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int GroupId { get; set; }
        public decimal Score { get; set; }
        public StudentDto Student { get; set; }
        public GroupDto Group { get; set; }
  }
}