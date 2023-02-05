using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonsterResponseManager : MonoBehaviour
{
    [SerializeField]
    public GameObject TextObject;
    
    [SerializeField]
    public float ResponseTimeout;

    private TMP_Text TextComponent;


    void Start()
    {
        TextComponent = TextObject.GetComponent<TMP_Text>();
        ShowResponse("HELLO USER");
    }

    public void ShowResponse(string response)
    {
        TextComponent.text = response;
        Invoke("CleanResponse", ResponseTimeout);
    }

    public void CleanResponse()
    {
        TextComponent.text = "";
    }
}
