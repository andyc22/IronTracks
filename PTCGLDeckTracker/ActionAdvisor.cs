using System.Collections.Generic;
using System.Linq;
using PTCGLDeckTracker.CardCollection;

namespace PTCGLDeckTracker
{
    internal static class ActionAdvisor
    {
        public static IList<string> GetSuggestions(Player player)
        {
            var suggestions = new List<string>();
            var candidates = new List<Player.PokemonSlot>();
            if (player.ActivePokemon != null)
                candidates.Add(player.ActivePokemon);
            candidates.AddRange(player.Bench);

            Player.PokemonSlot? best = null;
            int bestDamage = -1;

            foreach (var slot in candidates)
            {
                if (slot.Pokemon.energyRequirements == null)
                    continue;
                bool meets = true;
                foreach (var req in slot.Pokemon.energyRequirements)
                {
                    int attached = slot.AttachedEnergies.Count(e => e.englishName == req.Key);
                    if (attached < req.Value)
                    {
                        meets = false;
                        break;
                    }
                }
                if (meets && slot.Pokemon.attackDamage > bestDamage)
                {
                    bestDamage = slot.Pokemon.attackDamage;
                    best = slot;
                }
            }

            if (best == null)
                return suggestions;

            if (player.ActivePokemon != best)
            {
                suggestions.Add($"Switch to {best.Pokemon.englishName}");
            }
            suggestions.Add($"Attack with {best.Pokemon.englishName} for {best.Pokemon.attackDamage} damage");
            return suggestions;
        }
    }
}
