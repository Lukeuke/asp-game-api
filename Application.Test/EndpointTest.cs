using System;
using Application.Controllers;
using Application.DTO;
using Application.Models;
using Application.Services;
using NUnit.Framework;

namespace Application.Test;

public class EndpointTest
{
    private readonly WordProviderService _wordProviderService = new WordProviderService();
    private readonly MockWordProvider _mockWordProvider = new MockWordProvider();
    private readonly PlayerContext _playerContext;

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void InitializeController_Test()
    {
        var id = Guid.NewGuid();
        
        var initializeController = new InitializeController(_playerContext);
        var initializeDto = new InitializeRequestDto()
        {
            Id = id
        };

        var expectedInitializeResponseDto = new InitializeResponseDto()
        {
            Id = id,
            CanPlay = true
        };

        var result = initializeController.Post(initializeDto);
        
        Assert.AreEqual(expectedInitializeResponseDto.Id, result.Id);
        Assert.AreEqual(expectedInitializeResponseDto.CanPlay, result.CanPlay);
    }

    [Test]
    public void FinishController_Test()
    {
        var id = Guid.NewGuid();
        
        var finishController = new MockFinishController(_mockWordProvider);
        var finishRequestDto = new FinishRequestDto()
        {
            Id = id,
            Word = _mockWordProvider.GetWord()
        };

        var expectedFinishResponseDto = new FinishResponseDto()
        {
            Won = true,
            Bonus = 100
        };

        var result = finishController.Post(finishRequestDto);
        
        Assert.AreEqual(expectedFinishResponseDto.Bonus, result.Bonus);
        Assert.AreEqual(expectedFinishResponseDto.Won, result.Won);
    }
}