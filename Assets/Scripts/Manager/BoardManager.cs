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
            if (creature.Interactable(target.creature) && target.creature.Interactable(creature))
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


    public void InteractWith(Creature source, Block targetBlock)
    {
        if (targetBlock.Occupied)
        {
            source.InteractEffect?.Invoke();

            Creature target = targetBlock.creature;

            PreBattleParams preBattleParams = new PreBattleParams();
            preBattleParams.source = source;
            preBattleParams.target = target;

            source.PreBattleEffect?.Invoke(preBattleParams);
            target.PreBattleEffect?.Invoke(new PreBattleParams(preBattleParams).Swap());

            PostBattleParams postBattleParams = ResolveAttack(source, target);
            
            source.PostBattleEffect?.Invoke(postBattleParams);
            target.PostBattleEffect?.Invoke(new PostBattleParams(postBattleParams).Swap());
        }
        else
        {
            source.InteractEffect?.Invoke();
            MoveToBlock(source, targetBlock);
        }
        
    }
    public PostBattleParams ResolveAttack(Creature source, Creature target)
    {
        PostBattleParams param = new PostBattleParams();
        param.source = source;
        param.target = target;
        param.damageToTarget = source.Attack;
        param.damageToSource = target.Attack;

        source.actionPoint -= 1;
        source.Health -= target.Attack;
        target.Health -= source.Attack;

        return param;
    }

    public void MoveToBlock(Creature creature, Block target)
    {

        creature.block?.LeaveBlock();
        creature.MoveToBlock(target);
        target.EnterBlock(creature);

    }


}
