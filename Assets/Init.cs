using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour
{
    void Start()
    {
        Physics.gravity = new Vector3(0, -10, 0);
    }
}
