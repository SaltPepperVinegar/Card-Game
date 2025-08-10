
using UnityEngine;

[CreateAssetMenu(fileName = "StatsToSprite", menuName = "Card/StatsToSprite")]
public class StatsToSprite : ScriptableObject
{
    // Dictionary to map each Element to a color
    public Sprite shieldSprite;
    public Sprite freezeSprite;



    // Method to get the color for a specific element
    public Sprite GetSpriteForStat(Stat stat)
    {
        switch (stat)
        {
            case Stat.Shield:
                return shieldSprite;
            case Stat.Freeze:
                return freezeSprite;
        }
        return null;
    }
}

public enum Stat
{
    Shield,
    Freeze,
}