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

    void OnTriggerEnter(Collider other)
    {
        Transform t = other.transform;
        while (t.parent != null)
        {
            t = t.parent.gameObject.transform;
        }
        if (t.name.Contains("Success"))
        {
            GameManager.recipesBrewed++;
            if (GameManager.recipesBrewed == 1)
            {
                GameManager.StartTimer();
                GameManager.answerPotion = Interaction.generateAnswer(GameManager.inventory);
                GameManager.gameState = Constants.GameState.InGame;
                Debug.Log("YOUR TIMER STARTS NOW"); // Monster growl
                GameManager.MonsterMessage("YOUR TIMER STARTS NOW");
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
            Debug.Log(t.name); // Monster growl
            GameManager.MonsterMessage(t.name);
        }
        Destroy(t.gameObject);
    }
}
