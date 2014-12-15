using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class GhostAI : MonoBehaviour
{
    private const string PathToRandom = "JellyMonsters/Prefabs/";

    public float speed = 1f;
    public GameObject QuestItemMalus;

    GameObject _target;
    float _velY;
    float _originalY;

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        _velY = 0.1f;
        _originalY = transform.position.y;

        var prefab = Resources.Load(PathToRandom + RandomJelly()) as GameObject;
        var ghost = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
        if (ghost != null)
        {
            ghost.transform.parent = transform;
        }
    }

    public string RandomJelly()
    {
        var names = new ArrayList() { "Blue", "Red", "Orange", "Purple", "Red" };
        return names[Random.Range(0, 5)] + "Jelly";
    }

    void Update()
    {
        transform.LookAt(_target.transform.position);

        transform.position += new Vector3(0, _velY, 0);
        transform.position += transform.forward * speed * Time.deltaTime;
        if (Mathf.Abs(_originalY - transform.position.y) > 1)
        {
            _velY = -_velY;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(QuestItemMalus, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
