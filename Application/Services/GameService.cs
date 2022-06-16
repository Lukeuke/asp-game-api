using Application.DTO;

namespace Application.Services;

public sealed class GameService
{
    // TODO: Here will be all the business logic

    private static GameService? _instance;

    public static GameService GetInstance()
    {
        return _instance ??= new GameService();
    }

    public void SomeBusinessMethod()
    {
        Console.WriteLine("Method invoked");
    }

    public int GetIdFromDb(InitializeRequestDto initializeRequestDto)
    {
        var reqId = initializeRequestDto.Id;
        var resId = 2; // TODO: Getting id from Db

        return resId;
    }

    public bool CanPlay()
    {
        return true; // TODO: Make logic
    }
}