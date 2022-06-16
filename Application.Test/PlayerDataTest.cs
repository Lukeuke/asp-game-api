using System;
using Application.Models;
using Application.PlayerData;
using NUnit.Framework;

namespace Application.Test;

public class PlayerDataTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetAllPlayers_Test()
    {
        var mockPlayerData = new MockPlayerData();
        
        var result = mockPlayerData.GetPlayers();
        
        Assert.IsNotEmpty(result);
    }

    [Test]
    public void CreatePlayer_Test()
    {
        var mockPlayerData = new MockPlayerData();

        var player = new Player
        {
            Id = new Guid(),
            Name = "Test",
            Password = "TestPass"
        };

        var result = mockPlayerData.CreatePlayer(player);
        
        Assert.AreEqual(player, result);
    }

    [Test]
    public void GetOnePlayer_Test()
    {
        var mockPlayerData = new MockPlayerData();
        var player = new Player
        {
            Id = new Guid(),
            Name = "Test",
            Password = "TestPass"
        };
        mockPlayerData.CreatePlayer(player);

        var result = mockPlayerData.GetPlayer(player.Id);

        Assert.AreSame(player, result);
    }

    [Test]
    public void DeletePlayer_Test()
    {
        var mockPlayerData = new MockPlayerData();
        
        var player = new Player
        {
            Id = new Guid(),
            Name = "Test",
            Password = "TestPass"
        };

        try
        {
            mockPlayerData.DeletePlayer(player);
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }

    [Test]
    public void EditPlayer_Test()
    {
        
    }
}