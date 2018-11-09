using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{

	[SerializeField] private bool _inversedPitch = false;
	[SerializeField] private float _movementSpeed = 200f;
	[SerializeField] private float _rotationSpeed = 50f;

	private Rigidbody _playerRb;

	// Use this for initialization
	void Start ()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		_playerRb = GetComponentInParent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update()
	{
		MovementWithQuaternion();
	}

	void MovementWithQuaternion()
	{
		// Rotation needs to be done with Quaternions && applied to the rb's rotation rather than using the transform's!
		
		float yaw = Input.GetAxis("Mouse X") * _rotationSpeed * Time.deltaTime;
		float pitch = Input.GetAxis("Mouse Y") * _rotationSpeed * Time.deltaTime;
		
		if (_inversedPitch)
		{
			pitch = -pitch;
		}
		
//		Quaternion yawAsQuaternion = Quaternion.Euler(0f, yaw, 0f);
//		_playerRb.rotation *= yawAsQuaternion;
//
//		Quaternion pitchAsQuaternion = Quaternion.Euler(pitch, 0f, 0f);
//		_playerRb.rotation *= pitchAsQuaternion;

		Quaternion newOrientationDir = Quaternion.Euler(pitch, yaw, 0f);
		_playerRb.rotation *= newOrientationDir;
		_playerRb.velocity = transform.forward * _movementSpeed * Time.deltaTime;
	}
}
