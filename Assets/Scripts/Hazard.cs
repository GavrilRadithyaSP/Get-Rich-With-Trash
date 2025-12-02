using UnityEngine;

public class Hazard : MonoBehaviour
{
    public float reduceTimeAmount = 5f; // waktu berkurang 5 detik

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().ReduceTime(reduceTimeAmount);
            Destroy(gameObject);
        }
    }
}
