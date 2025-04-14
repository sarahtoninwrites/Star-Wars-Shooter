using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime); // Adjust axis if needed
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit!");
            Destroy(collision.gameObject); // 💀 Enemy dies
          //  Destroy(gameObject); // 💥 Bullet disappears too
        }
    }
}
