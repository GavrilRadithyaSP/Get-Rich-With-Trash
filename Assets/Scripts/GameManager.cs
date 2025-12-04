using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("===Score Settings===")]
    public int score = 0;
    public int targetScore = 10;
    public TextMeshProUGUI scoreText;

    [Header("===Timer Settings===")]
    [SerializeField] float timeRemaining;   // waktu awal
    [SerializeField] TextMeshProUGUI timerText;
    private bool isGameOver = false;

    [Header("===Panels===")]
    public GameObject winPanel;
    public GameObject losePanel;

    void Start()
    {
        UpdateScoreUI();
        UpdateTimerUI();
    }

    void Update()
    {
        if (isGameOver) return;

       if (timeRemaining > 0)
       {
        timeRemaining -= Time.deltaTime;
       } 
       else if (timeRemaining < 0)
       {
        timeRemaining = 0;
        timerText.color = Color.red;
        GameOver(false);
       }
       UpdateTimerUI();
    }

    // Dipanggil saat player mengambil sampah
    public void AddScore(int value)
    {
        if (isGameOver) return;

        score += value;
        UpdateScoreUI();

        if (score >= targetScore)
        {
            GameOver(true);
        }
    }

    // Dipanggil saat player kena paku atau bahaya
    public void ReduceTime(float value)
    {
        if (isGameOver) return;

        timeRemaining -= value;
        if (timeRemaining < 0) timeRemaining = 0;

        UpdateTimerUI();

        if (timeRemaining <= 0)
        {
            // timeRemaining = 0;
            GameOver(false);
        }
    }

    public void ReduceScore(int value)
    {
        if (isGameOver) return;

        score -= value;
        UpdateScoreUI();

        // Jika score minus maka kalah
        if (score < 0)
        {
            GameOver(false);
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = score + " of " + targetScore;
    }

    void UpdateTimerUI()
    {
        float displayTime = Mathf.Max(timeRemaining, 0); // kunci ke 0
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}",minutes, seconds);
    }

    void GameOver(bool isWin)
    {
        isGameOver = true;

        if (isWin)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
