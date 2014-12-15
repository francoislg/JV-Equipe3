using UnityEngine;

public class QuestItem : MessageDrawer
{
    public string friendlyName;
    public string description;
    public string pickUpMessage = "";
    public int distanceToPickUp = 3;
    public float speedBonus = 0;
    public GameObject spawnOnPickup;

    GameObject _player;
    PlayerHasInventory _playerInventory;
    bool _pickedUp;

    protected override void Start()
    {
        base.Start();
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerInventory = FindObjectOfType<PlayerHasInventory>();
        _pickedUp = false;
    }

    protected override void Update()
    {
        base.Update();

        if (!_pickedUp && Vector3.Distance(_player.transform.position, transform.position) < distanceToPickUp)
        {
            // On rammase l'objet quand le joueur est proche
            PickObject();
        }
        else if (_pickedUp && !IsMessageVisible())
        {
            // On supprime l'objet quand il a été récupéré et que le message a été affiché
            Destroy(gameObject);
        }
    }

    void PickObject()
    {
        InstanciatePickupSpawn();

        _playerInventory.Add(this);
        ShowMessage("Vous avez trouve : " + friendlyName + "\n" + pickUpMessage);
        _pickedUp = true;

        DisableRenderer();
    }

    void InstanciatePickupSpawn()
    {
        if (!spawnOnPickup) return;

        var angle = Random.Range(0.0f, Mathf.PI * 2);
        Instantiate(spawnOnPickup, transform.position + (new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle)) * 20), Quaternion.identity);
    }

    void DisableRenderer()
    {
        if (renderer)
        {
            renderer.enabled = false;
        }
        else
        {
            foreach (var childRend in GetComponentsInChildren<Renderer>())
            {
                childRend.enabled = false;
            }
        }
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;

        var other = (QuestItem) obj;
        return other.friendlyName == friendlyName;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
