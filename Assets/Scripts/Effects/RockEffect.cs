using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Creature))]
public class EarthEffect : Effect
{

    public int shieldValue; 
    void Start()
    {
        int creatureHealth = GetComponent<Creature>().Health;
        shieldValue = Mathf.CeilToInt(creatureHealth / 2f);
        GetComponent<Creature>().PostBattleEffect.AddListener(PostBattleEffect);
    }

    void PostBattleEffect(PostBattleParams battleParams)
    {
        Debug.Log("shieldValue");
        if (shieldValue > 0)
        {
            if (battleParams.IsInitiator)
            {
                int damageToAbsorb = Mathf.Min(battleParams.damageToSource, shieldValue);
                shieldValue -= damageToAbsorb;
                battleParams.source.Health += damageToAbsorb;
            }
            if (!battleParams.IsInitiator)
            {
                int damageToAbsorb = Mathf.Min(battleParams.damageToTarget, shieldValue);
                shieldValue -= damageToAbsorb;
                battleParams.target.Health += damageToAbsorb;
            }
        }
    }
}
