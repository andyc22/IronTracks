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

        /// <summary>
        /// The opponent's current active Pokémon, if known.
        /// </summary>
        public PokemonCard? OpponentActivePokemon { get; set; }

        /// <summary>
        /// Cards revealed from the opponent's deck, such as via card effects
        /// that show the top cards.  Only public information is stored here.
        /// </summary>
        public List<string> OpponentPublicCards { get; } = new();
    }
}
