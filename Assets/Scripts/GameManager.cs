using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreUI;

    private int life = 3;
    public TextMeshProUGUI lifeUI;

    public GameObject gameplayUI;
    public GameObject gameOverUI;
    public TextMeshProUGUI finalScoreUI;

    public PlayerInput playerInput;

    private void Start()
    {
        gameOverUI.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    public void Pause()
    {
        playerInput.SwitchCurrentActionMap("UI");
        gameplayUI.SetActive(false);
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        playerInput.SwitchCurrentActionMap("Player");
        Time.timeScale = 1;
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        playerInput.SwitchCurrentActionMap("UI");
        gameplayUI.SetActive(false);
        finalScoreUI.text = score.ToString();
        gameOverUI.SetActive(true);
    }

    public void UpdateScore(int delta)
    {
        score += delta;
        scoreUI.text = score.ToString();
    }

    public void UpdateLife(int delta)
    {
        life += delta;
        lifeUI.text = life.ToString();
        if (life <= 0)
        {
            GameOver();
        }
    }
}
