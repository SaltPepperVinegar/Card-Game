using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    void Awake()
    {
        Instance = this;

    }
    void Start()
    {
        IncreaseDice(StartDiceCount - DiceCount);
        Roll();
    }
    public void Roll()
    {
        elements = new int[6];
        foreach (ElementalDice dice in dices)
        {

            elements[(int)dice.Roll()] += 1;
        }
    }

    public void ReRoll()
    {
        foreach (ElementalDice dice in dices)
        {
            if (dice.Selected)
            {
                elements[(int)dice.element] -= 1;
                elements[(int)dice.Roll()] += 1;

            }
        }
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
