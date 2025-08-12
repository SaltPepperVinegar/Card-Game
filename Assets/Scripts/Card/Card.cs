using System.Collections;
using System.Collections.Generic;
using CardHouse;
using Unity.Mathematics;
using UnityEngine;
public class Card : MonoBehaviour
{
    public CardTemplate template;
    private int ownerPlayerId = -1;

    public ElementalCost[] elementalCosts;

    public int OwnerPlayerId
    {
        get
        {
            if (ownerPlayerId == -1)
            {
                ownerPlayerId =  GroupRegistry.Instance
                .GetOwnerIndex(GetComponent<CardHouse.Card>().Group) ?? 0;

            }
            return ownerPlayerId;
        }
    } 

    void Start()
    {
        elementalCosts = template.cost;
    }

    public void ApplyCost()
    {

        TokenManager.Instance.ApplyCost(elementalCosts);
    }
    public virtual bool CheckDropable(Block block)
    {
        return true;
    }

}

