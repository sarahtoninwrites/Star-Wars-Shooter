using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    private Player player;
    public float speed = 10f;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.GetComponent<Player>();
        }
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime); // or use direction if needed
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player hit!");
            if (player != null)
            {
                player.takeDamage();
            }
            Destroy(gameObject); // 💥 Bullet disappears too
        }
    }
}
