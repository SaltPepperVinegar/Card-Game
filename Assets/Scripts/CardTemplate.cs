using System;
using System.Collections.Generic;
using System.Linq;
using CardHouse.SampleGames.DeckBuilder;
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
    
}

[Serializable]
public class ElementalCost
{
    public Element element;
    public int Cost;
}
public enum Element
{
    Fire, //反伤
    Water, //隐身
    Earth, //护盾
    Lightning, //迅捷
    Ice, //冷冻
    Grass //吸血
}

