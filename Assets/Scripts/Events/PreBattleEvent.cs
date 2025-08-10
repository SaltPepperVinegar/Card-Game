
using UnityEngine;
using UnityEngine.Events;

public class PreBattleEvent : UnityEvent<PreBattleParams>
{
}

public class PreBattleParams
{
    public Creature target;
    public Creature source;
    
    public bool IsInitiator = true;

    public PreBattleParams() { }

    //swap target and source
    public PreBattleParams(PreBattleParams battleParams)
    {
        this.target = battleParams.target;
        this.source = battleParams.source;
        IsInitiator = battleParams.IsInitiator;
    }

    public PreBattleParams Swap()
    {

        IsInitiator = !IsInitiator;
        return this;
    }
}