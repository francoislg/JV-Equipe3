using UnityEngine;
using System.Collections;

public class CameraBindToPlayer : MonoBehaviour
{
    Transform _target;
    float _initialOffset = 30f;

    void Start()
    {
        _initialOffset = transform.position.y;
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        transform.position = new Vector3(_target.position.x, _target.position.y + _initialOffset, _target.position.z);
    }
}
