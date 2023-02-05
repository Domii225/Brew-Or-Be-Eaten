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
            case "Eyeball":
                return Constants.Ingredient.Eyeball;
            case "Heart":
                return Constants.Ingredient.Heart;
            case "Mandragora":
                return Constants.Ingredient.Mandragora;
            default:
                return Constants.Ingredient.Mandragora;
        }
    }
}
