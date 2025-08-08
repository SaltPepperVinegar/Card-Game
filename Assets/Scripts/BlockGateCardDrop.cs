using UnityEngine;

namespace CardHouse
{
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
            return !GetComponent<Block>().Occupied;
        }
    }
}
