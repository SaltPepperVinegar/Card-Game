using System;
using System.Collections.Generic;
using System.Linq;
using CardHouse.SampleGames.DeckBuilder;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "CardTemplate", menuName = "Card/CardTemplate")]
public class CardTemplate : ScriptableObject
{
    public String name;
    public String description;
    public Element element;
    public int health;
    public int attack;
    public ElementalCost[] cost;
    public CardTemplate upgrades;
    public Effect[] effects;
    public int moveCost;
    public int actionPoint = 1;

    public static void ElementToScript(Element element, Creature creature)
    {
        Debug.Log("add componenet");
        switch (element)
        {
            case Element.Fire:
                creature.AddComponent<FireEffect>();
                return;
            case Element.Water:
                creature.AddComponent<WaterEffect>();
                return;
            case Element.Earth:
                creature.AddComponent<EarthEffect>();
                return;
            case Element.Lightning:
                creature.AddComponent<LightningEffect>();
                return;
            case Element.Ice:
                creature.AddComponent<IceEffect>();
                return;
            case Element.Grass:
                creature.AddComponent<GrassEffect>();
                return;
        }
    }   
}

[Serializable]
public class ElementalCost
{
    public Element element;
    public int Cost;
}
public enum Element
{
    Fire, //加伤害
    Water, //隐身
    Earth, //护盾
    Lightning, //迅捷
    Ice, //冷冻
    Grass //吸血
}

