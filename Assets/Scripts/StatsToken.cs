using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsToken : MonoBehaviour
{
    public TextMeshPro text;
    public void SetStat(int amount)
    {
        text.text = amount.ToString();
    }
}
