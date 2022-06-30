namespace Application.Services;

public sealed class GameService
{
    // TODO: Here will be all the business logic

    private static GameService? _instance;

    public string Word { get; }

    private readonly WordProviderService _wordProviderService = new ();

    public GameService()
    {
       var word = _wordProviderService.GetWordFromApi();
       Word = word.Result;
    }
    
    public static GameService GetInstance()
    {
        return _instance ??= new GameService();
    }

    public void SomeBusinessMethod()
    {
        Console.WriteLine("Method invoked");
    }
}