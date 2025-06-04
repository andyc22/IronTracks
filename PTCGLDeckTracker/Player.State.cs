using System.Collections.Generic;
using System.Linq;
using PTCGLDeckTracker.CardCollection;

namespace PTCGLDeckTracker
{
    internal partial class Player
    {
        internal class PokemonSlot
        {
            public Card Pokemon { get; }
            public List<Card> AttachedEnergies { get; } = new List<Card>();

            public PokemonSlot(Card pokemon)
            {
                Pokemon = pokemon;
            }
        }

        public PokemonSlot? ActivePokemon { get; private set; }
        public List<PokemonSlot> Bench { get; } = new List<PokemonSlot>();

        public void SetActivePokemon(Card pokemon)
        {
            ActivePokemon = new PokemonSlot(pokemon);
        }

        public void AddBenchPokemon(Card pokemon)
        {
            if (Bench.Count >= 5)
                return;
            Bench.Add(new PokemonSlot(pokemon));
        }

        public void AttachEnergy(Card pokemon, Card energy)
        {
            var slot = GetSlot(pokemon);
            if (slot == null)
                return;
            slot.AttachedEnergies.Add(energy);
        }

        private PokemonSlot? GetSlot(Card pokemon)
        {
            if (ActivePokemon != null && ActivePokemon.Pokemon == pokemon)
                return ActivePokemon;
            return Bench.FirstOrDefault(s => s.Pokemon == pokemon);
        }
    }
}
