using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Creature))]
public class WaterEffect : Effect
{
    public int damageToAbsorb;
    void Start()
    {
        GetComponent<Creature>().InteractEffect.AddListener(OnInitiateInteraction);
        GetComponent<Creature>().PreBattleEffect.AddListener(PreBattleEffect);

        GetComponent<Creature>().PostBattleEffect.AddListener(PostBattleEffect);
    }
    void PreBattleEffect(PreBattleParams battleParams)
    {
        if (!battleParams.IsInitiator)
        {
            damageToAbsorb = battleParams.source.Attack;
            battleParams.source.Attack = 0;
        }


    }

    void PostBattleEffect(PostBattleParams battleParams)
    {
        if (!battleParams.IsInitiator)
        {
            battleParams.source.Attack = damageToAbsorb;
        }


    }

    void OnInitiateInteraction()
    {
        GetComponent<Creature>().InteractEffect.RemoveListener(OnInitiateInteraction);
        GetComponent<Creature>().PreBattleEffect.RemoveListener(PreBattleEffect);

        GetComponent<Creature>().PostBattleEffect.RemoveListener(PostBattleEffect);
        Destroy(this);

    }
}
