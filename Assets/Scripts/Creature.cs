using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public CardTemplate template;
    public int currentHealth;
    public int currentAttack;
    public int ownerPlayerId;

    public Block block;

    public int actionPoint = 1;

    public void Init(CardTemplate template, Block block, int Id)
    {
        this.template = template;
        this.block = block;
        block.EnterBlock(this);
        this.ownerPlayerId = Id;
        gameObject.transform.position = block.transform.position;
    }




    //check perform on the initiator action
    public bool Interactable(Creature creature)
    {
        if (creature.ownerPlayerId != ownerPlayerId)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void InteractWith(Creature creature)
    {
        
    }

    public void MoveToBlock(Block target)
    {

        gameObject.transform.position = target.transform.position;
        block = target;
    }

    public bool ReadyToAction()
    {
        if (CardHouse.PhaseManager.Instance.CurrentPlayer == ownerPlayerId)
        {
            if (actionPoint >= 0)
            {
                return true;
            }
        }
        return false;
    }
}
