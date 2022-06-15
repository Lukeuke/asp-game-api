using Application.Controllers;
using Application.DTO;
using NUnit.Framework;

namespace Application.Test;

public class EndpointTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void InitializeController_Test()
    {
        var initializeController = new InitializeController();
        var initializeDto = new InitializeRequestDto()
        {
            Id = 2
        };

        var expectedInitializeResponseDto = new InitializeResponseDto()
        {
            Id = 2,
            CanPlay = true
        };

        var result = initializeController.Post(initializeDto);
        
        Assert.AreEqual(expectedInitializeResponseDto.Id, result.Id);
        Assert.AreEqual(expectedInitializeResponseDto.CanPlay, result.CanPlay);
    }

    [Test]
    public void FinishController_Test()
    {
        var finishController = new FinishController();
        var finishRequestDto = new FinishRequestDto()
        {
            Id = 1,
            Word = "sample"
        };

        var expectedFinishResponseDto = new FinishResponseDto()
        {
            Won = false, // TODO: change this when will be some business logic 
            Bonus = 0
        };

        var result = finishController.Post(finishRequestDto);
        
        Assert.AreEqual(expectedFinishResponseDto.Bonus, result.Bonus);
        Assert.AreEqual(expectedFinishResponseDto.Won, result.Won);
    }
}