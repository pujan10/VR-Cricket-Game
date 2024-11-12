using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDelivery : MonoBehaviour
{
    public GameObject ballPrefab;           // Prefab of the ball
    public Transform bowlingMachine;        // Reference to the bowling machine position

    public float minSpeed = 30f;            // Minimum ball speed
    public float maxSpeed = 50f;            // Maximum ball speed

    public float minXOffset = -1f;          // Minimum X-axis deviation for the ball
    public float maxXOffset = 1f;           // Maximum X-axis deviation for the ball

    public float deliveryInterval = 6f;     // Time interval between ball deliveries
    private float deliverySpeed;
    private Vector3 deliveryDirection;

    private GameObject currentBall;         // Reference to the currently active ball

    void Start()
    {
        // Start the ball delivery after 5 seconds and keep repeating every 'deliveryInterval' seconds
        InvokeRepeating("DeliverBall", 5f, deliveryInterval);
    }

    void DeliverBall()
    {
        // Randomize ball speed
        deliverySpeed = Random.Range(minSpeed, maxSpeed);

        // Randomize X offset (left or right deviation)
        float xOffset = Random.Range(minXOffset, maxXOffset);
        deliveryDirection = new Vector3(xOffset, 0, 1); // Move the ball towards the player with random X offset

        // Instantiate a new ball at the position of the bowling machine
        currentBall = Instantiate(ballPrefab, bowlingMachine.position, Quaternion.identity);

        // Get the Rigidbody of the ball and apply random speed and direction
        Rigidbody ballRigidbody = currentBall.GetComponent<Rigidbody>();

        // Set the ball's initial position based on the bowling machine's position and random offset
        currentBall.transform.position = new Vector3(bowlingMachine.position.x + xOffset,
                                                     bowlingMachine.position.y,
                                                     bowlingMachine.position.z);

        // Launch the ball with the random speed in the forward direction (Z-axis) and random X offset
        ballRigidbody.velocity = deliveryDirection * deliverySpeed;
    }
}
