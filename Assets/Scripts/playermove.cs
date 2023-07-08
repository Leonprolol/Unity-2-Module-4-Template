 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public GameObject shop;
    private bool shopOn = false;
    
    public int coins = 10;
    public TextMeshProUGUI coinText;


    public List<string> weapons;
    /*

    here i am giving you the solution , First make an empty game object , 
    then add the player sprite as a child .
Add all the rigidbodies and the Box colliders to the empty game object .
Also add the player control script to the empty game object
now run the animation , will solve your problem
*/
    // Start is called before the first frame update
    void Start()
    {
        weapons.Add("Pistol");
        shop.SetActive(shopOn);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if  (canrun == true){
            if (Input.GetKeyDown(KeyCode.Q)) {
                shopOn = !shopOn;
                Cursor.visible = shopOn;
                shop.SetActive(shopOn);
            }
            moveDirection = Input.GetAxis("Horizontal");
            if (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.LeftArrow) ) {
        
                transform.GetChild(0).localScale = new Vector3(-0.75f, 0.75f, 1f);
            }
            else if(Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.RightArrow)){
                transform.GetChild(0).localScale = new Vector3(0.75f, 0.75f, 1f);
            }
            if (moveDirection > 0.4 || moveDirection < -0.4) {
                a.SetBool("is running", true);
            }
            else
            {
                a.SetBool("is running", false);
            }
            Vector2 movement = new Vector2(moveDirection * 6, rb.velocity.y);
            rb.velocity = movement;
        
            if (Input.GetKeyDown(KeyCode.Space)&& onGround == true && jumped == false)
            {
                rb.AddForce(new Vector2(0f,100f));
               //  a.SetBool("is jumping", true); //NEEds to be 30 frames half a second
                StartCoroutine(jumpCool());
             }
             
            }
            Falling();
            coinText.text = "Coins " + coins.ToString();
      
     }              


    void Falling()
    {
        //GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask.GetMask("Ground"))
        if (onGround) {
            a.SetBool("is jumping", false);
            a.SetBool("is falling", false);
            return;
        }
        else {
            a.SetBool("is running", false);
        }
        //bool playerHasVerticalSpeed = Math.Abs(playerRigidbody.velocity.y) > Mathf.Epsilon;
        if (rb.velocity.y >= 0)
        {
            //a.SetBool("isJumping", playerHasVerticalSpeed);
            a.SetBool("is jumping", false);
            a.SetBool("is jumping", true);
           
        } else
        {
            a.SetBool("is jumping", false);
            a.SetBool("is falling", true);
            //.SetBool("isLanding", playerHasVerticalSpeed); 
        }   
        
    }                                                          

    IEnumerator jumpCool() {
         jumped = true;
        yield return new WaitForSeconds(0.25f);
        jumped = false;
        //yield return new WaitForSeconds(0.5f); //half a second
        //call idle a.s
    }

    private void OnCollisionEnter2D(Collision2D col) {
        
    }

    private void OnCollisionStay2D(Collision2D col) {
       
    }

    private void OnCollisionExit2D(Collision2D col) {
    
    }

    private void OnTriggerEnter2D(Collider2D col) {
        print("Hello");
        if (col.gameObject.tag == "Ground") 
        {
            onGround = true;
        }
    }

    private void OnTriggerStay2D(Collider2D col) {
        print("Hello");
        if (col.gameObject.tag == "Ground") 
        {
            onGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        print("GOODBYEZ");
    if (col.gameObject.tag == "Ground") 
        {
            onGround = false;
        }
    }


}

