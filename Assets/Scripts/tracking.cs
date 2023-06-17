using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracking : MonoBehaviour
{
    private GameObject Player;
    public float Range = 10f;
    public float MoveSpeed = 5f;
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
