using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections; 


public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private InputActionReference moveActionToUse;
    [SerializeField] private float speed = 5f;

    [Header("Rotation Settings")]
    [SerializeField] private InputActionReference lookActionToUse;
    [SerializeField] private float rotationSpeed = 100f;
    private float currentZRotation = 0f;



    [Header("Shooting Settings")]
   // [SerializeField] private InputActionReference fireAction; // your "Fire" button
    [SerializeField] private GameObject projectilePrefab;     // assign in inspector
    [SerializeField] private Transform firePoint;             // where the bullet comes out
    [SerializeField] private float projectileSpeed = 10f;


    public GameObject pausePanel, leftStick, fireButton;
    public Button pauseButton, playButton;    
    private SpriteRenderer spriteRenderer;
    public AudioSource audioSource;
    public AudioClip fireSound;



void Start(){
        pausePanel.gameObject.SetActive(false);

        spriteRenderer = GetComponent<SpriteRenderer>();

}


    void Update()
    {
        // Movement
        Vector2 moveDirection = moveActionToUse.action.ReadValue<Vector2>();
        Vector3 movement = new Vector3(moveDirection.x, moveDirection.y, 0f);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // Rotation (Z only)
        Vector2 lookDirection = lookActionToUse.action.ReadValue<Vector2>();
        currentZRotation += lookDirection.x * rotationSpeed * Time.deltaTime;

        // Apply only Z rotation, lock X and Y
        transform.rotation = Quaternion.Euler(0f, 0f, currentZRotation);
    }

        void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Player hit!");
            takeDamage();
        }
    }

    public void takeDamage(){

        StartCoroutine(FlashRed());

    }
private IEnumerator FlashRed()
{
    spriteRenderer.color = Color.red; // Change color to red
    yield return new WaitForSeconds(0.5f); // Wait for 1 second
    spriteRenderer.color = Color.white; // Change color back to normal
}

    public void Fire()
    {
    if (projectilePrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            audioSource.clip = fireSound;
            audioSource.Play();
            if (rb != null)
            {
                rb.linearVelocity = firePoint.up * projectileSpeed;
            }
            Destroy(bullet, 3f);

        }
    }

    public void Pause()
{
    Debug.Log("pause");
    pauseButton.gameObject.SetActive(false);
    playButton.gameObject.SetActive(true);
    pausePanel.SetActive(true);
}

public void Unpause(){
    Debug.Log("unpause");
    pauseButton.gameObject.SetActive(true);
    playButton.gameObject.SetActive(false);

    pausePanel.SetActive(false);
}

}
