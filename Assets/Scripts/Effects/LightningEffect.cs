using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Creature))]
public class LightningEffect : Effect
{
    void Start()
    {
        Refresh();
    }
    public override void Refresh()
    {
        GetComponent<Creature>().actionPoint = 1;
    }
}
