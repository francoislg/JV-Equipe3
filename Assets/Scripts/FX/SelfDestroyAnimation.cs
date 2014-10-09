using UnityEngine;
using System.Collections;

public class SelfDestroyAnimation : MonoBehaviour
{
    void Update()
    {
        if (!particleSystem.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
