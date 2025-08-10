
using UnityEngine;

public class StatFinder : MonoBehaviour
{

    public StatsToSprite map;
    public Sprite FindSprite(Stat stat)
    {
        return map.GetSpriteForStat(stat);
    }
}
