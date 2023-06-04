using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeRespawner : MonoBehaviour
{
    public Vector3 respawnPoint;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        other.transform.position = respawnPoint;
    }
}
