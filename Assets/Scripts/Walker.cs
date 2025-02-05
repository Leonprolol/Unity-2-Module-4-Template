using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Walker : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 5f;
    private GameObject Player;
    private Vector3 startPosition;
    private bool movingRight = true;
    
    public float health = 100;
    public Transform healthbar;
    

    void Start()
    {
        Player = GameObject.Find("Player");

        startPosition = transform.position;
    }

    void Update()
    {
        // Move in the current direction
        Vector3 direction = movingRight ? Vector3.right : Vector3.left;
        transform.Translate(direction * speed * Time.deltaTime);

        // Check if we need to turn around
        float currentDistance = Mathf.Abs(transform.position.x - startPosition.x);
        if (currentDistance >= distance)
        {
            movingRight = !movingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            healthbar.localScale = new Vector3(-healthbar.localScale.x, healthbar.localScale.y, healthbar.localScale.z);
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
