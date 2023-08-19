using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10f;
   // public float lifetime = 2f;
    private Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Calculate the forward direction based on the current rotation
        Vector2 forwardDirection = transform.right.normalized;

        // Apply velocity to move the bullet in its forward direction
        rb.velocity = forwardDirection * speed;

        //Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Move the bullet forward
       // rb.AddForce(transform.forward * 8000);
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
