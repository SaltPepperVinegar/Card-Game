using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardHouse;
public class DeckSetup : MonoBehaviour
{


    public bool RunOnStart = true;
    public GameObject DisplayCardPrefab;
    public List<CardTemplate> Templates;
    public int copies = 2;
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

        var gameObjects = new List<GameObject>();

        foreach (CardTemplate template in Templates)
        {
            for (int i = 0; i < copies; i++)
            {
                var newThing = Instantiate(DisplayCardPrefab, Vector3.down * 10, Quaternion.identity);
                newThing.GetComponent<CardDisplay>().template = template;
                gameObjects.Add(newThing);

            }
        }
        yield return new WaitForEndOfFrame();


        CardGroup deck = GetComponent<CardGroup>();

        foreach (var newThing in gameObjects)
        {
            deck.Mount(newThing.GetComponent<CardHouse.Card>(), instaFlip: true, seekerSets: new SeekerSetList { new SeekerSet { Homing = homing, Turning = turning } });
        }
    

    }
}