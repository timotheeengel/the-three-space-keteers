using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    Vector3 v3Target;
    Vector3 v3Direction;

    public Rigidbody Rigidbody;
    public float fStartForceMin;
    public float fStartForceMax;

    // Use this for initialization
    void Start()
    {
        v3Direction = Random.onUnitSphere;
        Rigidbody.AddForce(v3Direction * Random.Range(fStartForceMin, fStartForceMax));
    }

    // Update is called once per frame
    void Update()
    {

    }
}

