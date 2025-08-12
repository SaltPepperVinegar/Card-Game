using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpell : SpellEffect
{
    public override void CastSpell(List<Block> blocks, int spellCasterPlayerId)
    {
        foreach (Block block in blocks)
        {
            if (block.Occupied)
            {
                if (block.creature.ownerPlayerId != spellCasterPlayerId)
                {
                    block.LeaveBlock();
                    Destroy(block.creature.gameObject);
                }
            }
        }
    }

}
