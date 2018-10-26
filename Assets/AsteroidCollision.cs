﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    public int iMaxHealth;

    private int iCurrentHealth;

    // Use this for initialization
    void Start()
    {
        iCurrentHealth = iMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AsteroidBoundary"))
        {
            Destroy(gameObject);
            AsteroidSpawner.iCurrentAsteroidCount--;
        }
    }

    private void OnParticleCollision(GameObject other)
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
}
