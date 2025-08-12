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