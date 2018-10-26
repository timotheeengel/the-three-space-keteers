using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
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
				gun.Emit(Mathf.RoundToInt(gun.emission.rateOverTimeMultiplier * Time.deltaTime));
			}
			else
			{
				gun.Emit(0);
			}
		}
		
	}
}
