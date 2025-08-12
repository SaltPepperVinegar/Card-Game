using System.Collections;
using CardHouse;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(CardHouse.CardGroup))]
public class DeckBuildTracker : MonoBehaviour
{
    public int DeckCount = 10;
    public TextMeshProUGUI text;
    public Image image;
    private CardGroup group;
    public bool Confirm => DeckCount == group?.MountedCards?.Count ;
    public Color confirmColor;
    public Color unconfirmColor;

    public void Start()
    {
        group = GetComponent<CardGroup>();
        UpdateConfirm();
    }
    public void UpdateConfirm()
    {
        if (Confirm)
        {
            image.color = confirmColor;
            text.color = confirmColor;
        }
        else
        {
            image.color = unconfirmColor;
            text.color = unconfirmColor;
        }
        DeckTransfer.Instance.CheckValidity();
        if (group != null && group.MountedCards != null)
        {
            text.text = group.MountedCards.Count + " \\ " + DeckCount;
        }
    }

    void OnEnable()
    {
        UpdateConfirm();
    }
}
