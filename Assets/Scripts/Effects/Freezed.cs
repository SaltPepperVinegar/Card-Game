using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Creature))]
public class FreezedEffect : Effect
{

    public int FreezesTurns
    {
        get { return freezesTurns; }
        set
        {
            freezesTurns = value;
            if (token != null)
            {
                token.SetStat(value);
            }
        }
    }
    private int freezesTurns = 1;
    private StatsToken token;
    void Start()
    {
        GetComponent<Creature>().TurnStartEffect.AddListener(TurnStartEffect);
        token = GetComponent<StatsBar>().AddStatToken(Stat.Freeze);
        token.SetStat(freezesTurns);
        Refresh();
    }
    public override void Refresh()
    {

    }

    public void TurnStartEffect()
    {
        if (FreezesTurns <= 0)
        {
            Destroy(this);
            return;
        }

        FreezesTurns -= 1;
        GetComponent<Creature>().actionPoint = 0;
    }

    void OnDestroy()
    {
        GetComponent<Creature>().TurnStartEffect.RemoveListener(TurnStartEffect);
        Destroy(token.gameObject);

    }
}
