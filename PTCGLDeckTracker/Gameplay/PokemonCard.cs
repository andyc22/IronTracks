using System.Collections.Generic;

namespace PTCGLDeckTracker.Gameplay
{
    public class PokemonCard
    {
        public string Name { get; }
        public List<Attack> Attacks { get; }
        public int AttachedEnergy { get; set; }

        public PokemonCard(string name, params Attack[] attacks)
        {
            Name = name;
            Attacks = new List<Attack>(attacks);
            AttachedEnergy = 0;
        }
    }
}
