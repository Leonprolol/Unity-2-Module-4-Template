using UnityEngine;

public class HomingProjectile2D : MonoBehaviour
{
    public Transform target; // The target to home in on (e.g., the player)
    public float homingSpeed = 5f; // The speed at which the projectile homes in on the target
    public float rotationSpeed = 200f; // The speed at which the projectile rotates to face the target

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * homingSpeed; // Set the initial velocity in the forward direction.
    }

    private void Update()
    {
        if (target == null)
        {
            return; // No target to home in on, so no further action needed.
        }

        // Calculate the direction to the target
        Vector2 directionToTarget = (target.position - transform.position).normalized;

        // Calculate the angle to rotate towards the target
        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

        // Rotate the projectile towards the target
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime));

        // Continue moving the projectile forward
        rb.velocity = transform.up * homingSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == target.gameObject)
        {
            // Handle what happens when the projectile hits the target (e.g., deal damage)
            // You can add your custom logic here.

            // Destroy the projectile upon hitting the target
            Destroy(gameObject);
        }
    }
}