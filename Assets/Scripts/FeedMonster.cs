using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedMonster : MonoBehaviour
{
    private float shakeStrength = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onTriggerEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Success"))
        {
            GameManager.recipesBrewed++;
            if (GameManager.recipesBrewed == 1)
            {
                GameManager.StartTimer();
                GameManager.answerPotion = Interaction.generateAnswer(GameManager.inventory);
                GameManager.gameState = Constants.GameState.InGame;
                Debug.Log("YOUR TIMER STARTS NOW"); // Monster growl
            }
            if (GameManager.recipesBrewed >= GameManager.recipesToWin)
            {
                GameManager.gameState = Constants.GameState.WinGame;
            }
        }
        else
        {
            GameManager.tries++;
            Shake.shakeAmount = GameManager.tries * shakeStrength;
            Shake.shakeStatic = true;
            Debug.Log(collision.gameObject.name); // Monster growl
        }
        Destroy(collision.gameObject);
    }
}
