using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpell : SpellEffect
{
    public int shieldAmount = 2;
    public override void CastSpell(List<Block> blocks, int spellCasterPlayerId)
    {
        foreach (Block block in blocks)
        {
            if (block.Occupied)
            {
                if (block.creature.ownerPlayerId == spellCasterPlayerId && !block.creature.isPlayer)
                {
                    Effect(block.creature);
                }
            }
        }
    }

    public override bool SpellApplicable(Block block, int spellCasterPlayerId)
    {
        if (block.Occupied && block.creature.ownerPlayerId == spellCasterPlayerId && !block.creature.isPlayer)
        {
            return true;
        }
        return false;
    }

    public void Effect(Creature creature)
    {
        ShieldedEffect shieldedEffect;

        if ((shieldedEffect = creature.GetComponent<ShieldedEffect>()) == null)
        {
            shieldedEffect = creature.gameObject.AddComponent<ShieldedEffect>();
        }
        shieldedEffect.ShieldValue += shieldAmount;

    }
}
