using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
public class Spell : MonoBehaviour
{
    public LayerMask blockLayer;
    public SpellCard card;
    public int ownerPlayerId;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & blockLayer) != 0)
        {
            Block target = collision.GetComponent<Block>();

            if (target != null )
            {
                card.blocks.Add(target);
                Debug.Log(target);
                target.GetComponent<CreatureSelect>().Select(SelectState.Selected);
            }
        }


    }
    public void Init(SpellCard card, int ownerPlayerId)
    {
        this.ownerPlayerId = ownerPlayerId;
        this.card = card;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & blockLayer) != 0)
        {
            Block target = collision.GetComponent<Block>();
            if (target != null && card.blocks.Contains(target))
            {
                card.blocks.Remove(target);
                target.GetComponent<CreatureSelect>().Select(SelectState.Default);
                
            }

        }


    }

    void OnDestroy()
    {

        foreach (Block block in card.blocks)
        {
            block.GetComponent<CreatureSelect>().Select(SelectState.Default);

        }
    }

}

