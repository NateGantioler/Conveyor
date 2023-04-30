using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static int score;
    [SerializeField] static int correctPackagePoints;
    [SerializeField] static int wrongPackagePoints;

    public TextMeshProUGUI timerText;
    public float timer;
    public GameObject endGameScreen;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        timerText.text = Mathf.FloorToInt(timer).ToString();
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            return;
        }
        if (timer <= 0) EndOfGame();
    }

    void EndOfGame()
    {
        endGameScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public static void AddScore()
    {
        score += correctPackagePoints;
        print(score);
    }
    public static void SubtractScore()
    {
        if (score <= 0) return;
        if (score > 0)
        { 
            score -= wrongPackagePoints; 
            if(score < 0) { score = 0; }
        }
        print(score);
    }

}
