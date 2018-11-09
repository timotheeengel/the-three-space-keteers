using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    public int iMaxHealthPerScale;
    public int iScoreValuePerScale;

    public GameObject goFracturedAsteroid;

    private int iCurrentHealth;

    // Use this for initialization
    void Start()
    {
        iCurrentHealth = Mathf.RoundToInt(iMaxHealthPerScale * transform.localScale.x);
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
                MissileExplosion();
            }
        }

        if (collidingGameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Destroyed on Contact with Player");
        }
    }
    private void MissileExplosion()
    {
        GameObject newFracturedAsteroid = Instantiate(goFracturedAsteroid, transform.position, transform.rotation);
        newFracturedAsteroid.transform.localScale = gameObject.transform.localScale;
        ScoreManager.iScore += Mathf.RoundToInt(iScoreValuePerScale * gameObject.transform.localScale.x);
        Destroy(gameObject);
        AsteroidSpawner.iCurrentAsteroidCount--;
    }
}
