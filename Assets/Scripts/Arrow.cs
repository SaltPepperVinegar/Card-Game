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
            Block target = collision.GetComponent<Block>();

            if (
                collision.gameObject != creature.block.gameObject &&
                BoardManager.Instance.Interactable(creature, target)
                )
            {
                Debug.Log("off by selection");
                block?.Selected(false);
                block = target;
                block.Selected(true);
            }
        }


    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & blockLayer) != 0)
        {
            Debug.Log("off by exit");
            gameObject.GetComponent<Block>()?.Selected(false);

        }


    }

    void OnDisable()
    {

        block?.Selected(false);
        block = null;
    }

}