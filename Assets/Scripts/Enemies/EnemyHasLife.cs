using UnityEngine;
using System.Collections;

public class EnemyHasLife : MonoBehaviour, HasLife
{
    public GameObject floatingTextClass;
    public GameObject floatingHealthClass;
    protected GameObject floatingHealthObject;
    protected FloatingHealth floatingHealthScript;
    
    public float maximumLife = 10;
    public int pointsOnDeath = 5;
    public bool alive = true;

    public float Life { get; private set; }

    void Start()
    {
        Life = maximumLife;
        floatingHealthObject = Instantiate(floatingHealthClass, transform.position, Quaternion.identity) as GameObject;
        floatingHealthScript = floatingHealthObject.GetComponent<FloatingHealth>() as FloatingHealth;
        floatingHealthScript.target = this.gameObject;
        OnStart();
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.y = 1;
        transform.position = pos;
        OnUpdate();
    }

    public void ReceiveDamage(float damage)
    {
        if (alive)
        {
            Life -= damage;
            floatingHealthScript.setPctLife(Life / maximumLife);
            createFloatingText(damage.ToString());
            if (Life <= 0)
            {
                Die();
            }
        }
    }

    private void createFloatingText(string text)
    {
        GameObject floatingText = Instantiate(floatingTextClass, transform.position, Quaternion.identity) as GameObject;
        floatingText.guiText.text = text;
    }

    private void Die()
    {
        FindObjectOfType<PlayerStatus>().AddPointsToScore(pointsOnDeath);
        Destroy(floatingHealthObject);
        alive = false;
        OnDeath();
    }

    protected virtual void OnStart() { }
    protected virtual void OnUpdate() { }
    protected virtual void OnDeath() { }
}
