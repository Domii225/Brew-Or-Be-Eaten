using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public static TMPro.TMP_Text UItext;
    private bool startGame = false;
    // Start is called before the first frame update
    void Start()
    {
        UItext = GetComponent<TMPro.TMP_Text>();
        UItext.text = @"Instructions:
        1. Grab ingredients from table or roof.
        2. Put ingredients in cauldron.
        3. Stir ingredients with spoon.
        4. Feed creation to monster.";

        UItext.text += "You need: " + GameManager.GetDictionaryString(GameManager.answerPotion);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameState == Constants.GameState.InGame && !startGame)
        {
            startGame = true;
            UItext.text = @"Instructions:
            1. Grab ingredients from table or roof.
            2. Put ingredients in cauldron.
            3. Stir ingredients with spoon.
            4. Feed creation to monster.";

            UItext.text += "You need: ";
            foreach (Constants.Ingredient ingredient in Enum.GetValues(typeof(Constants.Ingredient)))
            {
                UItext.text += ingredient + ": ?, ";
            }
        }
        if (GameManager.gameState == Constants.GameState.WinGame)
        {
            UItext.text = "You win!";
        }
        if (GameManager.gameState == Constants.GameState.LoseGame)
        {
            UItext.text = "You lose!";
        }
    }
}
