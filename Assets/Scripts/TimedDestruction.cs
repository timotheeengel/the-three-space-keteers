using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestruction : MonoBehaviour
{
    public float fTimeToDestruction;
	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, fTimeToDestruction);
	}
}
