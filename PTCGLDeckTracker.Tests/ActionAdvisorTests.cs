using PTCGLDeckTracker;
using PTCGLDeckTracker.CardCollection;
using System.Collections.Generic;

namespace PTCGLDeckTracker.Tests;

public class ActionAdvisorTests
{
    [Fact]
    public void Advisor_AttacksWithActivePokemon()
    {
        var player = new Player();
        var pikachu = new Card("p1")
        {
            englishName = "Pikachu",
            attackDamage = 50,
            energyRequirements = new Dictionary<string, int> { { "Lightning", 1 } }
        };
        player.SetActivePokemon(pikachu);
        player.AttachEnergy(pikachu, new Card("e1") { englishName = "Lightning" });

        var suggestions = ActionAdvisor.GetSuggestions(player);
        Assert.Single(suggestions);
        Assert.Equal("Attack with Pikachu for 50 damage", suggestions[0]);
    }

    [Fact]
    public void Advisor_SwitchesToStrongerBenchPokemon()
    {
        var player = new Player();
        var pidgey = new Card("p2")
        {
            englishName = "Pidgey",
            attackDamage = 20,
            energyRequirements = new Dictionary<string, int> { { "Colorless", 1 } }
        };
        var charizard = new Card("p3")
        {
            englishName = "Charizard",
            attackDamage = 150,
            energyRequirements = new Dictionary<string, int> { { "Fire", 3 } }
        };
        player.SetActivePokemon(pidgey);
        player.AttachEnergy(pidgey, new Card("c1") { englishName = "Colorless" });
        player.AddBenchPokemon(charizard);
        player.AttachEnergy(charizard, new Card("f1") { englishName = "Fire" });
        player.AttachEnergy(charizard, new Card("f2") { englishName = "Fire" });
        player.AttachEnergy(charizard, new Card("f3") { englishName = "Fire" });

        var suggestions = ActionAdvisor.GetSuggestions(player);
        Assert.Equal(2, suggestions.Count);
        Assert.Equal("Switch to Charizard", suggestions[0]);
        Assert.Equal("Attack with Charizard for 150 damage", suggestions[1]);
    }
}
