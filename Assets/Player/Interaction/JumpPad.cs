using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float boostForce = 15f;          // Upward force to boost the player
    public float horizontalBoostFactor = 5f; // Horizontal factor for forward launch

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Determine the direction of approach based on relative velocity
                float approachDirection = Mathf.Sign(collision.relativeVelocity.x);

                // Apply an upward and forward horizontal force based on approach direction
                Vector2 boostVelocity = new Vector2(approachDirection * horizontalBoostFactor, boostForce);
                rb.velocity = boostVelocity;
            }
        }
    }
}
