using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CreatureCardDisplay : CardDisplay
{


    public Transform elementBar;
    public GameObject elementIndicatorPrefab;

    public TextMeshPro CardName;
    public TextMeshPro Description;
    public TextMeshPro Health;
    public TextMeshPro Attack;

    public SpriteRenderer Image;
    public void Start()
    {
        foreach (var pair in template.cost)
        {
            AddElement(pair.element, pair.Cost);
        }
        CardName.text = template.CardName;
        Description.text = template.description;
        Health.text = template.health.ToString();
        Attack.text = template.attack.ToString();

        Image.sprite = template.sprite;



    }
    public void AddElement(Element element, int cost)
    {
        GameObject instance = Instantiate(elementIndicatorPrefab, elementBar);
        instance.GetComponent<SpriteRenderer>().color
            = GetComponent<ElementFinder>().FindColor(element);
        instance.GetComponent<StatsToken>().SetStat(cost);
    }



}
