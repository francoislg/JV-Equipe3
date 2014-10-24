using UnityEngine;
using System.Collections;

public class CameraBindToPlayer : MonoBehaviour
{
    public Transform target;
    public float depthOffset = 20f;

    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y + depthOffset, target.position.z);
    }
}
