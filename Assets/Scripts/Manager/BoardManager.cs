using System.Collections;
using System.Collections.Generic;
using CardHouse;
using Unity.VisualScripting;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public bool Interactable(Creature creature, Block target)
    {
        if (PhaseManager.Instance.CurrentPhase.Name != "P1Action"
        && PhaseManager.Instance.CurrentPhase.Name != "P2Action"
        )
        {
            return false;
        }
        if (target.Occupied)
        {
            if (creature.Interactable(target.creature))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    public void InteractWith(Creature creature, Block target)
    {
        if (target.Occupied)
        {
            creature.InteractWith(target.creature);
            creature.PostInteractionEffect?.Invoke();
            target.creature.PostInteractionEffect?.Invoke();
        }
        else
        {
            MoveToBlock(creature, target);
        }
        
    }


    public void MoveToBlock(Creature creature, Block target)
    {

        creature.block?.LeaveBlock();
        creature.MoveToBlock(target);
        target.EnterBlock(creature);

    }


}
