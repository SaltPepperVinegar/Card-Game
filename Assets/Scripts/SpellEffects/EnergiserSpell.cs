using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergiserSpells : SpellEffect
{
    public int ActionPointRefill = 1;
    public override void CastSpell(List<Block> blocks, int spellCasterPlayerId)
    {
        foreach (Block block in blocks)
        {
            if (block.Occupied)
            {
                if (block.creature.ownerPlayerId == spellCasterPlayerId  && !block.creature.isPlayer)
                {
                    block.creature.ActionPoint = ActionPointRefill;
                }
            }
        }
    }
    public override bool SpellApplicable(Block block, int spellCasterPlayerId)
    {
        if (block.Occupied && block.creature.ownerPlayerId == spellCasterPlayerId  && !block.creature.isPlayer)
        {
            return true;
        }
        return false;
    }
}
