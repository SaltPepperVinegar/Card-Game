using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Creature creature = null;
    public bool Occupied => creature != null;

    public void LeaveBlock()
    {
        creature = null;
    }

    public void EnterBlock(Creature creature)
    {
        if (this.creature != null) Debug.LogWarning("false enter");
        this.creature = creature;
    }

    public void Selected(bool active)
    {
        GetComponent<CardHouse.SpriteColorOperator>().Change(active? "Active" : "Inactive");
    }
}
