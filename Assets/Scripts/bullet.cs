using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
	private GameObject player;
	void Start() {
		player = GameObject.Find("Player");
		Destroy(gameObject, 3);
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		print("hello");
		if (collision.gameObject.tag == "Enemy")
		{						
			collision.gameObject.GetComponent<Walker>().health = collision.gameObject.GetComponent<Walker>().health - 25;
			if (collision.gameObject.GetComponent<Walker>().health <= 0) {
				Destroy(collision.gameObject);
				player.GetComponent<Player>().coins = player.GetComponent<Player>().coins + 5;
				Destroy(gameObject);
			}
		}  
	}
}
