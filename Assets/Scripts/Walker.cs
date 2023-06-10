using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Walker : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 5f;

    private Vector3 startPosition;
    private bool movingRight = true;
    
    public int health = 100;

    

    void Start()
    {
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
        }
    }
    SpriteRenderer m_SpriteRenderer;
    void OnCollisionEnter2D(Collision2D collision)
	{
		
		if (collision.gameObject.tag == "Bullet")
		{	
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            //Set the GameObject's Color quickly to a set Color (blue)
            m_SpriteRenderer.color = Color.red;
            StartCoroutine(red());
		}  
	}

    IEnumerator red() {
        yield return new WaitForSeconds(0.25f);
        m_SpriteRenderer.color = Color.white;
    }
}
