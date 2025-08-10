using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Creature))]
public class IceEffect : Effect
{

    public int freezesTurns = 1;
    void Start()
    {
        GetComponent<Creature>().PostBattleEffect.AddListener(PostBattleEffect);
        Refresh();
    }
    public override void Refresh()
    {

    }

    void PostBattleEffect(PostBattleParams battleParams)
    {
        FreezedEffect freezedEffect;
        if (battleParams.IsInitiator)
        {
            if ((freezedEffect = battleParams.target.gameObject.GetComponent<FreezedEffect>()) == null)
            {
                freezedEffect = battleParams.target.gameObject.AddComponent<FreezedEffect>();
                freezedEffect.FreezesTurns = freezesTurns;
                return;
            }
            freezedEffect.Refresh();
            freezedEffect.FreezesTurns = freezesTurns;

        }


    }
}
