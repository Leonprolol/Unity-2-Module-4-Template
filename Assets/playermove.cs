 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    private float moveDirection;
    public Rigidbody2D rb;
    
    private bool facingRight = true;
    private bool isJumping = false;
    public bool onGround = true;
    private bool jumped = false;
    public Animator a;
    public bool canrun = true;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        a = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if  (canrun == true){
            moveDirection = Input.GetAxis("Horizontal");
            if (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.LeftArrow) ) {

            print(transform.localScale.x);
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }
            else if(Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.RightArrow)){
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
            if (moveDirection != 0) {
                a.SetBool("is running", true);
            }
            else
            {
                a.SetBool("is running", false);
            }
            Vector2 movement = new Vector2(moveDirection * 6, rb.velocity.y);
            rb.velocity = movement;
            print(onGround);
            if (Input.GetKeyDown(KeyCode.Space)&& onGround == true && jumped == false)
            {
                rb.AddForce(new Vector2(0f,100f));
                 a.SetBool("is jumping", true); //NEEds to be 30 frames half a second
            }
                StartCoroutine(jumpCool());
            }
     }                                                                        

    IEnumerator jumpCool() {
         jumped = true;
        yield return new WaitForSeconds(0.5f);
        a.SetBool("is falling", true);
        jumped = false;
        //yield return new WaitForSeconds(0.5f); //half a second
        //call idle a.s
    }
    private void OnCollisionStay2D(Collision2D col) {
        if (col.gameObject.tag == "Ground") 
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col) {
    if (col.gameObject.tag == "Ground") 
        {
            onGround = false;
        }
    }
}

