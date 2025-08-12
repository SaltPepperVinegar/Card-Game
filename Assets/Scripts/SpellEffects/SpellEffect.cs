using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEffect : MonoBehaviour
{
    public virtual void CastSpell(List<Block> blocks, int spellCaster)
    {

    }

    public virtual bool SpellApplicable(Block block, int spellCasterPlayerId)
    {
        return true;
    }
}
