using UnityEngine;
using System.Collections;

public class CameraBindToPlayer : MonoBehaviour
{
    Transform target;
    float initialOffset = 20f;

    void Start()
    {
        initialOffset = transform.position.y;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y + initialOffset, target.position.z);
    }
}
