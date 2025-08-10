using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Creature))]
public class FreezedEffect : Effect
{

    public int freezesTurns = 1;
    void Start()
    {
        GetComponent<Creature>().TurnStartEffect.AddListener(TurnStartEffect);

    }

    public void TurnStartEffect()
    {
        if (freezesTurns <= 0)
        {
            Destroy(this);
            return;
        }

        freezesTurns -= 1;
        GetComponent<Creature>().actionPoint = 0;
    }

    void OnDestroy()
    {
        GetComponent<Creature>().TurnStartEffect.RemoveListener(TurnStartEffect);

    }
}
