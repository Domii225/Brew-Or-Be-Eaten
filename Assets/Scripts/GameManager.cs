using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int recipesBrewed = 0;
    private static int recipesToWin = 5;
    private int timeToLose = 60 * 2; // 2 mins
    public static Dictionary<Constants.Ingredient, int> inventory = new Dictionary<Constants.Ingredient, int>{
        {Constants.Ingredient.Root1, 0},
        {Constants.Ingredient.Root2, 0},
        {Constants.Ingredient.Root3, 0},
        {Constants.Ingredient.Item1, 0},
        {Constants.Ingredient.Item2, 0},
        {Constants.Ingredient.Item3, 0},
    };

    private static Dictionary<Constants.Ingredient, int> answerPotion;

    private static Dictionary<Constants.Ingredient, int> potionDiff; // dictionary to log difference in ingradients

    public static Constants.GameState gameState = Constants.GameState.PreGame;
    public static float timeNow = 0f;
    private static bool isTimerRunning = false;
    private static int tries = 0;
    private static int triesMax = 3;

    void Awake()
    {
        // Debug.Log("awake!");
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        answerPotion = Interaction.generateAnswer(inventory);
    }

    public static void AddToInventory(Constants.Ingredient ingredient)
    {
        inventory[ingredient]++;
    }

    private static void ResetInventory()
    {
        inventory[Constants.Ingredient.Root1] = 0;
        inventory[Constants.Ingredient.Root2] = 0;
        inventory[Constants.Ingredient.Root3] = 0;
        inventory[Constants.Ingredient.Item1] = 0;
        inventory[Constants.Ingredient.Item2] = 0;
        inventory[Constants.Ingredient.Item3] = 0;
    }

    public static bool BrewMixture()
    {
        ResetInventory();
        // TODO: Mix the ingredients
        potionDiff = Interaction.receive(inventory, answerPotion);
        bool isCorrect = potionDiff.Count == 0;
        if (isCorrect)
        {
            recipesBrewed++;
        }
        else
        {
            tries++;
        }
        if (recipesBrewed == 1)
        {
            StartTimer();
            gameState = Constants.GameState.InGame;
        }

        if (recipesBrewed >= recipesToWin)
        {
            gameState = Constants.GameState.WinGame;
        }
        return isCorrect;
    }

    private static void StartTimer()
    {
        isTimerRunning = true;
    }

    public static string GetFeedback()
    {
        Constants.FeedbackType feedbackType= tries <= 1 
            ? Constants.FeedbackType.Vague 
            : tries <= 2
            ? Constants.FeedbackType.Specific
            : Constants.FeedbackType.FullAnswer;
        return Interaction.mistakeFeedback(feedbackType, answerPotion, potionDiff);
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timeNow += Time.deltaTime;
            if (timeNow >= timeToLose)
            {
                isTimerRunning = false;
                gameState = Constants.GameState.LoseGame;
            }
        }
    }
}
