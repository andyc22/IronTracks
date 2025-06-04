using System.Collections.Generic;

namespace PTCGLDeckTracker.Gameplay
{
    public class BoardState
    {
        public List<PokemonCard> HandPokemon { get; } = new();
        public List<PokemonCard> BenchPokemon { get; } = new();
        public PokemonCard? ActivePokemon { get; set; }
        public List<string> HandEnergies { get; } = new();
        public List<string> HandTrainers { get; } = new();
    }
}
