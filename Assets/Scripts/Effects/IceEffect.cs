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

    }

    void PostBattleEffect(PostBattleParams battleParams)
    {
        if (battleParams.IsInitiator)
        {
            FreezedEffect freezedEffect = battleParams.target.gameObject.AddComponent<FreezedEffect>();
            freezedEffect.freezesTurns = freezesTurns;
        }
        if (!battleParams.IsInitiator)
        {
            FreezedEffect freezedEffect = battleParams.source.gameObject.AddComponent<FreezedEffect>();
            freezedEffect.freezesTurns = freezesTurns;
        }

    }
}
