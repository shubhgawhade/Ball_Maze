using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameEnd;

    public static bool Over;

    // Start is called before the first frame update
    void Start()
    {
        Timer.GameOverAction += AfterGame;
        PlayerBehaviour.GameOver += AfterGame;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AfterGame()
    {
        Timer.StopTimer();
        Over = true;
        gameEnd.SetActive(true);
    }

    private void OnDisable()
    {
        Timer.GameOverAction -= AfterGame;
        PlayerBehaviour.GameOver -= AfterGame;
    }
}
