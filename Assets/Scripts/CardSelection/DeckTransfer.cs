using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardHouse;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DeckTransfer : MonoBehaviour
{
    public List<List<CardTemplate>> Data;
    public static DeckTransfer Instance;
    [SerializeField] private List<CardHouse.CardGroup> GroupsToTransfer;
    public Image image;
    public Color inactiveColor;
    public Color activeColor;
    public DeckBuildTracker[] trackers;
    public string LevelTransferTo;
    void Awake()
    {
        Instance = this;
        image.color = inactiveColor;
    }
    void Start()
    {
        Data = new List<List<CardTemplate>>();
        DontDestroyOnLoad(gameObject);
    }

    public bool CheckValidity()
    {
        foreach (var tracker in trackers)
        {
            if (!tracker.Confirm)
            {
                image.color = inactiveColor;
                return false;
            } 

        }
        image.color = activeColor;
        return true;

    }
    public void SaveDeck()
    {
        if (!CheckValidity()) { Debug.Log("unload"); return; }
        int i = 0;
        foreach (CardHouse.CardGroup cardGroup in GroupsToTransfer)
        {
            Data.Add(new List<CardTemplate>());
            List<CardTemplate> CurrentList = Data[i];
            foreach (CardHouse.Card card in cardGroup.MountedCards)
            {
                CurrentList.Add(card.GetComponent<CardDisplay>().template);

            }
            i++;
        }
        Debug.Log("load");
        LoadScene(LevelTransferTo);
    }
    public void FinishLoad()
    {
        Destroy(gameObject);
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
