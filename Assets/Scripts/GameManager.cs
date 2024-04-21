using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreUI;

    private int life = 3;
    public TextMeshProUGUI lifeUI;

    public void UpdateScore(int delta)
    {
        score += delta;
        scoreUI.text = score.ToString();
    }

    public void UpdateLife(int delta)
    {
        life += delta;
        lifeUI.text = life.ToString();
    }
}
