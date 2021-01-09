using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveScore : MonoBehaviour
{
    [SerializeField] GameObject Player;

    [SerializeField] Text highScoreText;

    private float timeInSeconds;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        Timer.SaveScore += Scoring;

        highScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString("#.000") + "s";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Scoring(int _minutes, float _seconds)
    {
        Player.GetComponent<PlayerBehaviour>().enabled = false;

        timeInSeconds = (_minutes * 60) + _seconds;

        if (timeInSeconds < PlayerPrefs.GetFloat("HighScore") || PlayerPrefs.GetFloat("HighScore") < 1)
        {
            PlayerPrefs.SetFloat("HighScore", timeInSeconds);
            highScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString("#.000") + "s";
        }
    }
    private void OnDisable()
    {
        Timer.SaveScore-=Scoring;
    }
}
