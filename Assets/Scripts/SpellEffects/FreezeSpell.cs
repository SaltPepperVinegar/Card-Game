using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeSpell : SpellEffect
{
    public int freezesTurns = 2;
    public override void CastSpell(List<Block> blocks, int spellCasterPlayerId)
    {
        foreach (Block block in blocks)
        {
            if (block.Occupied)
            {
                if (block.creature.ownerPlayerId != spellCasterPlayerId)
                {
                    freezeEffect(block.creature);
                }
            }
        }
    }

    public void freezeEffect(Creature creature)
    {
        FreezedEffect freezedEffect;
        if ((freezedEffect = creature.GetComponent<FreezedEffect>()) == null)
        {
            freezedEffect = creature.gameObject.AddComponent<FreezedEffect>();
            freezedEffect.FreezesTurns = freezesTurns;
            return;
        }
            freezedEffect.Refresh();
        freezedEffect.FreezesTurns = freezesTurns;

    }
}
