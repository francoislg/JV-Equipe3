using UnityEngine;
using System.Collections;

public class EnemyMoving : MonoBehaviour
{
    public float speed = 1.0f;

    private GameObject target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.LookAt(target.transform.position);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
