using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ColorFinder : MonoBehaviour
{

    public ElementToColor map;
    public Color Find(Element element)
    {
        return map.GetColorForElement(element);
    }
}
