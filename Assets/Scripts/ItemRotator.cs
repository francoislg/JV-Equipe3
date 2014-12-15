using UnityEngine;
using System.Collections;

public class ItemRotator : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), 15 * Time.deltaTime, Space.World);
    }
}
