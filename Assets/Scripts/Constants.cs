using System.Collections;
using System.Collections.Generic;

namespace Constants
{
    public enum GameState
    {
        PreGame,
        InGame,
        WinGame,
        LoseGame,
    }

    public enum Ingredient
    {
        RedRoot,
        BlueRoot,
        GreenRoot,
        Item1,
        Item2,
        Item3,
    }

    public enum FeedbackType
    {
        Vague,
        Specific,
        FullAnswer,
    }
}
