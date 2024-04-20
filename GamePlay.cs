using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3.ProvidedCode;


namespace Assignment3
{
    internal class GamePlay
    {
        public void RegenerateDrawPile()
        {
            if (Player.DiscardPile == null || Player.DiscardPile.Count == 0)
            {
                throw new InvalidOperationException("Cannot regenerate draw pile from an empty discard pile.");
            }

            if (Player.DrawPile == null)
            {
                Player.DrawPile = new List<Card>();
            }

            // moves all the cards but moves the last one to the draw pile
            while (Player.DiscardPile.Count > 1)
            {
                var card = Player.DiscardPile[0];
                Player.DiscardPile.RemoveAt(0);
                Player.DrawPile.Add(card);
            }
        }

        // shuffle
        public void ShuffleDrawPile()
        {
            if (Player.DrawPile == null || Player.DrawPile.Count <= 1)
            {
                throw new InvalidOperationException("Cannot shuffle an empty or single-card draw pile.");
            }

            Random rng = new Random();
            int n = Player.DrawPile.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = Player.DrawPile[k];
                Player.DrawPile[k] = Player.DrawPile[n];
                Player.DrawPile[n] = value;
            }
        }
    }

    internal class NumberCard : Card, IColorCard
    {
        public CardColor Color { get; set; }
        public int Number { get; }

        public NumberCard(CardColor color, int number)
        {
            Color = color;
            Number = number;
        }

        public override bool IsPlayable(Card previousCard)
        {
            if (previousCard == null) return false;

            if (previousCard is NumberCard prevNumberCard)
            {
                return prevNumberCard.Color == this.Color || prevNumberCard.Number == this.Number;
            }

            if (previousCard is IColorCard prevColorCard)
            {
                return prevColorCard.Color == this.Color;
            }

            return false;
        }
    }

    internal class ActionColorCard : Card, IActionCard, IColorCard
    {
        public CardColor Color { get; set; }
        public CardAction Action { get; }

        public ActionColorCard(CardAction action, CardColor color)
        {
            Action = action;
            Color = color;
        }

        public override bool IsPlayable(Card previousCard)
        {
            if (previousCard == null) return false;

            if (previousCard is IColorCard prevColorCard)
            {
                return prevColorCard.Color == this.Color;
            }

            return false;
        }
    }

    internal class WildCard : Card, IActionCard
    {
        public CardAction Action { get; }
        public CardColor Color { get; set; }

        public WildCard(CardAction action)
        {
            Action = action;
        }
        public void SetColor(CardColor color)
        {
            this.Color = color;
        }

        public override bool IsPlayable(Card previousCard)
        {
            return true;
        }
    }
}
