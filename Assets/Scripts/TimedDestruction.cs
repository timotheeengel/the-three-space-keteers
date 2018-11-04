using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestruction : MonoBehaviour
{
    public float fTimeToDestruction;
	// Use this for initialization
	void Start ()
    {
        Invoke("Destroy", fTimeToDestruction);
	}
	
	// Update is called once per frame
	void Update ()
    {
	}
    void Destroy()
    {
        Destroy(gameObject);
    }
}
