using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ElementColor", menuName = "Card/ElementColor")]
public class ElementToColor : ScriptableObject
{
    // Dictionary to map each Element to a color
    public Color fireColor = Color.red;
    public Color waterColor = Color.blue;
    public Color earthColor = Color.green;
    //public Color airColor = Color.cyan;
    public Color lightningColor = Color.yellow;
    public Color iceColor = Color.white;
    public Color grassColor = Color.green;

    // Method to get the color for a specific element
    public Color GetColorForElement(Element element)
    {
        switch (element)
        {
            case Element.Fire:
                return fireColor;
            case Element.Water:
                return waterColor;
            case Element.Earth:
                return earthColor;
            case Element.Lightning:
                return lightningColor;
            case Element.Ice:
                return iceColor;
            case Element.Grass:
                return grassColor;
            default:
                return Color.black; // Default color if no match
        }
    }
}