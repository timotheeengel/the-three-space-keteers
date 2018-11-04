using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> a_goAsteroids;

    public float fSpawnRange;
    public float fMinmumScale;
    public float fMaximumScale;
    public int iAsteroidMax; //The amount of asteroid desired at all times

    public static int iCurrentAsteroidCount;

    // Use this for initialization
    void Start()
    {
        StartSetupAsteroids();
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

    public void StartSetupAsteroids()
    {
        for (int i = 0; i < iAsteroidMax; i++)
        {
            Vector3 v3SpawnPos = Random.insideUnitSphere * fSpawnRange;
            v3SpawnPos += transform.position;
            Quaternion qSpawnRotation = Random.rotation;
            GameObject spawn = Instantiate(a_goAsteroids[Random.Range(0, a_goAsteroids.Count)], v3SpawnPos, qSpawnRotation);
            spawn.transform.localScale = Vector3.one * Random.Range(fMinmumScale, fMaximumScale);
            iCurrentAsteroidCount++;
        }
    }

    public void CreateAsteroid()
    {
        Vector3 v3SpawnPos = Random.onUnitSphere * fSpawnRange;
        v3SpawnPos += transform.position;
        Quaternion qSpawnRotation = Random.rotation;
        GameObject spawn = Instantiate(a_goAsteroids[Random.Range(0, a_goAsteroids.Count)], v3SpawnPos, qSpawnRotation);
        spawn.transform.localScale = Vector3.one * Random.Range(fMinmumScale, fMaximumScale);
        iCurrentAsteroidCount++;
    }
}
