using UnityEngine;

public class RunDetection : MonoBehaviour
{
    public int runValue = 1;  // Set run value (1, 4, 6, etc.)
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            // Add runs when the ball enters the trigger
            gameManager.AddScore(runValue);
        }
    }
}
