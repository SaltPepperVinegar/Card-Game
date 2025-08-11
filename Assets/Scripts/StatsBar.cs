using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsBar : MonoBehaviour
{
    public Transform statsBar;
    public GameObject statsIndicatorPrefab;
    public List<StatsToken> statsTokens = new List<StatsToken>();

    public StatsToken AddStatToken(Stat stat)
    {
        if (statsTokens.Count == 0) statsBar.gameObject.SetActive(true);
        GameObject instance = Instantiate(statsIndicatorPrefab, statsBar);
        instance.GetComponent<SpriteRenderer>().sprite
            = GetComponent<StatFinder>().FindSprite(stat);
        StatsToken token = instance.GetComponent<StatsToken>();
        statsTokens.Add(token);
        return token;
    }

    public void RemoveStatToken(StatsToken statsToken)
    {
        statsTokens.Remove(statsToken);
        Destroy(statsToken.gameObject);
        if (statsTokens.Count == 0) statsBar.gameObject.SetActive(false);

    }
}
