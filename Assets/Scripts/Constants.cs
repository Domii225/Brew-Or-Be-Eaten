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
        Eyeball,
        Heart,
        Mandragora,
    }

    public enum FeedbackType
    {
        Vague,
        Specific,
        FullAnswer,
    }
}
