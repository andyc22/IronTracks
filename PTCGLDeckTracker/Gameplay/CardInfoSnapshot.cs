using System.Collections.Generic;
using System.Linq;
using MatchLogic;
using RainierClientSDK;

namespace PTCGLDeckTracker.Gameplay
{
    /// <summary>
    /// Lightweight snapshot of properties from <see cref="CardInfo"/> used by the
    /// tracker.  This allows accessing key information without keeping a
    /// reference to the live game objects.
    /// </summary>
    internal class CardInfoSnapshot
    {
        public string EntityId { get; }
        public string CardName { get; }
        public string CardSourceId { get; }
        public CardFormat Format { get; }
        public BoardPos CurrentPos { get; }
        public bool IsMyCard { get; }
        public bool IsEnergy { get; }
        public bool IsPokemon { get; }
        public bool IsTrainer { get; }
        public int TotalHP { get; }
        public int RetreatCost { get; }
        public int WeaknessAmount { get; }
        public int ResistanceAmount { get; }
        public CardStage Stage { get; }
        public IReadOnlyCollection<EnergyType> WeaknessTyping { get; }
        public IReadOnlyCollection<EnergyType> ResistanceTyping { get; }
        public IReadOnlyCollection<EnergyType> CardTyping { get; }
        public string TotalEnergy { get; }
        public string EnergyValue { get; }
        public IReadOnlyList<AppliedStatusEffect> PositiveStatusEffects { get; }
        public IReadOnlyList<AppliedStatusEffect> NegativeStatusEffects { get; }

        public CardInfoSnapshot(ICardInfo info)
        {
            EntityId = info.entityID;
            CardName = info.cardName;
            CardSourceId = info.cardSourceID;
            Format = info.cardFormat;
            CurrentPos = info.currentPos;
            IsMyCard = info.isMyCard;
            IsEnergy = info.isEnergy;
            IsPokemon = info.isPokemon;
            IsTrainer = info.isTrainer;
            WeaknessTyping = info.weaknessTyping.ToList().AsReadOnly();
            ResistanceTyping = info.resistanceTyping.ToList().AsReadOnly();
            CardTyping = info.cardTyping.ToList().AsReadOnly();
            // Cast to CardInfo to access additional properties not in ICardInfo
            if (info is CardInfo card)
            {
                TotalHP = card.totalHP;
                RetreatCost = card.retreatCost;
                WeaknessAmount = card.weaknessAmount;
                ResistanceAmount = card.resistanceAmount;
                Stage = card.cardStage;
                TotalEnergy = card.totalEnergy;
                EnergyValue = card.energyValue;
                PositiveStatusEffects = card.posStatusEffects.ToList().AsReadOnly();
                NegativeStatusEffects = card.negsStatusEffects.ToList().AsReadOnly();
            }
            else
            {
                PositiveStatusEffects = info.posStatusEffects.ToList().AsReadOnly();
                NegativeStatusEffects = info.negsStatusEffects.ToList().AsReadOnly();
            }
        }
    }
}
