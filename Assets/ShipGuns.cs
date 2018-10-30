using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Serialization;

public class ShipGuns : MonoBehaviour
{
	private string _firingKey = "Fire1";
	[SerializeField] private float _coolDown = 0.5f;
	private float _coolDownTimer = 0f;
	[SerializeField] private GameObject _missile;
	[SerializeField] private float _missileSpeed = 200f;
	private GameObject[] _gunBarrels;
	
	// Use this for initialization
	void Start ()
	{
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
				// TODO: Why is there no velocity?!
				GameObject newMissile = Instantiate(_missile, barrel.transform.position, Quaternion.identity);
				newMissile.GetComponent<Rigidbody>().velocity = newMissile.transform.forward * _missileSpeed;
				Debug.Log(newMissile.GetComponent<Rigidbody>().velocity);
			}

			_coolDownTimer = _coolDown;
		}
	}
}
