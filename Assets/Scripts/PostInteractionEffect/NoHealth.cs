using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Creature))]
public class NoHealth : MonoBehaviour
{
    public void OnDeathDestroy()
    {
        if (GetComponent<Creature>().Health <= 0)
        {
            Destroy(gameObject);
        }
    } 
}