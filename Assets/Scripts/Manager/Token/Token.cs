using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ElementFinder))]
public class Token : MonoBehaviour
{
    public Element element;
    [SerializeField] Image image;
    public void SetElement(Element element)
    {
        this.element = element;
        image.color = GetComponent<ElementFinder>().FindColor(element);
    }

    public void Update()
    {
        SetElement(element);
    }
}
