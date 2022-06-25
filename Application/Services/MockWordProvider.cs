namespace Application.Services;

public class MockWordProvider
{
    private string _word = "test1";

    public string GetWord() => _word;
}