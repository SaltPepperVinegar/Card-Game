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
    public String CardName;
    [TextArea(3, 10)] public String description;
    public Element element;
    public int health;
    public int attack;
    public ElementalCost[] cost;
    public Sprite sprite;
    public CreatureType creatureType;

    public CardType cardType;
    public int actionPoint = 1;

    public static bool ElementToScript(Element element, Creature creature)
    {
        Debug.Log("add componenet");
        switch (element)
        {
            case Element.Fire:
                if (creature.GetComponent<FireEffect>() == null)
                {
                    creature.AddComponent<FireEffect>();
                    return true;
                }
                return false;
            case Element.Water:
                if (creature.GetComponent<WaterEffect>() == null)
                {
                    creature.AddComponent<WaterEffect>();
                    return true;
                }
                return false;
            case Element.Earth:
                if (creature.GetComponent<EarthEffect>() == null)
                {
                    creature.AddComponent<EarthEffect>();
                    return true;
                }
                return false;
            case Element.Lightning:
                if (creature.GetComponent<LightningEffect>() == null)
                {
                    creature.AddComponent<LightningEffect>();
                    return true;
                }
                return false;
            case Element.Ice:
                if (creature.GetComponent<IceEffect>() == null)
                {
                    creature.AddComponent<IceEffect>();
                    return true;
                }
                return false;
            case Element.Grass:
                if (creature.GetComponent<GrassEffect>() == null)
                {
                    creature.AddComponent<GrassEffect>();
                    return true;
                }
                return false;
        }
        return false;
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


public enum CardType
{
    Creature,
    Enhancement,
    Spell,
}

public enum CreatureType
{
    Golem,
    Slime, 
    Bat
}