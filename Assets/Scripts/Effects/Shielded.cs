using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Creature))]
public class ShieldedEffect : Effect
{

    public int shieldValue; 
    public int ShieldValue
    {
        get { return shieldValue; }
        set
        {
            shieldValue = value;
            if (token != null)
            {
                token.SetStat(value);
            }
            if (shieldValue == 0)
            {
                Destroy(token.gameObject);
                GetComponent<Creature>().PostBattleEffect.RemoveListener(PostBattleEffect);
                Destroy(this);
            }
        }
    }
    private StatsToken token;
    void Start()
    {
        GetComponent<Creature>().PostBattleEffect.AddListener(PostBattleEffect);
        token = GetComponent<StatsBar>().AddStatToken(Stat.Shield);
        token.SetStat(ShieldValue);

        Refresh();
    }
    public override void Refresh()
    {
    }

    void PostBattleEffect(PostBattleParams battleParams)
    {
        Debug.Log("shieldValue");
        if (ShieldValue > 0)
        {
            if (battleParams.IsInitiator)
            {
                int damageToAbsorb = Mathf.Min(battleParams.damageToSource, ShieldValue);
                ShieldValue -= damageToAbsorb;
                battleParams.source.Health += damageToAbsorb;
            }
            if (!battleParams.IsInitiator)
            {
                int damageToAbsorb = Mathf.Min(battleParams.damageToTarget, ShieldValue);
                ShieldValue -= damageToAbsorb;
                battleParams.target.Health += damageToAbsorb;
            }
        }
    }
}
