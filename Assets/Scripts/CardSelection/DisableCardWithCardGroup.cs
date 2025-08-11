using System;
using System.Collections;
using System.Collections.Generic;
using CardHouse;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(CardHouse.CardGroup))]
public class DisableCardWithCardGroup : MonoBehaviour
{
    void OnDisable()
    {
        foreach (CardHouse.Card card in GetComponent<CardGroup>().MountedCards)
        {
            if(card!= null) card.gameObject.SetActive(false);
        }
    }
    void OnEnable()
    {
        foreach (CardHouse.Card card in GetComponent<CardGroup>().MountedCards) {
            if(card!= null) card.gameObject.SetActive(true);
        }
    }
}
