using UnityEngine;
using System.Collections;

public abstract class Munition : MonoBehaviour {

    public bool Expirer;
    public bool Actif;

    public int baseDamage;
    public Transform Spawner;
    public int speed;
    public int duration;
    public bool joueur;
    public Color color;

    protected Vector3 target;

    protected double creationTimeStamp;

	// Use this for initialization
	protected virtual void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject p in players)
        {
            Collider pc = p.GetComponent<Collider>();
            if (pc)
            {
                if (collider)
                {
                    Physics.IgnoreCollision(pc, collider);
                }
            }
        }
        Expirer = true;
        Actif = false;
	}

    public virtual void OnCollisionEnter(Collision other)
    {
        Recyle();
    }

    public virtual void Fire(Vector3 target)
    {
        Expirer = false;
        Actif = true;
        transform.position = Spawner.position;
        transform.LookAt(target);
        this.target = target;
        if (rigidbody)
        {
            rigidbody.isKinematic = false;
        }
        creationTimeStamp = Time.time;
    }

    protected void Recyle()
    {
        Expirer = true;
        if (rigidbody)
        {
            rigidbody.isKinematic = true;
        }
    }


}
