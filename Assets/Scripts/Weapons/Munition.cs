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

    protected int CompteurCollision = 0;
    protected Vector3 InitVelocity;

    public int NbCollision;
    public int emissionRate;
    public int emissionAngle;

    public int contactZone;
    public float explosionSpeed;
    public float explosionLifeTime;


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
        if (other.collider.tag == "Hydrant")
            Recyle();
        if (CompteurCollision >= NbCollision)
        {
            Recyle();
        }
        else
        {
            Vector3 arrive = InitVelocity;
            Vector3 normal = other.contacts[0].normal;
            Vector3 temp = 2 * Vector3.Dot(arrive, normal) * normal;
            Vector3 result = arrive - temp;
            InitVelocity = result;
            rigidbody.velocity = result;
            if (arrive != result)
            {
                CompteurCollision++;
            }
        }

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
        CompteurCollision = 0;
        if (rigidbody)
        {
            rigidbody.isKinematic = true;
        }
    }


}
