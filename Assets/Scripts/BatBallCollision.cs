using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBallCollision : MonoBehaviour
{
    public float forceAmount = 50f;
    public AudioSource batHitSound;  // Assign this in the Inspector
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name + " | Tag: " + collision.gameObject.tag);

        // Check if the ball hit the bat
        if (collision.gameObject.CompareTag("Ball"))
        {
            batHitSound.Play();
            Debug.Log("Ball hit by bat!");
            Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRigidbody != null)
            {
                Vector3 batVelocity = GetComponent<Rigidbody>().velocity;
                Vector3 hitDirection = batVelocity.normalized;
                float hitForce = batVelocity.magnitude * forceAmount;

                // Apply force based on bat's speed and direction
                ballRigidbody.AddForce(hitDirection * hitForce);
            }
        }

    }
}
