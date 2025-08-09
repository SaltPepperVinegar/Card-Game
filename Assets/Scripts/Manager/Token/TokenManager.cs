using System;
using System.Collections;
using System.Collections.Generic;
using CardHouse;
using UnityEngine;

public class TokenManager : MonoBehaviour
{

    public static TokenManager Instance;
    void Awake()
    {
        Instance = this;
    }
    public GameObject tokenPrefab;
    public Transform parentTransform;
    public Action<int> OnTokenChange;

    public Wallet[] playerWallets = new Wallet[2]
    {
        new Wallet(),
        new Wallet()
    };
    public List<Token>[] Tokens {
        get
        {
            return playerWallets[PhaseManager.Instance.CurrentPlayer].tokens;

        }
    }
    public void Init(int[] elements)
    {
        for (int i = 0; i < elements.Length; i++)
        {
            for (int j = 0; j < elements[i]; j++)
            {
                Element element = (Element)i;
                GameObject instance = Instantiate(tokenPrefab, parentTransform);
                Token token = instance.GetComponent<Token>();
                token.SetElement(element);
                Tokens[i].Add(token);
            }
        }
    }

    public void Clear()
    {
        int playerId = PhaseManager.Instance.CurrentPlayer;
        foreach (List<Token> element in playerWallets[playerId].tokens)
        {
            foreach (Token token in element)
            {
                Destroy(token.gameObject);
            }
            element.Clear();

        }
    }

    public int GetTokenAmount(int element, int? playerId = null)
    {
        playerId ??= PhaseManager.Instance.CurrentPlayer;

        return playerWallets[(int)playerId].tokens[element].Count;
    }

    public void ApplyCost(ElementalCost[] elementalCosts)
    {
        foreach (var pair in elementalCosts)
        {
            List<Token> tokens = Tokens[(int)pair.element];
            for (int i = 0; i < pair.Cost; i++)
            {
                int lastElement = tokens.Count - 1;
                Token token = tokens[lastElement];
                Destroy(token.gameObject);
                Tokens[(int)pair.element].RemoveAt(lastElement);
            }

        }
        OnTokenChange?.Invoke(PhaseManager.Instance.CurrentPlayer);

    }
}

public class Wallet
{
    public List<Token>[] tokens = new List<Token>[6]; // Initialize Elements to the size of your enum

    public Wallet()
    {
        for (int i = 0; i < tokens.Length; i++)
        {
            tokens[i] = new List<Token>();
        }
    }
}