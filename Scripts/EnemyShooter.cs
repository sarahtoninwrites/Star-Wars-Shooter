using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    private Transform player; // Assign player in the Inspector or find in Start()
    public float shootInterval = 2f;
    public float detectionRange = 10f;
    public float bulletSpeed = 5f;
    private float shootTimer;


void Start(){
   GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
    if (playerObj != null)
    {
        player = playerObj.transform;
    }
}
    void Update()
    {
        if (player == null) {
          Debug.Log("no player?");
        return;
        }

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootInterval)
            {
                Shoot();
                shootTimer = 0f;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null && player != null)
        {
            Vector2 direction = (player.position - firePoint.position).normalized;
            rb.linearVelocity = direction * bulletSpeed;
        }

        Destroy(bullet, 3f); // Auto-cleanup
    }
}
