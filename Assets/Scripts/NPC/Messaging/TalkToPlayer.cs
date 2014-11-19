using UnityEngine;
using System.Collections;

public abstract class TalkToPlayer : MessageDrawer
{
    protected abstract string InteractWithPlayer();

    GameObject player;
    bool isTalking = false;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void Update()
    {
        base.Update();
        // Si :
        // - le joueur est proche
        // - il n'y a pas de message visible
        // - le joueur n'a pas deja parlé
        if (!IsMessageVisible() &&
            !isTalking &&
            Vector3.Distance(player.transform.position, transform.position) < 3)
        {
            // Alors on intéragit avec le joueur
            isTalking = true;
            ShowMessage(InteractWithPlayer());
        }

        if (Vector3.Distance(player.transform.position, transform.position) >= 3)
        {
            isTalking = false;
        }
    }
}
