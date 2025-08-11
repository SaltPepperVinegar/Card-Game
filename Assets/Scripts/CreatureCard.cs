using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
public class CreatureCard : Card
{
    public GameObject creaturePrefab;

    void Start()
    {
        elementalCosts = template.cost;
    }
    public void InstantiateCreature()
    {
        CardHouse.GroupRegistry registry = CardHouse.GroupRegistry.Instance;

        ownerPlayerId =(int) registry.GetOwnerIndex(GetComponent<CardHouse.Card>().Group);

        CardHouse.CardGroup cardGroup = GetComponent<CardHouse.Card>()?.LastUsedOnGroup;
        Block block = cardGroup?.GetComponent<Block>();
        if (block != null)
        {
            GameObject card = Instantiate(creaturePrefab, block.transform.position, quaternion.identity);
            Creature creature = card.GetComponent<Creature>();
            creature.Init(template, block, ownerPlayerId);
        }
    }

}

