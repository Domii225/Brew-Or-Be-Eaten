using System.Collections;
using System.Collections.Generic;

public static class Utilities
{
    public static Constants.Ingredient GetIngredientFromTag(string tag)
    {
        switch (tag)
        {
            case "RedRoot":
                return Constants.Ingredient.RedRoot;
            case "BlueRoot":
                return Constants.Ingredient.BlueRoot;
            case "GreenRoot":
                return Constants.Ingredient.GreenRoot;
            case "Item1":
                return Constants.Ingredient.Item1;
            case "Item2":
                return Constants.Ingredient.Item2;
            case "Item3":
                return Constants.Ingredient.Item3;
            default:
                return Constants.Ingredient.Item3;
        }
    }
}
