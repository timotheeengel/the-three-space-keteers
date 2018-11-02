using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpinning : MonoBehaviour
{
    public Rigidbody RB;

	// Use this for initialization
	void Start ()
    {
        RB.angularVelocity = Random.insideUnitSphere;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
