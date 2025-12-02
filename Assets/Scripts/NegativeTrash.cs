using UnityEngine;

public class NegativeTrash : MonoBehaviour
{
    public int scorePenalty = 1; // score berkurang 1

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().ReduceScore(scorePenalty);
            Destroy(gameObject);
        }
    }
}
