using UnityEngine;


public class TokenGate : CardHouse.Gate<CardHouse.NoParams>
{
    Card MyCost;

    void Awake()
    {
        MyCost = GetComponent<Card>();
    }

    protected override bool IsUnlockedInternal(CardHouse.NoParams gateParams)
    {
        foreach (var pair in MyCost.elementalCosts)
        {
            int amountPlayerHas = TokenManager.Instance.GetTokenAmount((int) pair.element);
            if (amountPlayerHas < pair.Cost)
            {
                return false;
            }
        }
        return true;
    }
}

