using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Assignment3.ProvidedCode;


namespace Assignment3
{
    internal class Player
    { // properties
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
        public static List<Card> DrawPile { get; set; }
        public static List<Card> DiscardPile { get; set; }
        public Player(string name)
        {
            Name = name;
            Cards = new List<Card>();
        }

        // gets a card from the draw pile
        public Card GetCard()
        {
            if (DrawPile == null || DrawPile.Count == 0)
            {
                throw new InvalidOperationException("Draw pile is empty.");
            }

            var drawnCard = DrawPile[0];
            DrawPile.RemoveAt(0);
            return drawnCard;
        }

        // places a card in the discard pile
        public bool PlaceCard(Card card, Card previousCard = null, CardColor? newColor = null)
        {
            if (card == null) return false;

            if (previousCard != null && !card.IsPlayable(previousCard))
            {
                return false;
            }

            if (card is WildCard wildCard && newColor.HasValue)
            {
                wildCard.SetColor(newColor.Value);
            }

            if (Cards.Remove(card))
            {
                if (DiscardPile == null)
                {
                    DiscardPile = new List<Card>();
                }

                DiscardPile.Add(card);
                return true;
            }

            return false;
        }
    }
}
