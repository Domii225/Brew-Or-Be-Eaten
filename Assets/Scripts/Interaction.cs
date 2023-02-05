using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using System.Linq;


public static class Interaction
{
    private static int difficulty = 4;
    private static Random rnd = new Random();

    public static Dictionary<Constants.Ingredient, int> generateAnswer(Dictionary<Constants.Ingredient, int> answerPotion)
    {
        Dictionary<Constants.Ingredient, int> copyPotion = answerPotion.ToDictionary<KeyValuePair<Constants.Ingredient, int>, Constants.Ingredient, int>(entry => entry.Key, entry => entry.Value);;
        foreach(KeyValuePair<Constants.Ingredient, int> ingredient in answerPotion)
        {
            copyPotion[ingredient.Key] = rnd.Next(difficulty); //tweak difficulty
        }
        // copy answerPotion
        return copyPotion;
    }
    public static Dictionary<Constants.Ingredient, int> receive(Dictionary<Constants.Ingredient, int> currPotion, Dictionary<Constants.Ingredient, int> answerPotion)
    {
        Dictionary<Constants.Ingredient, int> potionDiff = new Dictionary<Constants.Ingredient, int>();
        int mistakeCount = 0;
        foreach (KeyValuePair<Constants.Ingredient, int> ingredient in currPotion)
        {
            if(currPotion[ingredient.Key] != answerPotion[ingredient.Key])
            {
                potionDiff.Add(ingredient.Key, currPotion[ingredient.Key] - answerPotion[ingredient.Key]);
                mistakeCount++;
            }
        }
        return potionDiff;
    }


    public static string mistakeFeedback(Constants.FeedbackType feedbackType, Dictionary<Constants.Ingredient, int> answerPotion, Dictionary<Constants.Ingredient, int> potionDiff)
    {
        string output;
        switch (feedbackType)
        {
            case Constants.FeedbackType.Vague:
                int index = rnd.Next(potionDiff.Count);
                if (potionDiff.ElementAt(index).Value > 0)
                {
                    output = "ARGHH!! THERE IS TOO MUCH " + potionDiff.ElementAt(index).Key;
                }
                else
                {
                    output = "ARGHH!! THERE IS TOO LITTLE " + potionDiff.ElementAt(index).Key;
                }
                break;
            case Constants.FeedbackType.Specific:
                string tooMuch = "";
                string tooLittle = "";
                foreach (KeyValuePair<Constants.Ingredient, int> ingredient in potionDiff)
                {
                    if (ingredient.Value > 0)
                    {
                        tooMuch += ingredient.Key + ", ";
                    }
                    else
                    {
                        tooLittle += ingredient.Key + ", ";
                    }
                }
                output = "WRONG!!! THERE IS TOO MUCH" + tooMuch + " AND TOO LITTLE " + tooLittle;
                break;
            case Constants.FeedbackType.FullAnswer:
                output = "!@#$%! I WANT: ";
                foreach (KeyValuePair<Constants.Ingredient, int> ingredient in answerPotion)
                {
                    output += ingredient.Value + " " + ingredient.Key + ", ";
                }
                break;
            default:
                output = "";
                break;
        }
        return output;
    }

}
