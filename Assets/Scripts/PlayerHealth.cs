using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 5;       // Number of hearts
    public int currentHealth;

    [Header("UI")]
    public Transform heartsPanel;   // Drag your HeartsPanel here
    public GameObject heartPrefab;  // A prefab with an Image component

    private List<Image> hearts = new List<Image>();

    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Start()
    {
        currentHealth = maxHealth;
        CreateHearts();
        UpdateHearts();
    }

    void CreateHearts()
    {
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject newHeart = Instantiate(heartPrefab, heartsPanel);
            Image heartImage = newHeart.GetComponent<Image>();
            hearts.Add(heartImage);
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < currentHealth)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHearts();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHearts();
    }

    private void Die()
    {
        Debug.Log("Player Died!");
    }
}
