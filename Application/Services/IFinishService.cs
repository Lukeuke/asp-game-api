using Application.DTO;

namespace Application.Services;

public interface IFinishService
{
    void AddToDb(FinishRequestDto finishRequestDto);
}