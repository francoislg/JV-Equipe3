using UnityEngine;
using System.Collections;

public class Munition_Bulle : Munition {

    ParticleSystem particule;
    private bool fire;

    protected override void Start()
    {
        base.Start();
        particule = GetComponent(typeof(ParticleSystem)) as ParticleSystem;
    }

    void FixedUpdate()
    {
        if (fire)
        {
            if (!particule.enableEmission)
            {
                particule.enableEmission = true;
            }
            fire = false;
        }
        else
        {
            particule.enableEmission = false;
        }
    }

    public override void Fire(Vector3 target)
    {
        base.Fire(target);
        fire = true;
    }

    public void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Spawner")
           {
               HasLife enemyWithLife = other.gameObject.GetComponent<HasLife>() as HasLife;
               enemyWithLife.ReceiveDamage(baseDamage);
           }
    }
}
