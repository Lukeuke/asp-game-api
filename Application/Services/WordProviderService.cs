using Newtonsoft.Json;

namespace Application.Services;

public class WordProviderService : IWordProviderService
{
    private const string Url = "https://random-word-api.herokuapp.com/word?length=5";
    
    public async Task<string> GetWordFromApi()
    {
        using var httpClient = new HttpClient();
        var result = await httpClient.GetAsync(Url);
        var json = await result.Content.ReadAsStringAsync();
        
        var word = JsonConvert.DeserializeObject<List<string>>(json);

        Console.WriteLine(word[0]);
        
        return word[0];
    }
}