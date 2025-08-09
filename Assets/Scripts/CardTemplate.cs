using System;
using System.Collections.Generic;
using System.Linq;
using CardHouse.SampleGames.DeckBuilder;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "CardTemplate", menuName = "Card/CardTemplate")]
public class CardTemplate : ScriptableObject
{
    [SerializeField] String name;
    [SerializeField] String description;
    [SerializeField] Element element;
    [SerializeField] int health;
    [SerializeField] int attack;
    [SerializeField] ElementalCost[] Cost;
    [SerializeField] CardTemplate upgrades;
    
}

[Serializable]
public class ElementalCost
{
    [SerializeField] Element element;
    [SerializeField] int Cost;
}
public enum Element
{
    fire, //反伤
    water, //隐身
    ice, //护盾
    electric, //迅捷
    rock, //嘲讽
    grass, //吸血

}