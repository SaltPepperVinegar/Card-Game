using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardHouse;
public class CardSetup : MonoBehaviour
{
[System.Serializable]
    public struct GroupPopulationData
    {
        public CardGroup Group;
        public GameObject CardPrefab;
        public int CardCount;

    }

    public bool RunOnStart = true;

    public List<GroupPopulationData> GroupPopulationList;

    public List<CardGroup> GroupsToShuffle;

    public List<TimedEvent> OnSetupCompleteEventChain;

    public List<CardGroup> GroupsToTransferDeck;
    public GameObject TransferCardPrefab;
    void Start()
    {
        if (RunOnStart)
        {
            DoSetup();
        }
    }

    public void DoSetup()
    {
        StartCoroutine(SetupCoroutine());
    }
    
    IEnumerator SetupCoroutine()
    {
        var homing = new InstantVector3Seeker();
        var turning = new InstantFloatSeeker();
        var newThingDict = new Dictionary<GroupPopulationData, List<GameObject>>();
        foreach (var group in GroupPopulationList)
        {
            newThingDict[group] = new List<GameObject>();
            for (var i = 0; i < group.CardCount; i++)
            {
                var newThing = Instantiate(group.CardPrefab, Vector3.down * 10, Quaternion.identity);
                newThingDict[group].Add(newThing);
            }
        }
        var tranferThingDict = new Dictionary<CardGroup, List<GameObject>>();
        if (DeckTransfer.Instance != null)
        {
            List<List<CardTemplate>> Data = DeckTransfer.Instance.Data;
            int j = 0;
            foreach (CardGroup group in GroupsToTransferDeck)
            {
                if (!tranferThingDict.ContainsKey(group)) { tranferThingDict[group] = new List<GameObject>(); }

                foreach (CardTemplate template in Data[j])
                {
                    var newThing = Instantiate(TransferCardPrefab, Vector3.down * 10, Quaternion.identity);
                    newThing.GetComponent<CardDisplay>().template = template;
                    newThing.GetComponent<Card>().template = template;
                    tranferThingDict[group].Add(newThing);
                }
            }
            DeckTransfer.Instance.FinishLoad();
        }
        
        yield return new WaitForEndOfFrame();

        foreach (var kvp in newThingDict)
        {
            foreach (var newThing in kvp.Value)
            {
                kvp.Key.Group.Mount(newThing.GetComponent<CardHouse.Card>(), instaFlip: true, seekerSets: new SeekerSetList { new SeekerSet { Homing = homing, Turning = turning } });
            }
        }

        foreach (var kvp in tranferThingDict)
        {
            foreach (var newThing in kvp.Value)
            {
                kvp.Key.Mount(newThing.GetComponent<CardHouse.Card>(), instaFlip: true, seekerSets: new SeekerSetList { new SeekerSet { Homing = homing, Turning = turning } });
            }
        }

        foreach (var group in GroupsToShuffle)
        {
            group.Shuffle(true);
        }

        StartCoroutine(TimedEvent.ExecuteChain(OnSetupCompleteEventChain));
    }
}