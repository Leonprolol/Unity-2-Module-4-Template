using UnityEngine;

public class BunchOfBeams : MonoBehaviour
{
    public GameObject beamPrefab;
    public int numBeams = 5;
    public float beamSpeed = 5f;
    public float spreadAngle = 45f;

    private void Start()
    {
        Destroy(this, 3f);
        FireBeams();
    }

    private void FireBeams()
    {
        float angleStep = spreadAngle / (numBeams - 1);

        for (int i = 0; i < numBeams; i++)
        {
            // Calculate the rotation for each beam
            Quaternion rotation = Quaternion.Euler(0f, -spreadAngle / 2 + i * angleStep, 0f);

            // Instantiate a beam and set its direction
            GameObject beam = Instantiate(beamPrefab, transform.position, rotation);
            Rigidbody beamRigidbody = beam.GetComponent<Rigidbody>();
            if (beamRigidbody != null)
            {
                Vector3 beamDirection = rotation * Vector3.forward;
                beamRigidbody.velocity = beamDirection * beamSpeed;
            }

            // Optionally, you can add additional behavior to the beams here, such as damage or lifetime.
        }

        // Destroy this object after firing the beams
        Destroy(gameObject);
    }
}
