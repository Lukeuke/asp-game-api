namespace Application.Services;

public interface IWordProviderService
{ 
    Task<string> GetWordFromApi();
    string GetWord();
}