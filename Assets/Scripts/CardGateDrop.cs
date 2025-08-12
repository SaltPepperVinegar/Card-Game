using UnityEngine;
using CardHouse;

[RequireComponent(typeof(CardGroup))]
public class CardGateDrop : Gate<DropParams>
{
    CardGroup MyGroup;

    void Awake()
    {
        MyGroup = GetComponent<CardGroup>();
    }

    protected override bool IsUnlockedInternal(DropParams gateParams)
    {
        return true;

    }
}
