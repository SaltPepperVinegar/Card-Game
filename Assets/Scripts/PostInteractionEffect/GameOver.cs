using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Creature))]
public class GameOver : MonoBehaviour
{
    public void OnDeathDestroy()
    {
        if (GetComponent<Creature>().Health <= 0)
        {
            Debug.Log("Player " + GetComponent<Creature>().ownerPlayerId + "Loss");
        }
    } 
}