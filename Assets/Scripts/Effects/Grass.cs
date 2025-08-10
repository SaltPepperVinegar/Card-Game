using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Creature))]
public class GrassEffect : Effect
{
    void Start()
    {

        GetComponent<Creature>().PostBattleEffect.AddListener(PostBattleEffect);
    }

    void PostBattleEffect(PostBattleParams battleParams)
    {
        if (battleParams.IsInitiator)
        {
            int diff = Mathf.Max(0, battleParams.damageToTarget - battleParams.damageToSource);
            battleParams.source.Health += diff;
        }
        else
        {
            int diff = Mathf.Max(0, battleParams.damageToSource - battleParams.damageToTarget);
            battleParams.target.Health += diff;
        }
    }
}
