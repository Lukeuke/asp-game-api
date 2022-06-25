using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

public class MockFinishController : ControllerBase
{
    private readonly MockWordProvider _mockWordProvider;

    public MockFinishController(MockWordProvider wordProviderService)
    {
        _mockWordProvider = wordProviderService;
    }
    
    [HttpPost]
    public FinishResponseDto Post(FinishRequestDto finishRequestDto)
    {
        Console.WriteLine($"{finishRequestDto.Id}, {finishRequestDto.Word}");

        _mockWordProvider.GetWord();
        
        if (finishRequestDto.Word.Equals(_mockWordProvider.GetWord()))
        {
            return new FinishResponseDto()
            {
                Won = true,
                Bonus = 100
            };
        }
        
        return new FinishResponseDto();
    }
}