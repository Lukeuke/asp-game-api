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