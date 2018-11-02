using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	[SerializeField] private bool _inversedYaw = false;
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
		float pitch = Input.GetAxis("Mouse X") * _rotationSpeed;
		float yaw = Input.GetAxis("Mouse Y") * _rotationSpeed;
		if (_inversedYaw)
		{
			yaw = -yaw;
		}

		transform.Rotate(yaw, pitch, 0f, Space.Self);
		float resetRoll = transform.eulerAngles.z;
		transform.Rotate(0, 0, -resetRoll, Space.Self);
		_playerRb.velocity = transform.forward * _movementSpeed * Time.deltaTime;
	}
}
