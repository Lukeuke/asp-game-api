using Application.DTO;
using Newtonsoft.Json;

namespace Application.Services;

public class WordProviderService : IWordProviderService
{
    private string _WordToGuess;

    private const string Url = "http://localhost:3000/word";

    private List<string> _words = new List<string>()
    {
        "burak", "wawel"
    };

    /*public async Task GetWordFromApi()
    {
        using var httpClient = new HttpClient();
        var result = await httpClient.GetAsync(Url);
        var json = await result.Content.ReadAsStringAsync();
        
        var wordDto = JsonConvert.DeserializeObject<WordDto>(json);

        _WordToGuess = wordDto.Word;

        Console.WriteLine(_WordToGuess);
    }*/

    public string GetWord()
    {
        var random = new Random();

        var index = random.Next(0, _words.Count);

        _WordToGuess = _words[index];
        return _WordToGuess;
    }
}