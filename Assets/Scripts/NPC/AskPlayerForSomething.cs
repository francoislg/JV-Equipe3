using UnityEngine;
using System.Collections;

public class AskPlayerForSomething : TalkToPlayer
{
    protected override string GenerateMessage()
    {
        return "J'AI PERDU MON PORTE FEUILLE ... " +
            "SI TU ME LE RETROUVE JE TE DONNERAI UNE BELLE RECOMPENSE !";
    }
}
