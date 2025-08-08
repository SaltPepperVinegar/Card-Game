using System.Collections;
using System.Collections.Generic;
using CardHouse;
using Unity.Mathematics;
using UnityEngine;
public class Card : MonoBehaviour
{
    public CardTemplate template;
    public int ownerPlayerId;

    public int modifiedCost;
    public GameObject cardPrefab;

    public void InstantiateCreature()
    {
        CardHouse.CardGroup cardGroup = GetComponent<CardHouse.Card>()?.LastUsedOnGroup;
        Block block = cardGroup?.GetComponent<Block>();
        if (block != null)
        {
            GameObject card = Instantiate(cardPrefab, block.transform.position,quaternion.identity);
            Creature creature = card.AddComponent<Creature>();
            ownerPlayerId = PhaseManager.Instance.CurrentPlayer;
            creature.Init(template, block, ownerPlayerId);
        }
    }
}

