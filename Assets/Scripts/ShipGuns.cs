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
	private GameObject[] _gunBarrels;
	private GameObject _missileParent;
	
	
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
	}
	
	// Update is called once per frame
	void Update () {
		Shoot();
	}

	void Shoot()
	{
		_coolDownTimer -= Time.deltaTime;
		if (Input.GetButton(_firingKey) && _coolDownTimer <= Mathf.Epsilon)
		{
			foreach (GameObject barrel in _gunBarrels)
			{
				GameObject newMissile = Instantiate(_missile, barrel.transform.position, Quaternion.identity);
				newMissile.GetComponent<Rigidbody>().velocity = transform.forward * _missileSpeed;
				newMissile.transform.parent = _missileParent.transform;
				Destroy(newMissile, _missileLifeTime);

				GameObject newFlash = Instantiate(_muzzleFlash, barrel.transform.position, Quaternion.identity);
				newFlash.transform.parent = barrel.transform;
				Destroy(newFlash, 1f);
			}
			_coolDownTimer = _coolDown;
		}
	}
}
