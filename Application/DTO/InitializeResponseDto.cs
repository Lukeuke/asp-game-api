namespace Application.DTO;

public class InitializeResponseDto
{
    public int Id { get; set; }
    public int WonCount { get; set; }
    public int TotalMoneyWon { get; set; }
    public bool CanPlay { get; set; }
}