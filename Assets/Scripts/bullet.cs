using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
	private GameObject player;
	private bool spread = false;
	private Rigidbody2D rb;
	private GameObject firepoint;

	private float damage = 0f;
	void Start() {
		rb = GetComponent<Rigidbody2D>();
		firepoint = GameObject.Find("firepoint");

		player = GameObject.Find("Player");
		//rb.AddForce(firepoint.transform.forward * 500, ForceMode2D.Impulse);
 		rb.velocity = new Vector2(firepoint.transform.localScale.x, 0)*15;
	}
	public void setDamage(float newDam) {
		damage = newDam;
	}

	public void setSpread() {
		spread = true;
	}
	
	void Update() {
		if (spread){
			//create two new bullets going in diff directions
			spread = false;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		print("hello");
		if (collision.gameObject.tag == "Enemy")
		{	
			print("sussy baka");					
			collision.gameObject.GetComponent<Walker>().health = collision.gameObject.GetComponent<Walker>().health - (int)damage;
			if (collision.gameObject.GetComponent<Walker>().health <= 0) {
				Destroy(collision.gameObject);
				player.GetComponent<playermove>().coins += 5;
			
			}
		}  
			Destroy(gameObject);
	}
}
