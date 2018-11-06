using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidShardDestruction : MonoBehaviour {
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Missile")||
            other.gameObject.CompareTag("Asteroid") ||
            other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
