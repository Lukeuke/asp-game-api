namespace Application.DTO;

public class FinishResponseDto
{
    public bool Won { get; set; }
    public int Bonus { get; set; }
    public string? WrongLetters { get; set; }
}