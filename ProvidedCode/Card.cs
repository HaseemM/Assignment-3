using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.ProvidedCode
{
    // DO NOT MODIFY THIS FILE

    public abstract partial class Card
    {
        public CardColor Color { get; set; }

        // method for checking if this card can be placed on the previously played card on the discard pile.
        // returns true if card can be played.
        public abstract bool IsPlayable(Card previousCard);
    }

    // Possible card colors
    public enum CardColor
    {
        Red, Green, Yellow, Blue
    }
}
