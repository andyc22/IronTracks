using PTCGLDeckTracker.CardCollection;
using Xunit;

namespace PTCGLDeckTracker.Tests;

public class CardTests
{
    [Fact]
    public void GetEnglishNameFromCard3DName_ReturnsExpected()
    {
        string result = Card.GetEnglishNameFromCard3DName("Card3D_Pikachu");
        Assert.Equal("Pikachu", result);
    }
}

