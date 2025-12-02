using UnityEngine;

public class Trash : MonoBehaviour
{
    public int scoreValue = 1; // tambah 1 setiap sampah

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
