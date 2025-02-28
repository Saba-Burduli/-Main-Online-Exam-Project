namespace OnlineExam.SERVICE.DTOs.ResultModels;

public class ResultUpdateModel
{
    public int ResultId { get; set; }
    
    public decimal Score { get; set; }
    
    public DateTime DateTaken { get; set; }
}