using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    public GameObject objekScore; // drag TextMeshPro UI object ke sini di Inspector
    private TextMeshProUGUI teksScore;

    public int maxHealth = 3;
    public int currentHealth;
    public HealthBar healthBar; // drag HealthBar script object ke sini di Inspector

    void Start()
    {
        teksScore = objekScore.GetComponent<TextMeshProUGUI>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        // Tampilkan skor awal
        UpdateScoreUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PREMAN"))
        {
            score -= 10;
            UpdateScoreUI();
            TakeDamage(1);
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
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void UpdateScoreUI()
    {
        if (teksScore != null)
        {
            teksScore.text = "Score: " + score.ToString();
        }
    }
}