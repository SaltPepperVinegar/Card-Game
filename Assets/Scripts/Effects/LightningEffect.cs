using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Creature))]
public class LightningEffect : Effect
{
    void Start()
    {
        GetComponent<Creature>().actionPoint = 1;
    }
}
