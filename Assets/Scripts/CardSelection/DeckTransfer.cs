using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardHouse;
using UnityEngine.SceneManagement;
public class DeckTransfer : MonoBehaviour
{
    public List<List<CardTemplate>> Data;
    public static DeckTransfer Instance;
    [SerializeField] private List<CardHouse.CardGroup> GroupsToTransfer;
    public string LevelTransferTo;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Data = new List<List<CardTemplate>>();
        DontDestroyOnLoad(gameObject);
    }

    public void SaveDeck()
    {
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
