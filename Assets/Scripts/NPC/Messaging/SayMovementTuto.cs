using UnityEngine;
using System.Collections;

public class SayMovementTuto : TalkToPlayer
{
    protected override string InteractWithPlayer()
    {
		return "Pour te deplacer dans le village, utilise les fleches du clavier (gauche, droite, haut et bas). Si tu preferes, il est pratique d'utiliser les touches A, S, D et W ! Bonne chance !";
    }
}
