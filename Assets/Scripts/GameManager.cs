using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;
  public static int recipesBrewed = 0;
  private static int recipesToWin = 2;
  private int timeToLose = 60 * 2; // 2 mins
  public static Dictionary<Constants.Ingredient, int> inventory;

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
    ResetInventory();
    answerPotion = new Dictionary<Constants.Ingredient, int> {
            {Constants.Ingredient.RedRoot, 1},
            {Constants.Ingredient.BlueRoot, 0},
            {Constants.Ingredient.GreenRoot, 0},
            {Constants.Ingredient.Item1, 0},
            {Constants.Ingredient.Item2, 0},
            {Constants.Ingredient.Item3, 0},
        };
    // TODO: uncomment below
    // answerPotion = Interaction.generateAnswer(inventory);
  }

  public static void AddToInventory(Constants.Ingredient ingredient)
  {
    inventory[ingredient]++;
    Debug.Log(inventory);
  }

  private static void ResetInventory()
  {
    foreach (Constants.Ingredient ingredient in Enum.GetValues(typeof(Constants.Ingredient)))
    {
      inventory[ingredient] = 0;
    }
  }

  public static bool BrewMixture()
  {
    Debug.Log("What is brewed: " + GetInventoryString());
    Debug.Log("Correct brew: " + Interaction.mistakeFeedback(Constants.FeedbackType.FullAnswer, answerPotion, potionDiff));
    // Mix the ingredients
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
      answerPotion = Interaction.generateAnswer(inventory);
      gameState = Constants.GameState.InGame;
    }

    if (recipesBrewed >= recipesToWin)
    {
      gameState = Constants.GameState.WinGame;
    }
    ResetInventory();
    return isCorrect;
  }

  private static string GetInventoryString()
  {
    string inventoryString = "";
    foreach (KeyValuePair<Constants.Ingredient, int> entry in inventory)
    {
      inventoryString += entry.Key + ": " + entry.Value + ", ";
    }
    return inventoryString;
  }

  private static void StartTimer()
  {
    isTimerRunning = true;
  }

  public static string GetFeedback()
  {
    // Constants.FeedbackType feedbackType = tries <= 1
    //     ? Constants.FeedbackType.Vague
    //     : tries <= 2
    //     ? Constants.FeedbackType.Specific
    //     : Constants.FeedbackType.FullAnswer;
    Constants.FeedbackType feedbackType = Constants.FeedbackType.Vague;
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
