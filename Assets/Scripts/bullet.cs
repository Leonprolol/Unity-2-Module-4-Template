using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{						
			collision.gameObject.GetComponent<Walker>().health = collision.gameObject.GetComponent<Walker>().health - 10;
			if (collision.gameObject.GetComponent<Walker>().health <= 0) {
				Destroy(collision.gameObject);
			}
		}  
	}
}
