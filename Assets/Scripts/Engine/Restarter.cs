using UnityEngine;
using System.Collections;

public class Restarter : MonoBehaviour
{
    public void RestartGame()
    {
        Application.LoadLevel("GenTerrain");
    }
}
