using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    public GameObject objekScore; // drag TextMeshPro UI object ke sini di Inspector
    private TextMeshProUGUI teksScore;
    private HealthBar healthBar;

    private void Start()
    {
        teksScore = objekScore.GetComponent<TextMeshProUGUI>();
        healthBar = GetComponent<HealthBar>();
        UpdateScoreUI();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PREMAN"))
        {
            score -= 10;
            UpdateScoreUI();
            healthBar.TakeDamage(1);
            // Destroy(other.gameObject);
        }
        else if (other.CompareTag("SAMPAH"))
        {
            score += 10;
            UpdateScoreUI();
            Destroy(other.gameObject);
        }
        else
        {
            healthBar.TakeDamage(1);
            Destroy(other.gameObject);
        }
    }

    void UpdateScoreUI()
    {
        if (teksScore != null)
        {
            teksScore.text = "Score: " + score.ToString();
        }
    }
}