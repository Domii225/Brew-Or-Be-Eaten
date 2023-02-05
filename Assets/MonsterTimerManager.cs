using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonsterTimerManager : MonoBehaviour
{
    [SerializeField]
    public GameObject TextObject;

    [SerializeField]
    public float GameTime;

    private float TimeLeft;

    private TMP_Text TextComponent;



    void Start()
    {
        TextComponent = TextObject.GetComponent<TMP_Text>();
        TimeLeft = GameTime;
    }


    void Update()
    {
        if (TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
        }

        if (TimeLeft < 0)
        {
            TimeLeft = 0f;
        }

        TextComponent.text = GetFormattedLeftTime(GameManager.timeLeft);
    }

    string GetFormattedLeftTime(float time)
    {
        double minutes = Math.Floor(time / 60.0f);
        double seconds = time % 60.0f;
        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }

}
