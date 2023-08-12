using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracking : MonoBehaviour
{
    private GameObject Player;
    public Transform healthbar;
    public float Range = 10f;
    public float MoveSpeed = 5f;
    public bool movingRight = true;
    private Vector3 oldPosition;
    private Rigidbody2D rb;
    public float health = 100;
    public float jumpPower = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        InvokeRepeating("CheckStuck", 5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
         float currentDistance = Mathf.Abs(distance);
        // Flip the character's sprite accordingly
        Vector3 direction = Player.transform.position - transform.position;
        if (direction.x > 0f)
        {
            movingRight = false;
            transform.localScale = new Vector3(0.75f, 0.75f, 1f);
         //   GetComponent<SpriteRenderer>().flipX = false; // Face right (no flip)
        }
        else if (direction.x < 0f)
        {
            transform.localScale = new Vector3(-0.75f, 0.75f, 1f);
            movingRight = true;
         //   GetComponent<SpriteRenderer>().flipX = true; // Face left (flip the sprite horizontally)
        }
        if(distance <= Range){
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, MoveSpeed * Time.deltaTime);
        }
    }

    void CheckStuck(){
        if ((int)transform.position.x == (int)oldPosition.x) {
            rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            print("TRACKING STUCK");
        }
        oldPosition = transform.position;

    }

     SpriteRenderer m_SpriteRenderer;
    void OnTriggerEnter2D(Collider2D collision)
	{
		
		if (collision.gameObject.tag == "Bullet")
		{	
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
