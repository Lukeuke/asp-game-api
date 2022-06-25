﻿using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("/finish")]
public class FinishController : ControllerBase
{
    private readonly IWordProviderService _wordProviderService;

    public FinishController(IWordProviderService wordProviderService)
    {
        _wordProviderService = wordProviderService;
    }
    
    [HttpPost]
    [Authorize]
    public FinishResponseDto Post(FinishRequestDto finishRequestDto)
    {
        Console.WriteLine($"{finishRequestDto.Id}, {finishRequestDto.Word}");

        _wordProviderService.GetWord();
        
        if (finishRequestDto.Word.Equals(_wordProviderService.GetWord()))
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