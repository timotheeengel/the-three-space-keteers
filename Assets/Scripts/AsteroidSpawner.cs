using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject goAsteroid;

    public float fSpawnRange;
    public float fMinmumScale;
    public int iAsteroidMax; //The amount of asteroid desired at all times

    public static int iCurrentAsteroidCount;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < iAsteroidMax; i++)
        {
            CreateAsteroid();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (iCurrentAsteroidCount < iAsteroidMax)
        {
            for (int i = iAsteroidMax - iCurrentAsteroidCount; i > 0; i--)
            {
                CreateAsteroid();
            }
        }
    }

    void CreateAsteroid()
    {
        Vector3 v3SpawnPos = Random.insideUnitSphere * fSpawnRange;
        v3SpawnPos += transform.position;
        Quaternion qSpawnRotation = Random.rotation;
        GameObject spawn = Instantiate(goAsteroid, v3SpawnPos, qSpawnRotation);
        spawn.transform.localScale = Vector3.one * Random.Range(fMinmumScale, 1);
        iCurrentAsteroidCount++;
    }
}
