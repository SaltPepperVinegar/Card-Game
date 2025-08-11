using System.Collections;
using System.Collections.Generic;
using CardHouse;
using Unity.Mathematics;
using UnityEngine;
public class Card : MonoBehaviour
{
    public CardTemplate template;
    public int ownerPlayerId;

    public ElementalCost[] elementalCosts;

    void Start()
    {
        elementalCosts = template.cost;
    }

    public void ApplyCost()
    {

        TokenManager.Instance.ApplyCost(elementalCosts);
    }
}

