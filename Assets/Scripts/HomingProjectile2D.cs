using UnityEngine;

public class HomingProjectile2D : MonoBehaviour
{
    public Transform target; // The target to home in on (e.g., the player)
    public float homingSpeed = 1f; // The speed at which the projectile homes in on the target
    public float rotationSpeed = 1f; // The speed at which the projectile rotates to face the target
    public float rotateSpeed = 1f;
    public float speed = 1f;
    private Rigidbody2D rb;

    private void Start()
    {
        target = GameObject.Find("Player").transform;
        print(target);
        rb = GetComponent<Rigidbody2D>();
        Destroy(this, 3.5f);
    }

    private void Update()
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;

            // Calculate the angle to rotate towards the target
            /*
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            float rotateAmount = Mathf.MoveTowardsAngle(rb.rotation, angle, rotateSpeed * Time.deltaTime);

            // Apply torque to the missile to rotate it towards the target
         
            rb.angularVelocity = (rotateAmount - rb.rotation) * rotateSpeed;
*/
            // Apply forward force to move the missile forward
            rb.velocity = direction * speed;
        }
        else
        {
            // If the target is null (destroyed or not assigned), destroy the missile
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        print("I've hit something");
        print(other.gameObject.tag);
        if (other.gameObject.tag == "Bullet")
        {
            // Handle what happens when the projectile hits the target (e.g., deal damage)
            // You can add your custom logic here.

            // Destroy the projectile upon hitting the target
            Destroy(gameObject);
        }
        if (other.gameObject.tag != "Enemy" || other.gameObject.tag != "Player"){
            Destroy(gameObject);
        }
        
    }
}