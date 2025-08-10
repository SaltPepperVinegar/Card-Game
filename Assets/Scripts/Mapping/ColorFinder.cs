using UnityEngine;
public class ElementFinder : MonoBehaviour
{

    public ElementToColor map;
    public Color FindColor(Element element)
    {
        return map.GetColorForElement(element);
    }
}
