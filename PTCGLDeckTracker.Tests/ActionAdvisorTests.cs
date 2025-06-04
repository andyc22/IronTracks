using PTCGLDeckTracker.Gameplay;
using Xunit;

namespace PTCGLDeckTracker.Tests;

public class ActionAdvisorTests
{
    [Fact]
    public void Advisor_SelectsHighestDamageAttack()
    {
        var pikachu = new PokemonCard("Pikachu", new Attack("Thunderbolt", 100, 2));
        var charmander = new PokemonCard("Charmander", new Attack("Flame", 70, 1));
        var state = new BoardState();
        state.HandPokemon.Add(pikachu);
        state.HandPokemon.Add(charmander);
        state.HandEnergies.Add("L");
        state.HandEnergies.Add("L");
        state.HandEnergies.Add("F");

        string suggestion = ActionAdvisor.GetSuggestions(state);

        Assert.Contains("Pikachu", suggestion);
        Assert.Contains("Thunderbolt", suggestion);
        Assert.Contains("100", suggestion);
    }

    [Fact]
    public void Advisor_UsesTrainerToMeetEnergyRequirement()
    {
        var blastoise = new PokemonCard("Blastoise", new Attack("Hydro Pump", 150, 3));
        var pikachu = new PokemonCard("Pikachu", new Attack("Quick Attack", 50, 1));
        var state = new BoardState();
        state.HandPokemon.Add(blastoise);
        state.HandPokemon.Add(pikachu);
        state.HandEnergies.Add("W");
        state.HandEnergies.Add("W");
        state.HandTrainers.Add("EnergySearch");

        string suggestion = ActionAdvisor.GetSuggestions(state);

        Assert.Contains("Blastoise", suggestion);
        Assert.Contains("150", suggestion);
    }
}
