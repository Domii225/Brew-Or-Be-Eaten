using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static Dictionary<Constants.Ingredient, int> inventory = new Dictionary<Constants.Ingredient, int>{
        {Constants.Ingredient.Root1, 0},
        {Constants.Ingredient.Root2, 0},
        {Constants.Ingredient.Root3, 0},
        {Constants.Ingredient.Item1, 0},
        {Constants.Ingredient.Item2, 0},
        {Constants.Ingredient.Item3, 0},
    };
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
}
