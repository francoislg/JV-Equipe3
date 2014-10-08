using UnityEngine;
using System.Collections;

public class EnemyMoving : MonoBehaviour
{
    private GameObject target;
    private float speed = 1.0f;
    private ParticleSystem ps;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        transform.LookAt(target.transform.position);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void onDestroy()
    {
        ps.Play();
        ps.Stop();
    }
}
