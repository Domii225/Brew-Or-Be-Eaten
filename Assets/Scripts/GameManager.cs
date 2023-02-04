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

    public static Constants.GameState gameState = Constants.GameState.PreGame;
    public static float timeNow = 0f;
    private static bool isTimerRunning = false;

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
        bool isCorrect = true;
        if (isCorrect)
        {
            recipesBrewed++;
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
