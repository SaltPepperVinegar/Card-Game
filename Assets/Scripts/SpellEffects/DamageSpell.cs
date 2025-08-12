using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSpell : SpellEffect
{
    public int damage = 2;
    public override void CastSpell(List<Block> blocks, int spellCasterPlayerId)
    {
        foreach (Block block in blocks)
        {
            if (block.Occupied)
            {
                if (block.creature.ownerPlayerId != spellCasterPlayerId )
                {
                    Creature creature = block.creature;
                    creature.Health -= damage;
                    if (creature.Health <= 0)
                    {
                        block.LeaveBlock();
                        Destroy(creature.gameObject);
                    }
                }
            }
        }
    }
    public override bool SpellApplicable(Block block, int spellCasterPlayerId)
    {
        if (block.Occupied && block.creature.ownerPlayerId != spellCasterPlayerId  && !block.creature.isPlayer)
        {
            return true;
        }
        return false;
    }

}
