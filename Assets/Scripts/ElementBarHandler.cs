using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementBarHandler : MonoBehaviour
{
    public Transform elementBar;
    public GameObject elementIndicatorPrefab;

    public void AddElement(Element element)
    {
        GameObject instance = Instantiate(elementIndicatorPrefab, elementBar);
        instance.GetComponent<SpriteRenderer>().color
            = GetComponent<ElementFinder>().FindColor(element);
    }
}
