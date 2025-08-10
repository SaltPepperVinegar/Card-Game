using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsBar : MonoBehaviour
{
    public Transform statsBar;
    public GameObject statsIndicatorPrefab;

    public StatsToken AddStatToken(Stat stat)
    {
        GameObject instance = Instantiate(statsIndicatorPrefab, statsBar);
        instance.GetComponent<SpriteRenderer>().sprite
            = GetComponent<StatFinder>().FindSprite(stat);
        return instance.GetComponent<StatsToken>();
    }
}
