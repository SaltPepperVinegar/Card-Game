
using UnityEngine;
using UnityEngine.Events;

public class ActionPointManager : MonoBehaviour
{
    public static ActionPointManager Instance;
    public UnityEvent ActionPointRefill;

    void Awake()
    {
        Instance = this;
    }

    public void Invoke()
    {
        Debug.Log("Refill");

        ActionPointRefill?.Invoke();
    }

}
