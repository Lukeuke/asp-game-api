using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("/finish")]
public class FinishController : ControllerBase
{
    private readonly IWordProviderService _wordProviderService;
    private readonly IFinishService _finishService;

    public FinishController(IWordProviderService wordProviderService, IFinishService finishService)
    {
        _wordProviderService = wordProviderService;
        _finishService = finishService;
    }
    
    [HttpPost]
    [Authorize]
    public FinishResponseDto Post(FinishRequestDto finishRequestDto)
    {
        Console.WriteLine($"{finishRequestDto.Id}, {finishRequestDto.Word}");

        _wordProviderService.GetWord();
        
        if (finishRequestDto.Word.Equals(_wordProviderService.GetWord()))
        {
            _finishService.AddToDb(finishRequestDto);
            
            return new FinishResponseDto()
            {
                Won = true,
                Bonus = 100
            };
        }
        
        return new FinishResponseDto();
    }
}