using System.Collections;
using UnityEngine;

public class EnemyScript2D : MonoBehaviour
{
    public Transform player;
    public float trackingSpeed = 3f;
    public float shootingCooldown = 2f;
    public float detectionRange = 10f; // The range at which the enemy detects the player
    public GameObject bulletPrefab;
    public Transform shootPoint;

    private float timeSinceLastShot;

    private void Start()
    {
        timeSinceLastShot = shootingCooldown; // Start with cooldown expired to shoot immediately
    }

    private void Update()
    {
        // Check if the player is within detection range
        if (player != null && Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            // Calculate direction to the player
            Vector2 directionToPlayer = player.position - transform.position;

            // Rotate towards the player
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, trackingSpeed * Time.deltaTime);

            // Check if it's time to shoot
            timeSinceLastShot += Time.deltaTime;
            if (timeSinceLastShot >= shootingCooldown)
            {
                Shoot();
                timeSinceLastShot = 0f;
            }
        }
    }

    private void Shoot()
    {
        if (bulletPrefab != null && shootPoint != null)
        {
            // Instantiate the bullet prefab and set its position and rotation
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            // Add any additional logic to configure the bullet's behavior here
        }
    }
}
