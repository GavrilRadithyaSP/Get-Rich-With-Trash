using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    [SerializeField] public int currentHealth;

    [Header("Config")]
    [SerializeField] private Image healthbar;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {

        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }

    public void UpdatePlayerUI()
    {
        healthbar.fillAmount = Mathf.Lerp(healthbar.fillAmount, currentHealth / maxHealth, 10f * Time.deltaTime);
    }
}