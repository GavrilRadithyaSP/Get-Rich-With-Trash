using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;     // drag the player here in the inspector
    public float speed = 2f;     // movement speed
    public float stopDistance = 1f; // how close before stopping
    public float reduceTimeAmount = 5f; // waktu berkurang 5 detik

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance > stopDistance)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            transform.position += (Vector3)(direction * speed * Time.deltaTime);
            if (direction.x > 0)
                transform.localScale = new Vector3(-1, 1, 1);
            else
                transform.localScale = new Vector3(1, 1, 1);

            if (anim != null)
                anim.SetBool("Walking", true);
        }
        else
        {
            if (anim != null)
                anim.SetBool("Walking", false);
        }
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().ReduceTime(reduceTimeAmount);
        }
    }

}
