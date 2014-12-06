using UnityEngine;
using System.Collections;

public class SayQuestTuto : TalkToPlayer
{
	protected override string InteractWithPlayer()
	{
		return "Dans ton aventure, tu devras parfois completer des missions. Les gens du village t'expliqueront en temps et lieu. Lorsque tu te sentiras pret, marche dans cette zone mysterieuse (et bleue !) pour progresser dans ton aventure ! Bonne chance !";
	}
}
