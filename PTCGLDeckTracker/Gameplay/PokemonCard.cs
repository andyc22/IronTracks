using System.Collections.Generic;

namespace PTCGLDeckTracker.Gameplay
{
    public class PokemonCard
    {
        public string Name { get; }
        public List<Attack> Attacks { get; }
        public int AttachedEnergy { get; set; }

        /// <summary>
        /// Optional ability text.  The tracker does not parse the
        /// rules text but keeps it so consumers can reason about it.
        /// </summary>
        public string? Ability { get; set; }

        /// <summary>
        /// Weakness type string such as "Lightning" or "Fire".
        /// </summary>
        public string Weakness { get; set; } = string.Empty;

        /// <summary>
        /// Resistance type string such as "Grass".
        /// </summary>
        public string Resistance { get; set; } = string.Empty;

        /// <summary>
        /// Names of any Pokémon Tool cards currently attached.
        /// </summary>
        public List<string> ToolCards { get; } = new();

        public PokemonCard(string name, params Attack[] attacks)
        {
            Name = name;
            Attacks = new List<Attack>(attacks);
            AttachedEnergy = 0;
        }
    }
}
