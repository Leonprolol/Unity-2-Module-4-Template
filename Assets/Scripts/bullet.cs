using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
	private GameObject player;
	private bool spread = false;
	private Rigidbody2D rb;
	private GameObject firepoint;
	public Vector3 directions;

	public float damage = 0f;
	void Start() {
		rb = GetComponent<Rigidbody2D>();
		firepoint = GameObject.Find("firepoint");
		print(directions);

		player = GameObject.Find("Player");
		
 		//rb.velocity = new Vector2(firepoint.transform.forward.x, 0)*500;

	}
	public void setDamage(float newDam) {
		damage = newDam;
	}

	public void setSpread() {
		spread = true;
	}
	
	void Update() {
		rb.AddForce(directions.normalized * 10, ForceMode2D.Impulse);
		
		if (spread){
			//create two new bullets going in diff directions
			spread = false;
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		Destroy(gameObject);
	}
	
}
