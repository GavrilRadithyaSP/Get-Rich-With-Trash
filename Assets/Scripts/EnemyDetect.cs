using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    private EnemyChase enemy;

    void Start()
    {
        enemy = GetComponentInParent<EnemyChase>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.StartChase();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.StopChase();
        }
    }
}
