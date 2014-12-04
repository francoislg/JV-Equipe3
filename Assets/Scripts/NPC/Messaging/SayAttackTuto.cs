using UnityEngine;
using System.Collections;

public class SayAttackTuto : TalkToPlayer
{
	protected override string InteractWithPlayer()
	{
		return "Pour attaquer, bouge la souris sur les monstres et lance une attaque en cliquant avec le bouton de gauche. Il y a des zombis dans les environs, peux-tu les eliminer ? Lors de ton aventure, tu trouveras peut-etre de nouvelles armes. Tu pourras les utiliser a l'aide du bouton de droite de la souris ! Bonne chance !";
	}
}
