using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
	private GameObject player;
	private bool spread = false;
	private Rigidbody2D rb;
	private GameObject firepoint;
	

	public float damage = 0f;
	void Start() {
		rb = GetComponent<Rigidbody2D>();
		firepoint = GameObject.Find("firepoint");
	

		player = GameObject.Find("Player");
		
 		//rb.velocity = new Vector2(firepoint.transform.forward.x, 0)*500;

	}
	public void setDamage(float newDam) {
		damage = newDam;
	}

	 private void Update()
	    {
		// Destroy the bullet when it's out of bounds
		if (!GetComponent<Renderer>().isVisible)
		{
		    Destroy(gameObject);
		}
	    }

	public void setSpread() {
		spread = true;
	}

	public void fire(Vector3 direction){
		GetComponent<Rigidbody2D>().velocity = direction.normalized *50;
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		Destroy(gameObject);
	}
	
}
