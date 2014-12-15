using UnityEngine;
using System.Collections;

public abstract class TalkToPlayer : MessageDrawer
{
    protected abstract string InteractWithPlayer();
    
    public string message;

    GameObject _player;
    bool _isTalking;

    protected override void Start()
    {
        base.Start();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void Update()
    {
        base.Update();
        // Si :
        // - le joueur est proche
        // - il n'y a pas de message visible
        // - le joueur n'a pas deja parlé
        if (!IsMessageVisible() &&
            !_isTalking &&
            Vector3.Distance(_player.transform.position, transform.position) < 3)
        {
            // Alors on intéragit avec le joueur
            _isTalking = true;
            ShowMessage(InteractWithPlayer());
        }

        if (Vector3.Distance(_player.transform.position, transform.position) >= 3)
        {
            _isTalking = false;
        }
    }
}
