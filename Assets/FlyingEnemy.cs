using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour

{
    public float speed = 5f;
    public float detectionRange = 10f;
    public float health = 15;

    private Transform player;
    private bool isChasing = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            isChasing = true;
            MoveTowards(player.position);
        }
        else
        {
            isChasing = false;
        }

        if (isChasing)
        {
            // Move the enemy forward
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            // Add animation and sound effects here
        }

        // Add collision detection with player's projectiles or other game elements

        // Check if the enemy is out of bounds, and handle accordingly
        if (IsOutOfBound())
        {
            Destroy(gameObject); // Remove the enemy from the game
        }
    }

    private void MoveTowards(Vector2 targetPosition)
    {
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
    }

    private bool IsOutOfBound()
    {
        // Implement your out-of-bounds check logic here
        return false;
    }
    SpriteRenderer m_SpriteRenderer;
    void OnTriggerEnter2D(Collider2D collision)
	{
		
		if (collision.gameObject.tag == "Bullet")
		{	
            health = health - collision.gameObject.GetComponent<bullet>().damage;
            /*
            if(movingRight){
                healthbar.position = new Vector3(healthbar.position.x-0.5f, healthbar.position.y,healthbar.position.z);
                print("jghuithwruyijh");
            }
            else{
                healthbar.position = new Vector3(healthbar.position.x+0.50f, healthbar.position.y,healthbar.position.z);
                print("gioehgegiuqehgre");
            }
            */
            if (health <= 0) {
                Player.GetComponent<playermove>().coins += 5;
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

