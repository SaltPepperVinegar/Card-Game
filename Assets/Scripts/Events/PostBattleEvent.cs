
using UnityEngine;
using UnityEngine.Events;

public class PostBattleEvent : UnityEvent<PostBattleParams>
{
}

public class PostBattleParams
{
    public Creature target;
    public Creature source;
    public int damageToTarget;
    public int damageToSource;
    public bool IsInitiator = true;
    public PostBattleParams() { }

    //swap target and source
    public PostBattleParams(PostBattleParams battleParams)
    {
        this.target = battleParams.target;
        this.source = battleParams.source;
        this.damageToTarget = battleParams.damageToTarget;
        this.damageToSource = battleParams.damageToSource;
        IsInitiator = battleParams.IsInitiator;

    }

    public PostBattleParams Swap()
    {
        IsInitiator = !IsInitiator;
        return this;
    }
}