using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class ShipGuns : MonoBehaviour
{
	private string _firingKey = "Fire1";
	private ParticleSystem[] guns;
	
	// Use this for initialization
	void Start ()
	{
		guns = GetComponentsInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		Shoot();
	}

	void Shoot()
	{
		foreach (ParticleSystem gun in guns)
		{

			if (Input.GetButton(_firingKey))
			{
				gun.Play();
			}
			else
			{
				gun.Stop();
			}
		}
	}
}
