using UnityEngine;

namespace CardHouse
{
    //used for smoothly transitioning a value of type T over time use trategy based system
    public abstract class BaseSeekerComponent<T> : MonoBehaviour
    {
        /* 
        function to override 
        */

        //the default interpolation method 
        protected abstract Seeker<T> GetDefaultSeeker();

        //set what value you want to change e.g position/scale etc
        protected abstract T GetCurrentValue();

        //set what value you want to change e.g position/scale etc
        protected abstract void SetNewValue(T value);

        

        [Tooltip("assign the strategy in inspector, keep null if you want to use the default strategy")]
        public SeekerScriptable<T> Strategy;



        /*
            internal logics 
        */

        //current seeking strategy 
        protected Seeker<T> MyStrategy;

        protected bool IsSeeking;
        //if the local transform space is used. 
        protected bool UseLocalSpace;

        void Awake()
        {   
            //get the strategy assigned to in inspector, if no strategy is assigned, get the default strategy
            MyStrategy = Strategy?.GetStrategy() ?? GetDefaultSeeker();
        }
        //start the transition from From to TO.
        public void StartSeeking(T destination, Seeker<T> strategy = null, bool useLocalSpace = false)
        {
            IsSeeking = true;
            UseLocalSpace = useLocalSpace;
            //using a copy of strategy provided OR use inspector provided strategy OR use the default builtin strategy 
            MyStrategy = strategy?.MakeCopy() ?? Strategy?.GetStrategy() ?? GetDefaultSeeker();
            //from = GetCurrentValue,  to = destination
            MyStrategy.StartSeeking(GetCurrentValue(), destination);
        }

        void Update()
        {
            if (!IsSeeking)
                return;
            //get next interpolated value from current value
            var newValue = MyStrategy.Pump(GetCurrentValue(), Time.deltaTime);
            //set the new value 
            SetNewValue(newValue);
            //set the final value
            if (MyStrategy.IsDone(newValue))
            {
                SetNewValue(MyStrategy.End);
                IsSeeking = false;
            }
        }


    }
}
