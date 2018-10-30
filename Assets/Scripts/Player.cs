using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	[SerializeField] private bool _inversedYAxis = false;
	[SerializeField] private float _movementSpeed = 20f;
	[SerializeField] private float _rotationSpeed = 50f;
	[SerializeField] private float _mouseOffsetFromCamera = 100f;

	private Rigidbody _playerRb;
	
	// Use this for initialization
	void Start ()
	{
		_playerRb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Movement();
	}

	void Movement()
	{
		Vector3 mousePos = MousePosition();
    	Quaternion rotationNew = Quaternion.FromToRotation(transform.position, mousePos);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationNew, _rotationSpeed * Time.deltaTime);
		
		_playerRb.velocity = transform.forward * _movementSpeed * Time.deltaTime;
	}

	Vector3 MousePosition()
	{
		if (Camera.main == null)
		{
			Debug.LogError("No Camera, Cannot Compile ViewPort Direction");
			return Vector3.zero;
		}
		
		/* Vector3.forward * _mouseOffsetFromCamera
		 is used to offset the mouse's perceived world position in respect to the camera.
		 This way the angle we calculate later on is not too obtuse and allows for smoother rotation.
		*/ 
		Vector3 mousePositionScreen = Input.mousePosition + Vector3.forward * _mouseOffsetFromCamera;
		Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);

		if (_inversedYAxis == true)
		{
			mousePositionWorld.y = -mousePositionWorld.y;
		}
		
		return mousePositionWorld;
	}
}
