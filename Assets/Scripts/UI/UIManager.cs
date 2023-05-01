using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static int score;
    static int staticCorrectPackagePoints;
    static int staticWrongPackagePoints;
    
    // +1 every time a package gets delivered
    static int packagesDelivered;
    static int packagesDropped;

    [Header("Score")]
    public TextMeshProUGUI scoreText;
    public int correctPackagePoints;
    public int wrongPackagePoints;
    
    [Space]
    [Header("Timer")]
    public TextMeshProUGUI timerText;
    public float startTimer;
    float timer;

    public GameObject endGameScreen;

    [Space]
    [Header("End game UI")]
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI packagesDeliveredText;
    public TextMeshProUGUI packagesDroppedText;

    private void Start()
    {
        packagesDelivered = 0;

        staticCorrectPackagePoints = correctPackagePoints;
        staticWrongPackagePoints = wrongPackagePoints;

        timer = startTimer;
        score = 0;
    }

    private void Update()
    {
        print(score);
        timerText.text = Mathf.FloorToInt(timer).ToString();
        scoreText.text = score.ToString();
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return;
        }
        if (timer <= 0) EndOfGame();
        
    }

    void EndOfGame()
    {
        finalScoreText.text = score.ToString();
        packagesDeliveredText.text = packagesDelivered.ToString();
        packagesDroppedText.text = packagesDropped.ToString();
        endGameScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    #region score functions
    public static void AddScore()
    {
        packagesDelivered += 1;
        score += staticCorrectPackagePoints;
        print("score changed");
    }
    public static void SubtractScore()
    {
        packagesDropped += 1;
        if (score <= 0) return;
        if (score > 0)
        {
            score -= staticWrongPackagePoints; 
            if(score < 0) { score = 0; }
        }
        print("score changed");
    }
    #endregion

}
