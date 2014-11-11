using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour
{
    public float cooldownDuration = 1.0f;

    public Texture2D icon { get; protected set; }

    public abstract void ShootAt(Vector3 target);
}