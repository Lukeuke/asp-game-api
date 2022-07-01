using Application.Services;
using NUnit.Framework;

namespace Application.Test;

public class GameServiceTest
{
    private string _word;
    
    private readonly WordProviderService _wordProviderService = new ();
    
    [Test]
    public void GetWord_Test()
    {
        var word = _wordProviderService.GetWordFromApi();
        _word = word.Result;
        
        Assert.AreEqual(word.Result, _word);
    }

    [Test]
    public void CheckForWord_Test()
    {
        var output = GameService.GetInstance().CheckForWord_Mock("wrong", "wrung");
        var output1 = GameService.GetInstance().CheckForWord_Mock("wrong", "wrong");
        
        Assert.AreEqual(output, "o");
        Assert.AreEqual(output1, string.Empty);
        
        Assert.AreNotEqual(output, "wrong");
        Assert.AreNotEqual(output, string.Empty);
    }
}