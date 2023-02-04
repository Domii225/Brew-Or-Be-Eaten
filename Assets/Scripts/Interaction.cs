using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using System.Linq;


public class Interaction : MonoBehaviour
{
    public Dictionary<string,int> currPotion; //potion that the player creates
    public Dictionary<string, int> answerPotion; //fixed answer generated at start of game
    public Dictionary<string, int> potionDiff; // dictionary to log difference in ingradients
    private Random rnd = new Random();

    // Start is called before the first frame update
    void Start()
    {
        generateAnswer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateAnswer()
    {
        foreach(KeyValuePair<string, int> ingredient in answerPotion)
        {
            answerPotion[ingredient.Key] = rnd.Next(4); //tweak difficulty
        }
    }
    public bool receive()
    {
        int mistakeCount = 0;
        foreach (KeyValuePair<string, int> ingredient in currPotion)
        {
            if(currPotion[ingredient.Key] != answerPotion[ingredient.Key])
            {
                potionDiff.Add(ingredient.Key, currPotion[ingredient.Key] - answerPotion[ingredient.Key]);
                mistakeCount++;
            }
        }

        if(mistakeCount == 0)
        {
            victory();
            Debug.Log("u win");
            return true;
        }
        else
        {
            mistakeFeedback();
            return false;
        }
    }


    public void mistakeFeedback()
    {
        string output;
        int index = rnd.Next(potionDiff.Count);
        if (potionDiff.ElementAt(index).Value > 0)
        {
            output = "THERE IS TOO MUCH" + potionDiff.ElementAt(index);
        }
        else
        {
            output = "THERE IS TOO LITTLE" + potionDiff.ElementAt(index);
        }

        //add more feedback
    }
    public void victory()
    {
        //win actions
    }

}
