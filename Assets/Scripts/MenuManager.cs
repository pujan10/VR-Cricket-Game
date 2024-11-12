using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject readyText;
    public GameObject playButton;
    public GameObject spinButton;
    public GameObject fastButton;

    public GameObject ballPrefab;
    public Transform ballSpawner;

    private float deliveryInterval = 5f;
    private bool isDelivering = false;

    // Randomization parameters
    public float minSpeed = 100f;  // Minimum ball force
    public float maxSpeed = 200f;  // Maximum ball force
    public float xOffsetRange = 1f;  // Range for random X position offsets

    private void Start()
    {
        ShowReadyMenu();
    }

    public void ShowReadyMenu()
    {
        readyText.SetActive(true);
        playButton.SetActive(true);
        spinButton.SetActive(false);
        fastButton.SetActive(false);
    }

    public void OnPlayButtonClicked()
    {
        readyText.SetActive(false);
        playButton.SetActive(false);
        spinButton.SetActive(true);
        fastButton.SetActive(true);
    }

    public void OnSpinButtonClicked()
    {
        StartBallDelivery("Spin");
        HideMenu();
    }

    public void OnFastButtonClicked()
    {
        StartBallDelivery("Fast");
        HideMenu();
    }

    private void HideMenu()
    {
        spinButton.SetActive(false);
        fastButton.SetActive(false);
    }

    private void StartBallDelivery(string type)
    {
        Debug.Log("Ball Delivery Type: " + type);
        isDelivering = true;
        InvokeRepeating("DeliverBall", 6f, deliveryInterval);
    }

    private void DeliverBall()
    {
        if (!isDelivering) return;

        // Instantiate the ball
        GameObject ball = Instantiate(ballPrefab, ballSpawner.position, ballSpawner.rotation);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        // Apply random X offset to simulate different delivery angles
        float xOffset = Random.Range(-xOffsetRange, xOffsetRange);
        Vector3 randomSpawnPosition = ballSpawner.position + new Vector3(xOffset, 0, 0);
        ball.transform.position = randomSpawnPosition;

        // Randomize the speed of the ball
        float forceMagnitude = Random.Range(minSpeed, maxSpeed);

        // Apply force to the ball in the forward direction with random speed
        Vector3 forceDirection = ballSpawner.forward;
        rb.AddForce(forceDirection * forceMagnitude);
    }

    public void StopBallDelivery()
    {
        isDelivering = false;
        CancelInvoke("DeliverBall");
    }
}
