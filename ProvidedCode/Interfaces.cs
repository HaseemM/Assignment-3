using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.ProvidedCode
{
    // DO NOT MODIFY THIS FILE

    // interface for cards that have a color
    interface IColorCard
    {
        // Color used for specify the color of the card.
        // For wild cards, Color used for storing the user's choice on what color card comes next.
        CardColor Color { get; set; }
    }


    // interface for action cards
    interface IActionCard
    {
        // Specifies the action type of the card.
        CardAction Action { get; }
    }


    // Types of actions used by action cards (both color action cards and wild action cards)
    public enum CardAction
    {
        // color action cards
        Reverse, Skip, DrawTwo,

        // wild action cards
        Wild, WildDrawFour, WildSwapHands, WildShuffleHands
    }
}
