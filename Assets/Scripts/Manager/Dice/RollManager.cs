using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RollManager : MonoBehaviour
{
    public static RollManager Instance;
    public List<ElementalDice> dices;
    [SerializeField] public int[] elements = new int[6];
    public int DiceCount => dices.Count;
    public int StartDiceCount;
    public GameObject dicePrefab;
    public Transform parentTransform;
    public int MaximunReroll = 3;
    public TextMeshProUGUI rerollCount;
    private int rerolls;    
    public int Rerolls { get{ return rerolls; } set { rerolls = value; rerollCount.text = "Rerolls: " + value.ToString();} }
    void Awake()
    {
        Instance = this;

    }
    void Start()
    {
        IncreaseDice(StartDiceCount - DiceCount);
    }
    public void Roll()
    {
        Rerolls = MaximunReroll;
        elements = new int[6];
        foreach (ElementalDice dice in dices)
        {

            elements[(int)dice.Roll()] += 1;
        }
    }

    public void ReRoll()
    {
        if (Rerolls <= 0)
        {
            return;
        }
        bool hasRerolled = false;
        foreach (ElementalDice dice in dices)
        {
            if (dice.Selected)
            {
                elements[(int)dice.element] -= 1;
                elements[(int)dice.Roll()] += 1;
                hasRerolled = true;
            }
        }
        if (hasRerolled) Rerolls -= 1;
    }

    public void IncreaseDice(int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject dice = Instantiate(dicePrefab, parentTransform);
            dices.Add(dice.GetComponent<ElementalDice>());
        }
    }
    public void DecreaseDice(int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            // Remove the last dice in the list (reverse iteration)
            if (dices.Count > 0)
            {
                ElementalDice diceToRemove = dices[dices.Count - 1];
                dices.RemoveAt(dices.Count - 1);
                Destroy(diceToRemove.gameObject);
            }
        }
    }

    public void Transfer()
    {
        TokenManager.Instance.Init(elements);
    }
}
