using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

	[SerializeField] private GameObject _Explosion;
	[SerializeField] private GameObject _ExplosionVertical;
	// Use this for initialization
	void Start ()
	{
		AudioSource audioSource = GetComponent<AudioSource>();
		audioSource.pitch = Random.Range(0.9f, 1.1f);
		audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.CompareTag("Asteroid"))
		{
			Destroy(gameObject);
		}
	}
}
