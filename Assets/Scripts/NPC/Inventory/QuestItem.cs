using UnityEngine;
using System.Collections;

public class QuestItem : MessageDrawer
{
    public string friendlyName;
    public string description;

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
        playerInventory.Add(this);
        ShowMessage("Vous avez trouve : " + friendlyName);

        pickedUp = true;
        renderer.enabled = false;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        return (obj as QuestItem).friendlyName == friendlyName;
    }

    // override object.GetHashCode
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
