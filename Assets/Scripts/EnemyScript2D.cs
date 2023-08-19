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
    public float health = 100;
    public Transform healthbar;

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

    SpriteRenderer m_SpriteRenderer;
    void OnTriggerEnter2D(Collider2D collision)
	{
		
		if (collision.gameObject.tag == "Bullet")
		{	
            print("im dying");
            health = health - collision.gameObject.GetComponent<bullet>().damage;
            if(movingRight){
                healthbar.position = new Vector3(healthbar.position.x-0.5f, healthbar.position.y,healthbar.position.z);
                print("jghuithwruyijh");
            }
            else{
                healthbar.position = new Vector3(healthbar.position.x+0.50f, healthbar.position.y,healthbar.position.z);
                print("gioehgegiuqehgre");
            }
           
            if (health <= 0) {
                player.gameObject.GetComponent<playermove>().coins += 5;

                Destroy(gameObject);
            }
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            //Set the GameObject's Color quickly to a set Color (blue)
            m_SpriteRenderer.color = Color.red;
            StartCoroutine(red());
		}  
        Destroy(collision.gameObject);

	}

    IEnumerator red() {
        yield return new WaitForSeconds(0.25f);
        m_SpriteRenderer.color = Color.white;
    }
}
