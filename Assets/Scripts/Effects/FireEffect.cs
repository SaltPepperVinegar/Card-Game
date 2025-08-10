using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Creature))]
public class FireEffect : Effect
{
    void Start()
    {
        GetComponent<Creature>().PostBattleEffect.AddListener(PostBattleEffect);
    }

    void PostBattleEffect(PostBattleParams battleParams)
    {
        if (battleParams.IsInitiator)
        {
            battleParams.source.Attack += battleParams.damageToSource;
        }
    }
}
