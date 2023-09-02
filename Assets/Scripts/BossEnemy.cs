using System.Collections;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float moveSpeed = 5f;
    public float lowerBound;
    public float upperBound; 
    public GameObject slowBeamPrefab;
    public GameObject bunchOfBeamsPrefab;
    public Transform SlowBeamFirepoint;
    public Transform BunchofBeamsFirepoint;
    
    private enum AttackPattern
    {
        None,
        RunAttack,
        SlowBeamAttack,
        BunchOfBeamsAttack
    }
    
    private AttackPattern currentAttack = AttackPattern.None;
    private bool isAttacking = false;

    private void Start()
    {
        StartCoroutine(AttackLoop());
    }

    private IEnumerator AttackLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(lowerBound, upperBound)); // Time between attacks
            if (!isAttacking)
            {
                currentAttack = (AttackPattern)Random.Range(1, 4);
                StartCoroutine(ExecuteAttack());
            }
        }
    }

    private IEnumerator ExecuteAttack()
    {
        isAttacking = true;

        switch (currentAttack)
        {
            case AttackPattern.RunAttack:
                RunAttack();
                break;
            case AttackPattern.SlowBeamAttack:
                SlowBeamAttack();
                break;
            case AttackPattern.BunchOfBeamsAttack:
                BunchOfBeamsAttack();
                break;
        }

        yield return new WaitForSeconds(3f); // Time to complete attack
        isAttacking = false;
        currentAttack = AttackPattern.None;
    }

    private void RunAttack()
    {
        print("I am preforming a Running Attack");
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime);
    }

    private void SlowBeamAttack()
    {
        print("I am preforming a Slow Beam Attack");
        GameObject slowBeam = Instantiate(slowBeamPrefab, SlowBeamFirepoint.position, Quaternion.identity);
        SlowBeamController beamController = slowBeam.GetComponent<SlowBeamController>();
        beamController.SetTarget(player);
    }

    private void BunchOfBeamsAttack()
    {
        print("I am preforming a Bunch of Beams Attack");

        int numBeams = 5;
        float angleStep = 360f / numBeams;

        for (int i = 0; i < numBeams; i++)
        {
            Quaternion rotation = Quaternion.Euler(0f, i * angleStep, 0f);
            Instantiate(bunchOfBeamsPrefab, BunchofBeamsFirepoint.position, rotation);
        }
    }
}
