using UnityEngine;

public class HomingProjectile : MonoBehaviour
{
    private Transform target; // The target to home in on (e.g., the player)
    public float homingSpeed = 5f; // The speed at which the projectile homes in on the target
    public float rotationSpeed = 200f; // The speed at which the projectile rotates to face the target
    void Start() {
        target = GameObject.Find("Player");
    }
    private void Update()
    {
        if (target == null)
        {
            // If the target is lost or destroyed, just move forward
            transform.Translate(Vector2.up * homingSpeed * Time.deltaTime);
            return;
        }

        // Calculate the direction to the target
        Vector2 directionToTarget = (target.position - transform.position).normalized;

        // Calculate the angle to rotate towards the target
        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

        // Rotate the projectile towards the target
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Move the projectile forward in the direction of the target
        transform.Translate(Vector2.up * homingSpeed * Time.deltaTime);
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
        Destroy(gameObject);

    }
}
