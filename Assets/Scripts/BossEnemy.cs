using System.Collections;
using UnityEngine;
using System.Collections.Generic;


public class BossEnemy : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float moveSpeed = 5f;
    public float lowerBound;
    public float attackRange = 10f; // The range at which the boss can attack
    public float upperBound; 
    public GameObject slowBeamPrefab;
    public GameObject bunchOfBeamsPrefab;
    public Transform SlowBeamFirepoint;
    public Transform BunchofBeamsFirepoint;
    public Rigidbody2D rb;
    
    private enum AttackPattern
    {
        None,
        SlowBeamAttack,
        BunchOfBeamsAttack,
        Move
    }
    
    private AttackPattern currentAttack = AttackPattern.BunchOfBeamsAttack;
    private bool isAttacking = false;
    private List<Vector3> storedPositions = new List<Vector3>();


    private void Start()
    {
        StartCoroutine(AttackLoop());
        playerPos =  player.transform.position;
        startPosition = transform.position;
    }

    private IEnumerator AttackLoop()
    {
        while (true)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= attackRange && !isAttacking)
            {
                currentAttack = (AttackPattern)Random.Range(1, 4);
                StartCoroutine(ExecuteAttack());
            }

            yield return new WaitForSeconds(Random.Range(lowerBound, upperBound)); // Time between attacks
        }
    }


    public float speed = 20f;
    public float distance = 5f;

    private Vector3 startPosition;
    private bool movingRight = true;
    
    public float health = 100;
    public Transform healthbar;
    public bool isMoving = false;
    public bool isShooting = false;
    public float slowBeamSpeed;
    Vector3 playerPos;
        public int followDistance = 90;

    void Update()
    {
        if (isMoving) {
                 Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
                transform.Translate(directionToPlayer * speed * Time.deltaTime);
        }
       if(isShooting) {
            GameObject slowBeam = Instantiate(slowBeamPrefab, SlowBeamFirepoint.position, Quaternion.identity);
            Strech(slowBeam, SlowBeamFirepoint.position, playerPos, false);
        }
        storedPositions.Add(player.transform.position); //store the position every frame
     
        if(storedPositions.Count > followDistance)
        {
            playerPos = storedPositions[0]; //move the player
            storedPositions.RemoveAt (0); //delete the position that player just move to
        }
   
    }

   


	public void Strech(GameObject _sprite,Vector3 _initialPosition, Vector3 _finalPosition, bool _mirrorZ) {
		Vector3 centerPos = (_initialPosition + _finalPosition) / 2f;
		_sprite.transform.position = centerPos;
		Vector3 direction = _finalPosition - _initialPosition;
		direction = Vector3.Normalize(direction);
		_sprite.transform.right = direction;
		if (_mirrorZ) _sprite.transform.right *= -1f;
		Vector3 scale = new Vector3(1,1,1);
		scale.x = Vector3.Distance(_initialPosition, _finalPosition);
        _sprite.GetComponent<PolygonCollider2D>().points[0] = new Vector2(_initialPosition.x, _initialPosition.y);
        _sprite.GetComponent<PolygonCollider2D>().points[1] = new Vector2(_finalPosition.x, _finalPosition.y);

		_sprite.transform.localScale = scale;
	}

    private IEnumerator ExecuteAttack()
    {
        isAttacking = true;

        switch (currentAttack)
        {
           
            case AttackPattern.SlowBeamAttack:
                print("preforming A SlowbeamAttac");
                isShooting = true;
                //SlowBeamAttack();
                yield return new WaitForSeconds(5f); // Time to complete attack
                isShooting = false;
                break;
                
            case AttackPattern.BunchOfBeamsAttack:        
                StartCoroutine(BunchOfBeamsAttack());
                yield return new WaitForSeconds(5f);
                break;
            case AttackPattern.Move:    
                isMoving=true;
                yield return new WaitForSeconds(1f); // Time to complete attack
                isMoving = false;
                break;
            case AttackPattern.None:
                print("preforming A None");
                break;
                
        }

        yield return new WaitForSeconds(3f); // Time to complete attack
        isAttacking = false;
        currentAttack = AttackPattern.None;
    }

    public void Move()
    {
       
        // Move in the current direction
       
    }

 

    private void SlowBeamAttack()
    {
        print("I am preforming a Slow Beam Attack");
        GameObject slowBeam = Instantiate(slowBeamPrefab, SlowBeamFirepoint.position, Quaternion.identity);
        SlowBeamController beamController = slowBeam.GetComponent<SlowBeamController>();
        beamController.SetTarget(player);
    }

    private IEnumerator BunchOfBeamsAttack()
    {
        print("I am preforming a Bunch of Beams Attack");

        int numBeams = 5;
        float angleStep = 360f / numBeams;

        for (int i = 0; i < numBeams; i++)
        {
            Quaternion rotation = Quaternion.Euler(0f, i * angleStep, 0f);
            GameObject x = Instantiate(bunchOfBeamsPrefab, BunchofBeamsFirepoint.position, Quaternion.identity);
            x.GetComponent<HomingProjectile2D>().speed = (i + 1) * 2;
            yield return new WaitForSeconds(1f);
            
        }
    }
}
