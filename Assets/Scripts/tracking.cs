using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracking : MonoBehaviour
{
    private GameObject Player;
    public float Range = 10f;
    public float MoveSpeed = 5f;
    private Vector3 oldPosition;
    private Rigidbody2D rb;
    public float jumpPower = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        InvokeRepeating("CheckStuck", 0.0f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if(distance <= Range){
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, MoveSpeed * Time.deltaTime);
            oldPosition = transform.position;
        }
    }

    void CheckStuck(){
        if ((int)transform.position.x == (int)oldPosition.x) {
            rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        }
    }
}
