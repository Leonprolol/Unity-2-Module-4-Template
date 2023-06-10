using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Player : MonoBehaviour
{
   // public Animator animator;
   // public float deathDelay = 1.5f;

    //private bool isAlive = true;
    public TextMeshProUGUI coinText;
    public int coins = 0;

    void Start() {
       // animator = GetComponent<Animator>();
    }

    void Update() {
        coinText.text = coins.ToString();
    }
    
/*
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
        //Destroy(gameObject);
    }
*/
    
}
