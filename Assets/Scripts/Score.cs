using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    public GameObject objekScore; // Drag TextMeshPro UI object here
    private TextMeshProUGUI teksScore;

    private void Start()
    {
        teksScore = objekScore.GetComponent<TextMeshProUGUI>();
        UpdateScoreUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PREMAN")) // Enemy tag
        {
            score -= 10;
            UpdateScoreUI();
        }
        else if (other.CompareTag("SAMPAH")) // Pickup tag
        {
            score += 10;
            UpdateScoreUI();
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
