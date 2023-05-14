using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifer : MonoBehaviour
{
	private GameObject player;
	public int pos = 0;
	void Start() {
		player = GameObject.Find("Player");
		
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		print("hello");
		if (collision.gameObject.tag == "Enemy")
		{	
			print("sussy baka");					
			collision.gameObject.GetComponent<Walker>().health = collision.gameObject.GetComponent<Walker>().health - 25;
			if (collision.gameObject.GetComponent<Walker>().health <= 0) {
				Destroy(collision.gameObject);
				player.GetComponent<Player>().coins = player.GetComponent<Player>().coins + 5;
			
			}
		}  
			
	}
	public void changePosition() {
		transform.position = new Vector3(0,0,0);
	}
	void Update(){
		print("hi");
		print(pos);
		if (pos == 1) {
			transform.position = new Vector3(-0.12f, 0.07f, -0.03f);
			transform.rotation = new Quaternion(-3.504f, 1.463f, -89.31f, 1);
		}
		else {
			
		}
	}
}
