using UnityEngine;
using System.Collections;

public class fireHydrantOnHit : MonoBehaviour
{
    public ParticleSystem emitter;

    bool _isReady;

    void Start()
    {
        _isReady = true;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet" && _isReady)
        {
            emitter.Play();
            _isReady = false;

            var hydrantDmgCollider = transform.Find("HydrantDmgCollider");
            var feild = hydrantDmgCollider.gameObject.GetComponent("fireHydrantWaterDmgFeild") as fireHydrantWaterDmgFeild;

            if (feild != null)
            {
                feild.ActivateFeild();
            }
        }
    }
}
