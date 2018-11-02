using System.Collections;
using UnityEngine;

// In order for this script to work the camera should be a child of
// empty object that is located in the center world space

public class CameraShake : MonoBehaviour {

    [SerializeField]
    private float _duration = 0.7f;
    [SerializeField]
    private float _amplitude = 0.1f;

    private float _elapsedTime = 0f;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(Shake());
	}

    private IEnumerator Shake ()
    {
        while (_elapsedTime < _duration)
        {
            Vector2 pos = Random.insideUnitCircle * _amplitude;
            transform.position = new Vector3(pos.x, pos.y, 0f);

            _elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        _elapsedTime = 0f;
    }
}
