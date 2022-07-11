namespace Application.DTO.Separate;

/// <summary>
/// This model is for getting list of words from heroku API
/// </summary>
public class WordsDto
{
    public List<string> Words { get; set; }
}