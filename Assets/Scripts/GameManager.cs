using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;
  public static int recipesBrewed = 0;
  public static int recipesToWin = 2;
  private int timeToLose = 60 * 2; // 2 mins
  public static Dictionary<Constants.Ingredient, int> inventory = new Dictionary<Constants.Ingredient, int>();

  public static Dictionary<Constants.Ingredient, int> answerPotion = new Dictionary<Constants.Ingredient, int>();

  private static Dictionary<Constants.Ingredient, int> potionDiff = new Dictionary<Constants.Ingredient, int>(); // dictionary to log difference in ingradients

  public static Constants.GameState gameState = Constants.GameState.PreGame;
  public static float timeNow = 0f;
  public static float timeLeft = 0f;
  private static bool isTimerRunning = false;
  public static int tries = 0;
  private static int triesMax = 3;
  [SerializeField] private GameObject TextObject;
  private static MonsterResponseManager monsterResponseManager;
  private bool isHurryUp = false;

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
            {Constants.Ingredient.BlueRoot, 1},
            {Constants.Ingredient.GreenRoot, 1},
            {Constants.Ingredient.Item1, 0},
            {Constants.Ingredient.Item2, 0},
            {Constants.Ingredient.Item3, 0},
        };
    monsterResponseManager = TextObject.GetComponent<MonsterResponseManager>();
    // TODO: uncomment below
    // answerPotion = Interaction.generateAnswer(inventory);
  }

  public static void AddToInventory(Constants.Ingredient ingredient)
  {
    inventory[ingredient]++;
    Debug.Log(GetDictionaryString(inventory));
  }

  private static void ResetInventory()
  {
    foreach (Constants.Ingredient ingredient in Enum.GetValues(typeof(Constants.Ingredient)))
    {
        if (inventory.ContainsKey(ingredient))
        {
            inventory[ingredient] = 0;
        }
        else
        {
            inventory.Add(ingredient, 0);
        }
    }
  }

  public static bool BrewMixture()
  {
    Debug.Log("What is brewed: " + GetDictionaryString(inventory));
    Debug.Log("Correct brew: " + Interaction.mistakeFeedback(Constants.FeedbackType.FullAnswer, answerPotion, potionDiff));
    // Mix the ingredients
    potionDiff = Interaction.receive(inventory, answerPotion);
    bool isCorrect = potionDiff.Count == 0;

    ResetInventory();
    return isCorrect;
  }

  public static string GetDictionaryString(Dictionary<Constants.Ingredient, int> dict)
  {
    string dictString = "";
    foreach (KeyValuePair<Constants.Ingredient, int> entry in dict)
    {
      dictString += entry.Key + ": " + entry.Value + ", ";
    }
    return dictString;
  }

  public static void StartTimer()
  {
    isTimerRunning = true;
  }

  public static void MonsterMessage(string message)
  {
    monsterResponseManager.ShowResponse(message);
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
      timeLeft = timeToLose - timeNow;
      if (timeLeft < 30f)
      {
        Shake.shakeAmount = 0.1f;
        Shake.shakeStatic = true;
        if (!isHurryUp)
        {
          isHurryUp = true;
          MonsterMessage("HURRY UP!! 30 SECONDS LEFT!!");
        }
      }
      if (timeNow >= timeToLose)
      {
        isTimerRunning = false;
        gameState = Constants.GameState.LoseGame;
      }
    }
  }
}
