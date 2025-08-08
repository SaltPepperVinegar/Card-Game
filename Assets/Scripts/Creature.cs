using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public CardTemplate template;
    public int currentHealth;
    public int currentAttack;
    public int ownerPlayerId;

    public Block block;

    public void Init(CardTemplate template, Block block, int Id)
    {
        this.template = template;
        this.block = block;
        block.EnterBlock(this);
        this.ownerPlayerId = Id;
        gameObject.transform.position = block.transform.position;
    }

    public void MoveToBlock(Block to)
    {

        block?.LeaveBlock();
        gameObject.transform.position = to.transform.position;
        block = to;
        to.EnterBlock(this);
    }
}
