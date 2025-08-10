using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ElementalDice : MonoBehaviour
{
    public Element element;
    public bool Selected = false;
    public GameObject Object;
    public Element Roll()
    {
        int roll = Random.Range(0, 5);
        element = (Element)roll;
        GetComponentInChildren<TextMeshProUGUI>().text = element.ToString();
        Selected = false;
        Object.SetActive(Selected);

        return element;
    }

    public void Select()
    {
        Selected = !Selected;
        Object.SetActive(Selected);
    }

}
