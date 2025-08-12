using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Creature))]
public class GameOver : Effect
{

    public void Start()
    {

        GetComponent<Creature>().PostBattleEffect.AddListener(OnDeathDestroy);
    }


    public void OnDeathDestroy(PostBattleParams battleParams)
    {


        if (GetComponent<Creature>().Health <= 0)
        {
            Destroy(DeckTransfer.Instance.gameObject);
        }
    }
    void OnDestroy()
    {
        Debug.Log("Player " + GetComponent<Creature>().ownerPlayerId + "Loss");
        SceneManager.LoadScene("End" + GetComponent<Creature>().ownerPlayerId);

    }
}