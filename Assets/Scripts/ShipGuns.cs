using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Serialization;

public class ShipGuns : MonoBehaviour
{
	private string _firingKey = "Fire1";
	[SerializeField] private float _coolDown = 0.5f;
	private float _coolDownTimer = 0f;
	[SerializeField] private GameObject _missile;
	[SerializeField] private GameObject _muzzleFlash;
	[SerializeField] private float _missileSpeed = 200f;
	[SerializeField] private float _missileLifeTime = 3f;

	[SerializeField] private float _autoAimDistance = 20f;
 	private GameObject[] _gunBarrels;
	private GameObject _missileParent;

	private Transform _crossHairProjection;
	private Transform _crossHairPos;
	
	// Use this for initialization
	void Start ()
	{
		_missileParent = GameObject.Find("Missiles");
		if (_missileParent == null)
		{
			_missileParent = new GameObject();
			_missileParent.transform.position = Vector3.zero;
			_missileParent.transform.rotation = Quaternion.identity;
			_missileParent.name = "Missiles";
		}
		_gunBarrels = GameObject.FindGameObjectsWithTag("Barrel");
		_crossHairProjection = GameObject.Find("CrossHairProjection").transform;
		_crossHairPos = GameObject.Find("CrossHair").transform;
	}

	void OrientBarrels()
	{
		RaycastHit hit;
		Ray ray = new Ray(_crossHairPos.transform.position, _crossHairPos.forward);
		Debug.DrawRay(ray.origin, ray.direction * _autoAimDistance, Color.blue);
		
		if (Physics.Raycast(ray, out hit, _autoAimDistance))
		{
			Vector3 autoAimTarget = hit.transform.position;
			
			foreach (GameObject barrel in _gunBarrels)
			{
				barrel.transform.LookAt(autoAimTarget);
			}
		}
		else
		{
			foreach (GameObject barrel in _gunBarrels)
			{
				barrel.transform.LookAt(_crossHairProjection.position);
			}			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		Shoot();
		OrientBarrels();
		foreach (var gun in _gunBarrels)
		{
			Debug.DrawRay(gun.transform.position, gun.transform.forward * 100f, Color.magenta);
		}
	}

	void Shoot()
	{
		_coolDownTimer -= Time.deltaTime;
		if (Input.GetButton(_firingKey) && _coolDownTimer <= Mathf.Epsilon)
		{
			foreach (GameObject barrel in _gunBarrels)
			{
				GameObject newMissile = Instantiate(_missile, barrel.transform.position, barrel.transform.rotation);
				Rigidbody missileRb = newMissile.GetComponent<Rigidbody>();
				missileRb.velocity = barrel.transform.forward * _missileSpeed;
				missileRb.useGravity = false;
				
				newMissile.transform.parent = _missileParent.transform;
				Destroy(newMissile, _missileLifeTime);

				GameObject newFlash = Instantiate(_muzzleFlash, barrel.transform.position, barrel.transform.rotation);
				newFlash.transform.parent = barrel.transform;
				Destroy(newFlash, 1f);
			}
			_coolDownTimer = _coolDown;
		}
	}
}
