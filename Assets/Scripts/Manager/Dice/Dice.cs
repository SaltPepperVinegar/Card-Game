using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ElementalDice : MonoBehaviour
{
    public Element element;
    public bool Selected = false;
    public GameObject Object;
    public bool rolling = false;
    public Element Roll()
    {
        int roll = Random.Range(0, 6);
        element = (Element)roll;
        GetComponent<Image>().color = GetComponent<ElementFinder>().FindColor(element);
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
