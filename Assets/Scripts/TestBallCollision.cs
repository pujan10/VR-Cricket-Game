using UnityEngine;

public class TestBallCollision : MonoBehaviour
{
    public Rigidbody ballRigidbody;
    public float forceAmount = 500f;
    public Vector3 direction = Vector3.forward;

    void Start()
    {
        // Apply force to the ball in the specified direction
        ballRigidbody.AddForce(direction * forceAmount);
    }
}
