using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
public class EvolutionCard : Card
{
    void Start()
    {
        elementalCosts = template.cost;
    }
    public void CreatureEvolution()
    {
        CardHouse.CardGroup cardGroup = GetComponent<CardHouse.Card>()?.LastUsedOnGroup;
        Block block = cardGroup?.GetComponent<Block>();
        if (block != null)
        {
            block.creature.AddElement(template.element);
        }
    }

    public override bool CheckDropable(Block block)
    {
        if (block.Occupied
            && block.creature.ownerPlayerId == OwnerPlayerId
            && block.creature.CanAddElement(template.element))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

