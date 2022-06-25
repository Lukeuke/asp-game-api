﻿using Application.DTO;

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
    
    public bool CanPlay()
    {
        return true; // TODO: Make logic
    }
}