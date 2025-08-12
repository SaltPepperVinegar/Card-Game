using UnityEngine;
using CardHouse;

[RequireComponent(typeof(CardGroup))]
[RequireComponent(typeof(Block))]

public class BlockCardDrop : Gate<DropParams>
{
    CardGroup MyGroup;

    void Awake()
    {
        MyGroup = GetComponent<CardGroup>();
    }

    protected override bool IsUnlockedInternal(DropParams gateParams)
    {
        Card card = gateParams.Card.GetComponent<Card>();
        Block block = GetComponent<Block>();
        if (card != null && block != null)
        {
            return card.CheckDropable(block);
        }
        
        return true;
    }
}
