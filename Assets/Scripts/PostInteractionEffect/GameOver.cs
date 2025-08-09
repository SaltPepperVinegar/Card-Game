using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Creature))]
public class GameOver : Effect
{
    
    public void Start()
    {
        //GetComponent<Creature>().PostInteractionEffect.AddListener(OnDeathDestroy);
    }


    public void OnDeathDestroy()
    {


        if (GetComponent<Creature>().Health <= 0)
        {
            Debug.Log("Player " + GetComponent<Creature>().ownerPlayerId + "Loss");
        }
    } 
}