using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    public int iMaxHealth;
    public int iScoreValue;

    public GameObject goFracturedAsteroid;

    private int iCurrentHealth;

    // Use this for initialization
    void Start()
    {
        iCurrentHealth = iMaxHealth;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AsteroidBoundary"))
        {
            Destroy(gameObject);
            AsteroidSpawner.iCurrentAsteroidCount--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleCollision(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision.gameObject);
    }
    
    private void HandleCollision(GameObject collidingGameObject)
    {
        if(collidingGameObject.CompareTag("Missile"))
        {
            if (iCurrentHealth > 0)
            {
                iCurrentHealth--;
            }
            else
            {
                Destroy(gameObject);
                AsteroidSpawner.iCurrentAsteroidCount--;
            }
        }

        if (collidingGameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            AsteroidSpawner.iCurrentAsteroidCount--;
            Debug.Log("Destroyed on Contact with Player");
        }
    }
    
}
