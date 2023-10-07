using UnityEngine;

public class SlowBeamController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public int damageAmount = 20;

    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            transform.Translate(directionToTarget * moveSpeed * Time.deltaTime);
        }
        else
        {
            // If target is lost or destroyed, destroy the beam
            Destroy(gameObject);
        }
    }


}
