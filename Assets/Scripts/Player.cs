using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{

	[FormerlySerializedAs("_inversedYaw")] [SerializeField] private bool _inversedPitch = false;
	[SerializeField] private float _movementSpeed = 20f;
	[SerializeField] private float _rotationSpeed = 50f;

	private Rigidbody _playerRb;

	// Use this for initialization
	void Start ()
	{
		_playerRb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update()
	{
		Movement();
	}

	void Movement()
	{
		float yaw = Input.GetAxis("Mouse X") * _rotationSpeed * Time.deltaTime;
		float pitch = Input.GetAxis("Mouse Y") * _rotationSpeed * Time.deltaTime;
		if (_inversedPitch)
		{
			pitch = -pitch;
		}

		transform.Rotate(transform.up, yaw);
		transform.Rotate(transform.right, pitch);
		float resetRoll = transform.eulerAngles.z;
		transform.Rotate(0, 0, -resetRoll);
		
		_playerRb.velocity = transform.forward * _movementSpeed * Time.deltaTime;
	}
}
