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

        var word = GameService.GetInstance().Word;
        
        var wrongLetters = GameService.GetInstance().CheckForWord(finishRequestDto.Word);
        
        if (finishRequestDto.Word.Equals(word))
        {
            _finishService.AddToDb(finishRequestDto);
            
            GameService.GetInstance().GetNewWord();
            
            return new FinishResponseDto()
            {
                Won = true,
                Bonus = 100,
                WrongLetters = null
            };
        }
        
        return new FinishResponseDto() { WrongLetters = wrongLetters };
    }
}