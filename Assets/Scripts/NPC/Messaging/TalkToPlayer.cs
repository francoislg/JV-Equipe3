using UnityEngine;
using System.Collections;

public abstract class TalkToPlayer : MessageDrawer
{
    protected abstract string InteractWithPlayer();

    GameObject player;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void Update()
    {
        base.Update();
        // Si le joueur est proche, qu'il appuie sur espace et qu'il n'y a pas de message visible
        if (!IsMessageVisible() &&
            Input.GetKeyDown(KeyCode.Space) &&
            Vector3.Distance(player.transform.position, transform.position) < 3)
        {
            // Alors on intéragit avec le joueur
            ShowMessage(InteractWithPlayer());
        }
    }
}
