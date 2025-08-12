using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSelect : MonoBehaviour
{
    public GameObject cover;
    public Color Selected;
    public Color Inactive;
    public void Select(SelectState state)
    {
        switch (state)
        {
            case SelectState.Selected:
                cover.gameObject.SetActive(true);

                cover.GetComponent<SpriteRenderer>().color = Selected;
                return;
            case SelectState.Inactive:
                cover.gameObject.SetActive(true);

                cover.GetComponent<SpriteRenderer>().color = Inactive;
                return;
            case SelectState.Default:
                cover.gameObject.SetActive(false);

                return;
        }
    }

}

public enum SelectState
{
    Selected,
    Inactive,
    Default,
}