using UnityEngine;

public class HomingProjectile : MonoBehaviour
{
    public Transform target; // The target to home in on (e.g., the player)
    public float homingSpeed = 5f; // The speed at which the projectile homes in on the target
    public float rotationSpeed = 5f; // The speed at which the projectile rotates to face the target

    private void Update()
    {
        if (target == null)
        {
            // If the target is lost or destroyed, just move forward
            transform.Translate(Vector3.forward * homingSpeed * Time.deltaTime);
            return;
        }

        // Calculate the direction to the target
        Vector3 directionToTarget = (target.position - transform.position).normalized;

        // Rotate the projectile towards the target
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Move the projectile forward in the direction of the target
        transform.Translate(Vector3.forward * homingSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
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
