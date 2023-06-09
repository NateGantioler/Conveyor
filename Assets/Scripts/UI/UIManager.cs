using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [Header("Reviews")]
    public TextMeshProUGUI[] reviews; 
    public string[] goodReviews;
    public string[] badReviews;


    public void LoadLevel(int lvl) { SceneManager.LoadScene(lvl); }
    public void LoadLevel(string lvl) { SceneManager.LoadScene(lvl); }

    bool endOfGameExecuted;
    private void Start()
    {
        packagesDelivered = 0;

        staticCorrectPackagePoints = correctPackagePoints;
        staticWrongPackagePoints = wrongPackagePoints;

        endOfGameExecuted = false;

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
        if (timer <= 0 && !endOfGameExecuted) { EndOfGame(); endOfGameExecuted = true; }
        
    }

    void EndOfGame()
    {
        finalScoreText.text = score.ToString();
        packagesDeliveredText.text = packagesDelivered.ToString();
        packagesDroppedText.text = packagesDropped.ToString();

        // REVIEW

        if(packagesDropped >= 3)
        {
            for (int i = 0; i < reviews.Length; i++)
            {
                //Random.InitState((int)System.DateTime.Now.Ticks));
                int rand = Random.Range(0, badReviews.Length);
                reviews[i].text = badReviews[rand];
            }
        }
        else if (packagesDropped < 3)
        {
            for (int i = 0; i < reviews.Length; i++)
            {
                //Random.InitState((int)System.DateTime.Now.Ticks));
                int rand = Random.Range(0, goodReviews.Length);
                reviews[i].text = goodReviews[rand];
            }
        }

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
