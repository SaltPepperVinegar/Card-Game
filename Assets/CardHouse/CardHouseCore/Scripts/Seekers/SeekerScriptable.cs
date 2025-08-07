using UnityEngine;

namespace CardHouse
{
    public abstract class SeekerScriptable<T> : ScriptableObject
    {
        //This is a factory method intended to construct or configure a Seeker<T> instance using optional arguments.
        public abstract Seeker<T> GetStrategy(params object[] args);
    }
}
