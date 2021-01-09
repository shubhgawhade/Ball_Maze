using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _rules;
    [SerializeField] private float _num = 0;

    public static Action TimerAction;

    private void Start()
    {
        _num = 0;
        PlayerBehaviour.RulesEnable += EnableRules;
        PlayerBehaviour.RulesDisable += DisableRules;
        Timer.StopTimer();
    }

    private void Update()
    {
        if(_num > 0)
        {
            if (TimerAction != null)
            {
                TimerAction();
            }
        }
    }

    private void EnableRules()
    {
        if (_num < 1)
        {
            _rules.SetActive(true);
        }
    }

    private void DisableRules()
    {
        if (_rules.activeSelf == true)
        {
            _rules.SetActive(false);
            _num++;
        }
    }

    private void OnDisable()
    {
        PlayerBehaviour.RulesEnable -= EnableRules;
        PlayerBehaviour.RulesDisable -= DisableRules;
    }

    public void Restart()
    {
        GameOver.Over = false;
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
