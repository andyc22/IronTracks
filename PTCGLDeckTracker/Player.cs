using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using PTCGLDeckTracker.CardCollection;
using static ContentItemCellRow;
using static MelonLoader.MelonLogger;
using TPCI.Rainier.Match.Cards.Ownership;
using TPCI.Rainier.Match.Cards;

namespace PTCGLDeckTracker
{
    internal partial class Player
    {
        public string username { get; set; }

        // Card Collections
        public Deck deck { get; set; }
        public DiscardPile discardPile { get; set; }
        public Hand hand { get; set; }
        public Card3D activePokemon { get; private set; }
        public List<Card3D> benchPokemon { get; } = new List<Card3D>();
        // key: pokemon entityID
        private Dictionary<string, List<Card3D>> _attachedEnergies = new Dictionary<string, List<Card3D>>();

        public Player()
        {
            this.deck = new Deck("playerOne");
            this.discardPile = new DiscardPile();
            this.hand = new Hand();
            this.username = string.Empty;
        }

        private string GetKey(Card3D card) => card.entityID;

        public void SetActivePokemon(Card3D card)
        {
            activePokemon = card;
            var key = GetKey(card);
            if (!_attachedEnergies.ContainsKey(key))
            {
                _attachedEnergies[key] = new List<Card3D>();
            }
        }

        public void AddBenchPokemon(Card3D card)
        {
            benchPokemon.Add(card);
            var key = GetKey(card);
            if (!_attachedEnergies.ContainsKey(key))
            {
                _attachedEnergies[key] = new List<Card3D>();
            }
        }

        public void RemoveBenchPokemon(Card3D card)
        {
            benchPokemon.RemoveAll(c => c.entityID == card.entityID);
            _attachedEnergies.Remove(GetKey(card));
        }

        public void AttachEnergy(Card3D pokemon, Card3D energy)
        {
            var key = GetKey(pokemon);
            if (!_attachedEnergies.ContainsKey(key))
            {
                _attachedEnergies[key] = new List<Card3D>();
            }
            _attachedEnergies[key].Add(energy);
        }

        public void DetachEnergy(Card3D pokemon, Card3D energy)
        {
            var key = GetKey(pokemon);
            if (_attachedEnergies.ContainsKey(key))
            {
                _attachedEnergies[key].RemoveAll(e => e.entityID == energy.entityID);
            }
        }

        public void OnEnergyAttached(Card3D energy, Card3D pokemon)
        {
            AttachEnergy(pokemon, energy);
        }

        public void OnEnergyDetached(Card3D energy, Card3D pokemon)
        {
            DetachEnergy(pokemon, energy);
        }


        public void OnGainCardIntoCollection(Card3D cardAdded, PlayerCardOwner playerCardOwner)
        {
            var ownerName = playerCardOwner.GetType().Name;
            if (ownerName.Contains("Deck"))
            {
                deck.OnCardAdded(cardAdded);
            }
            else if (ownerName.Contains("Hand"))
            {
                hand.OnCardAdded(cardAdded);
            }
            else if (ownerName.Contains("Prize"))
            {
                deck.prizeCards.OnCardAdded(cardAdded);
            }
            else if (ownerName.Contains("Bench"))
            {
                AddBenchPokemon(cardAdded);
            }
            else if (ownerName.Contains("Active"))
            {
                SetActivePokemon(cardAdded);
            }
        }

        public void OnRemovedCardFromCollection(Card3D cardRemoved, PlayerCardOwner playerCardOwner)
        {
            var ownerName = playerCardOwner.GetType().Name;
            if (ownerName.Contains("Deck"))
            {
                deck.OnCardRemoved(cardRemoved);
            }
            else if (ownerName.Contains("Hand"))
            {
                hand.OnCardRemoved(cardRemoved);
            }
            else if (ownerName.Contains("Prize"))
            {
                deck.prizeCards.OnCardRemoved(cardRemoved);
            }
            else if (ownerName.Contains("Bench"))
            {
                RemoveBenchPokemon(cardRemoved);
            }
            else if (ownerName.Contains("Active"))
            {
                if (activePokemon != null && activePokemon.entityID == cardRemoved.entityID)
                {
                    activePokemon = null;
                }
                _attachedEnergies.Remove(cardRemoved.entityID);
            }
        }

        public PrizeCards GetPrizeCards()
        {
            return deck.prizeCards;
        }

        public void ClearCollections()
        {
            deck.Clear();
            discardPile.Clear();
            hand.Clear();
            activePokemon = null;
            benchPokemon.Clear();
            _attachedEnergies.Clear();
        }
    }
}
