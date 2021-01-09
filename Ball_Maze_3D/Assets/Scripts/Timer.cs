using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text _timerText;

    [SerializeField] private float _time;

    public static Action GameOverAction;
    public static Action<int, float> SaveScore;

    [SerializeField] private int _minutes = 0;
    
    public static bool timerStarted;

    // Start is called before the first frame update
    void Start()
    {
        UI.TimerAction += TimerStart;
        PlayerBehaviour.SaveScore += a;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted && _minutes < 60 && GameOver.Over == false)
        {
            _time += Time.deltaTime;
        }
        else
        {
            timerStarted = false;
        }
    }

    private void TimerStart()
    {
        if (timerStarted == false)
        {

            timerStarted = true;
            if (_time > 60)
            {
                _time -= 60;
                _minutes++;

                if (_minutes > 59)
                {
                    if (GameOverAction != null)
                    {
                        if (SaveScore != null)
                        {
                            SaveScore(_minutes, _time);
                        }
                        GameOverAction();
                    }
                }
            }
        }
        if (GameOver.Over == false)
        {
            _timerText.text = _time.ToString("#" + _minutes + ":00.000");
        }
    }

    public static void StopTimer()
    {
        timerStarted = false;
    }

    private void a()
    {
        if (SaveScore != null)
        {
            SaveScore(_minutes, _time);
        }
    }
}
