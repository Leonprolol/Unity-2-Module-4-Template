using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
	private GameObject player;
	private bool spread = false;
	private Rigidbody2D rb;

	private float damage = 0f;
	void Start() {
    	rb.AddForce(transform.up * 1000, ForceMode2D.Impulse);

		player = GameObject.Find("Player");
		
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
				player.GetComponent<Player>().coins = player.GetComponent<Player>().coins + 5;
			
			}
		}  
			//Destroy(gameObject);
	}
}
