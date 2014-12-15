using UnityEngine;
using System.Collections;

public class ItemUpDown : MonoBehaviour
{
    public float amplitude;
    public float offset;

    float _timeSum = 0.0f;

    void Update()
    {
        _timeSum += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, (Mathf.Sin(_timeSum) * amplitude) + offset, transform.position.z);
    }
}
