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
                Debug.Log("set selected");
                cover.gameObject.SetActive(true);
                Debug.Log("After SetActive(true), cover active: " + cover.activeSelf);

                cover.GetComponent<SpriteRenderer>().color = Selected;
                return;
            case SelectState.Inactive:
                Debug.Log("set inactive");
                cover.gameObject.SetActive(true);
                Debug.Log("After SetActive(true), cover active: " + cover.activeSelf);

                cover.GetComponent<SpriteRenderer>().color = Inactive;
                return;
            case SelectState.Default:
                cover.gameObject.SetActive(false);
                Debug.Log("After SetActive(true), cover active: " + cover.activeSelf);

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