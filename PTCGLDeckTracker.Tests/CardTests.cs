using PTCGLDeckTracker.CardCollection;
using System.Collections.Generic;
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

    [Fact]
    public void Card_AttackFields_CanBeAssigned()
    {
        var card = new Card("abc")
        {
            AttackDamage = new List<string> { "20" },
            EnergyRequirement = new List<string> { "L" }
        };

        Assert.Equal("20", card.AttackDamage[0]);
        Assert.Equal("L", card.EnergyRequirement[0]);
    }

    [Fact]
    public void Card_CanStoreAbilityAndWeakness()
    {
        var card = new Card("def")
        {
            Ability = "Power Boost",
            Weakness = "Water",
            Resistance = "Grass"
        };

        card.ToolCards.Add("Muscle Band");

        Assert.Equal("Power Boost", card.Ability);
        Assert.Equal("Water", card.Weakness);
        Assert.Equal("Grass", card.Resistance);
        Assert.Contains("Muscle Band", card.ToolCards);
    }
}

