using UnityEngine;
using System.Collections;

public class Restarter : MonoBehaviour {
    public void restartGame() {
        Application.LoadLevel("Scene");
    }

    private void destroyEnemies() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies){
            Destroy(enemy);
        }
    }

    private void respawnPlayer() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerHasLife>().respawn();
    }
}
