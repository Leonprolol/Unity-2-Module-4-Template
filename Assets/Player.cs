using UnityEngine;


public class Player : MonoBehaviour
{
    public Animator animator;
    public float deathDelay = 1.5f;

    private bool isAlive = true;

    

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && isAlive)
        {
            isAlive = false;
            this.GetComponent<playermove>().canrun = false;
            this.GetComponent<playermove>().rb.velocity = new Vector2(0,0);
            animator.SetTrigger("Die");
            Invoke("Die", deathDelay);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}