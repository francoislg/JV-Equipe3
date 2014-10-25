using UnityEngine;
using System.Collections;

public class CameraBindToPlayer : MonoBehaviour
{
    public Transform target;

    private float initialOffset = 20f;

    void Start()
    {
        initialOffset = transform.position.y;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y + initialOffset, target.position.z);
    }
}
