using UnityEngine;
using System.Collections;

public class QuestItem : MessageDrawer
{
    public string friendlyName;
    public string description;
	public string pickUpMessage = "";
	public int distanceToPickUp = 3;
	public float speedBonus = 0;
	public GameObject spawnOnPickup;

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

		if (!pickedUp && Vector3.Distance(player.transform.position, transform.position) < distanceToPickUp)
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
		if(spawnOnPickup){
			float angle = Random.Range(0.0f, Mathf.PI*2);
			Instantiate(spawnOnPickup, transform.position + (new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle)) * 20), Quaternion.identity);
		}
        playerInventory.Add(this);
		ShowMessage("Vous avez trouve : " + friendlyName + "\n" + pickUpMessage);

        pickedUp = true;
		if(renderer){
			renderer.enabled = false;
		}else{
			Renderer childRend = GetComponentInChildren<Renderer>() as Renderer;
			if(childRend){
				childRend.enabled = false;
			}
		}
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
