using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Creature))]
public class EarthEffect : Effect
{
    public int shieldValue; 

    void Start()
    {

        Refresh();
    }
    public override void Refresh()
    {
        ShieldedEffect shieldedEffect;

        if ((shieldedEffect = GetComponent<ShieldedEffect>()) == null)
        {
            shieldedEffect = gameObject.AddComponent<ShieldedEffect>();
        }
        int creatureHealth = GetComponent<Creature>().Health;
        shieldValue = Mathf.CeilToInt(creatureHealth / 2f);
        shieldedEffect.ShieldValue = shieldValue;
    }


}
