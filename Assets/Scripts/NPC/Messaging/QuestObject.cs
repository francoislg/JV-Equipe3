using UnityEngine;
using System.Collections;

public class QuestObject : MessageDrawer
{
    public string objectName;

    GameObject player;
    PlayerHasInventory playerInventory;
    bool pickedUp = false;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
        playerInventory = GameObject.FindObjectOfType<PlayerHasInventory>();
    }

    protected override void Update()
    {
        base.Update();

        if (!pickedUp && Vector3.Distance(player.transform.position, transform.position) < 3)
        {
            // On rammase l'objet quand le joueur est proche
            PickObject();
        }
        else if (pickedUp && !IsMessageVisible())
        {
            // On supprime l'objet quand il a été récupéré et que le message a été affiché
            Destroy(this.gameObject);
        }
    }

    void PickObject()
    {
        playerInventory.AddQuestObject(objectName);
        ShowMessage("Vous avez trouve : " + objectName);
        pickedUp = true;
        renderer.enabled = false;
    }
}
