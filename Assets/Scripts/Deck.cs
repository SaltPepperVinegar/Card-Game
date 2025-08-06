using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Deck : MonoBehaviour
{
    List<Card> MountedCards = new List<Card>();
    [SerializeField] private Hand hand;
    public int ownerplayerId;
    public int Count => MountedCards.Count;
    public Card[] Draw(int amount)
    {
        if (MountedCards.Count >= amount)
        {
            Card[] drawnCards = new Card[amount];
            for (int i = 0; i < amount; i++)
            {
                drawnCards[i] = MountedCards[0];
                MountedCards.RemoveAt(0);
            }
            return drawnCards;
        }

        return null;
    }

    public void Insert(Card card, int? index = null)
    {
        if (index == null || index >= MountedCards.Count)
        {
            MountedCards.Add(card); // Insert at the end
        }
        else if (index < 0)
        {
            MountedCards.Insert(0, card); // Insert at the beginning
        }
        else
        {
            MountedCards.Insert((int)index, card); // Insert at the given index
        }
    }

}
