using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ColorFinder))]
public class Token : MonoBehaviour
{
    public Element element;
    [SerializeField] Image image;
    public void SetElement(Element element)
    {
        this.element = element;
        image.color = GetComponent<ColorFinder>().Find(element);
    }

    public void Update()
    {
        SetElement(element);
    }
}
