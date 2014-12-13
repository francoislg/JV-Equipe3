using UnityEngine;
using System.Collections;

public class onHit : MonoBehaviour {

    public ParticleSystem emitter;
    private bool isReady;
    
    void Start()
    {
        isReady = true;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet" && isReady)
        {
            Debug.Log("hit from bullet");
            emitter.Play();
            isReady = false;
        }
    }
}
