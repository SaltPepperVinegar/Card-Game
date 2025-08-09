using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Creature))]
public class NoHealth : Effect
{
    public void Start()
    {
        //GetComponent<Creature>().PostInteractionEffect.AddListener(OnDeathDestroy);
    }

    public void OnDeathDestroy()
    {
        if (GetComponent<Creature>().Health <= 0)
        {
            Destroy(gameObject);
        }
    } 
}