using System.Collections.Generic;
using System.Linq;

namespace PTCGLDeckTracker.Gameplay
{
    public static class ActionAdvisor
    {
        public static string GetSuggestions(BoardState state)
        {
            int availableEnergy = state.HandEnergies.Count + state.HandTrainers.Count;
            string bestPlay = "No available plays";
            int bestScore = int.MinValue;

            IEnumerable<PokemonCard?> candidates = new[] { state.ActivePokemon }
                .Concat(state.BenchPokemon)
                .Concat(state.HandPokemon);

            foreach (var pokemon in candidates)
            {
                if (pokemon == null) continue;

                foreach (var attack in pokemon.Attacks)
                {
                    int totalEnergy = pokemon.AttachedEnergy + availableEnergy;
                    if (totalEnergy < attack.EnergyCost)
                        continue;

                    int requiredAttachments = attack.EnergyCost - pokemon.AttachedEnergy;
                    if (requiredAttachments < 0) requiredAttachments = 0;

                    int damage = attack.Damage;

                    // Simple tool/ability bonuses
                    damage += pokemon.ToolCards.Count * 10;
                    if (!string.IsNullOrEmpty(pokemon.Ability) && pokemon.Ability.ToLower().Contains("boost"))
                        damage += 20;

                    // Apply weakness/resistance if opponent active pokemon is known
                    if (state.OpponentActivePokemon != null)
                    {
                        var opponent = state.OpponentActivePokemon;
                        if (!string.IsNullOrEmpty(opponent.Weakness) && opponent.Weakness == attack.Type)
                            damage *= 2;
                        if (!string.IsNullOrEmpty(opponent.Resistance) && opponent.Resistance == attack.Type)
                        {
                            damage -= 30;
                            if (damage < 0) damage = 0;
                        }
                    }

                    int score = damage * 10 - requiredAttachments;

                    if (score > bestScore)
                    {
                        bestScore = score;

                        bestPlay = $"Play {pokemon.Name}, attach {requiredAttachments} Energy, use {state.HandTrainers.Count} Trainer(s), attack with {attack.Name} for {damage} damage";

                    }
                }
            }

            return bestPlay;
        }
    }
}
