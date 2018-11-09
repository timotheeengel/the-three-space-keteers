using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    Vector3 v3Target;
    Vector3 v3Direction;

    [SerializeField] private Rigidbody Rigidbody;
    [SerializeField] private float fStartForceMin = 50f;
    [SerializeField] private float fStartForceMax = 200f;

    // Use this for initialization
    void Start()
    {
        v3Direction = Random.onUnitSphere;
        Rigidbody.AddForce(v3Direction * Random.Range(fStartForceMin, fStartForceMax));
    }
}

