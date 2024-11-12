using UnityEngine;

public class OutDetection : MonoBehaviour
{
    public GameManager gameManager;
    public AudioSource stumpHitSound;  // Assign this in the Inspector
    void Start()
    {
        // Try to find GameManager if not assigned in Inspector
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
            if (gameManager == null)
            {
                Debug.LogError("GameManager not found! Make sure it’s in the scene.");
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Ball"))
        {
            stumpHitSound.Play();
            Debug.Log("Ball hit the stumps - Game Over!");
            gameManager.GameOver();
        }
    }
}
