namespace API.Dtos
{
  public class ScoreRecordDto
  {
        public int Id { get; set; }
        public decimal Score { get; set; }
        public StudentDto Student { get; set; }
        public GroupDto Group { get; set; }
  }
}