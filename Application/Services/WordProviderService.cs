using Application.DTO.Separate;
using Newtonsoft.Json;

namespace Application.Services;

public class WordProviderService : IWordProviderService
{
    private const string Url = "https://random-word-api.herokuapp.com/word?length=5";
    private const string AltUrl = "https://eng-words-api.herokuapp.com/words?length=5&count=1"; // My Api made in node.js in case first wont work
    
    public async Task<string> GetWordFromApi()
    {
        try
        {
            using var httpClient = new HttpClient();
            var result = await httpClient.GetAsync(Url);
            var json = await result.Content.ReadAsStringAsync();
        
            var word = JsonConvert.DeserializeObject<List<string>>(json);

            return word![0];
        }
        catch
        {
            // I've put its in catch because somehow its slower than this first one
            // ~ 1000ms vs 300-200ms
            using var httpClient = new HttpClient();
            var result = await httpClient.GetAsync(AltUrl);
            var json = await result.Content.ReadAsStringAsync();
        
            var wordsDto = JsonConvert.DeserializeObject<WordsDto>(json);
            
            return wordsDto!.Words[0];
        }
    }
}