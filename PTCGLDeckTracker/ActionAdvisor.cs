using System;
using System.Collections.Generic;
using System.Linq;
using PTCGLDeckTracker.CardCollection;

namespace PTCGLDeckTracker
{
    internal static class ActionAdvisor
    {
        public static List<string> GetSuggestions(Player player)
        {
            var suggestions = new List<string>();
            var handCards = player.hand.GetCards();

            if (handCards.Count == 0)
            {
                suggestions.Add("Your hand is empty");
                return suggestions;
            }

            // Suggest attaching an energy card if available
            var energyCard = handCards.Values.FirstOrDefault(c => c.englishName?.Contains("Energy", StringComparison.OrdinalIgnoreCase) == true);
            if (energyCard != null)
            {
                suggestions.Add("Consider attaching an Energy card: " + energyCard.englishName);
            }

            // Suggest playing a trainer card if available
            var trainerCard = handCards.Values.FirstOrDefault(c => c.englishName?.Contains("Trainer", StringComparison.OrdinalIgnoreCase) == true);
            if (trainerCard != null)
            {
                suggestions.Add("You have a Trainer card that might help: " + trainerCard.englishName);
            }

            // Suggest playing a pokemon if available
            var pokemonCard = handCards.Values.FirstOrDefault(c => !(c.englishName?.Contains("Energy", StringComparison.OrdinalIgnoreCase) == true) && !(c.englishName?.Contains("Trainer", StringComparison.OrdinalIgnoreCase) == true));
            if (pokemonCard != null)
            {
                suggestions.Add("Consider playing Pokemon: " + pokemonCard.englishName);
            }

            if (suggestions.Count == 0)
            {
                suggestions.Add("No obvious actions found");
            }
            return suggestions;
        }
    }
}
