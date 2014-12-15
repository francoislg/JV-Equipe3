using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour
{
    GameObject _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.LookAt(_player.transform);
    }
}
