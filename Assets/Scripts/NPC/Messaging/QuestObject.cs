using UnityEngine;
using System.Collections;

public class QuestObject : MessageDrawer
{
    public string objectName;

    GameObject player;
    PlayerHasInventory playerInventory;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
        playerInventory = GameObject.FindObjectOfType<PlayerHasInventory>();
    }

    protected override void Update()
    {
        base.Update();
        // Si le joueur est proche
        if (Vector3.Distance(player.transform.position, transform.position) < 3)
        {
            // Alors il ramasse l'objet
            playerInventory.AddQuestObject(objectName);
            ShowMessage("VOUS AVEZ RAMASSE : " + objectName);
            Destroy(this.gameObject);
        }
    }
}
