using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;
    private Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Move the bullet forward
        rb.AddForce(transform.forward * 8000);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
