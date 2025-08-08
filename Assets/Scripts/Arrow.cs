using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    Creature creature;
    public Block block;
    public bool hitBlock => block != null;
    public LayerMask blockLayer;
    public void Init(Creature creature)
    {
        this.creature = creature;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & blockLayer) != 0)
        {

            if (collision.gameObject != creature.block.gameObject && !collision.GetComponent<Block>().Occupied)
            {
                if (block != null)
                {
                    block.GetComponent<CardHouse.SpriteColorOperator>().Change("Inactive");
                }
                block = collision.GetComponent<Block>();
                block.GetComponent<CardHouse.SpriteColorOperator>().Change("Active");
            }
        }


    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & blockLayer) != 0)
        {   
            collision.GetComponent<CardHouse.SpriteColorOperator>().Change("Inactive");

        }


    }

    void OnDisable()
    {
        block?.GetComponent<CardHouse.SpriteColorOperator>().Change("Inactive");
        block = null;
    }

}