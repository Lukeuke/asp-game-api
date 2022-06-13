using Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("/finish")]
public class FinishController : ControllerBase
{
    [HttpPost]
    public FinishRequestDto Post(FinishRequestDto finishRequestDto)
    {
        return finishRequestDto;
    }
}