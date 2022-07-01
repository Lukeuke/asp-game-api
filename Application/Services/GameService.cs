namespace Application.Services;

/// <summary>
/// This class is made as Singleton to Serve public access to logic everywhere in the code
/// </summary>
public sealed class GameService
{
    private static GameService? _instance;

    public string Word { get; private set; }

    private readonly WordProviderService _wordProviderService = new ();
    
    public static GameService GetInstance()
    {
        return _instance ??= new GameService();
    }

    
    public string CheckForWord(string guessedWord)
    {
        return guessedWord.Where((t, i) => t != Word[i]).Aggregate("", (current, t) => current + t);
    }
    
    /// <summary>
    /// Mocked method of CheckForWord to test it,
    /// not quite sure if its good way to do this
    /// </summary>
    /// <param name="guessedWord"></param>
    /// <param name="word"></param>
    /// <returns>Wrong letters in guessedWord, compared to word</returns>
    public string CheckForWord_Mock(string guessedWord, string word)
    {
        Word = word;
        return CheckForWord(guessedWord);
    }
    
    public void SomeBusinessMethod()
    {
        Console.WriteLine("Method invoked");
    }

    public void GetNewWord()
    {
        var word = _wordProviderService.GetWordFromApi();
        Word = word.Result;
    }
}