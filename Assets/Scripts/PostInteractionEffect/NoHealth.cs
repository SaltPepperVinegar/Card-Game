using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Creature))]
public class NoHealth : Effect
{
    public void Start()
    {
        GetComponent<Creature>().PostBattleEffect.AddListener(OnDeathDestroy);
    }

    public void OnDeathDestroy(PostBattleParams battleParams)
    {
        if (GetComponent<Creature>().Health <= 0)
        {
            Destroy(gameObject);
        }
    } 
}