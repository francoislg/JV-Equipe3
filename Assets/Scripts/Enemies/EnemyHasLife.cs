using UnityEngine;
using System.Collections;

public class EnemyHasLife : MonoBehaviour, HasLife
{
    public GameObject floatingTextClass;
    public GameObject floatingHealthClass;
    public float maximumLife = 10;
    public int pointsOnDeath = 5;
    public bool alive = true;

    public float Life { get; private set; }

    protected GameObject FloatingHealthObject;
    protected FloatingHealth FloatingHealthScript;

    void Start()
    {
        Life = maximumLife;
        FloatingHealthObject = Instantiate(floatingHealthClass, transform.position, Quaternion.identity) as GameObject;
        FloatingHealthScript = FloatingHealthObject.GetComponent<FloatingHealth>();
        FloatingHealthScript.target = gameObject;
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
        if (!alive) return;

        Life -= damage;
        FloatingHealthScript.setPctLife(Life / maximumLife);
        CreateFloatingText(damage.ToString());
        if (Life <= 0)
        {
            Die();
        }
    }

    private void CreateFloatingText(string text)
    {
        var floatingText = Instantiate(floatingTextClass, transform.position, Quaternion.identity) as GameObject;
        if (floatingText != null)
        {
            floatingText.guiText.text = text;
        }
    }

    private void Die()
    {
        PlayerStatus.Score += pointsOnDeath;

        Destroy(FloatingHealthObject);
        alive = false;
        OnDeath();
    }

    protected virtual void OnStart() { }
    protected virtual void OnUpdate() { }
    protected virtual void OnDeath() { }
}
