using Newtonsoft.Json;

namespace Application.Services;

public class WordProviderService : IWordProviderService
{
    private string _wordToGuess = "";
    
    private const string Url = "https://random-word-api.herokuapp.com/word?length=5";
    
    public async Task<string> GetWordFromApi()
    {
        using var httpClient = new HttpClient();
        var result = await httpClient.GetAsync(Url);
        var json = await result.Content.ReadAsStringAsync();
        
        var word = JsonConvert.DeserializeObject<List<string>>(json);

        _wordToGuess = word[0];
        
        Console.WriteLine(_wordToGuess);

        return _wordToGuess;
    }

    public string GetWord()
    {
        return _wordToGuess;
    }
}