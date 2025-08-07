namespace CardHouse
{
    //in what way the value should be interpolated
    public abstract class Seeker<T>
    {

        //start value of transitioning 
        protected T Start;
        //end value of transitioning 
        public T End;

        //return a copy of strategy instance
        public abstract Seeker<T> MakeCopy();
        //initiate transition 
        public void StartSeeking(T from, T to)
        {
            Start = from;
            End = to;
        }

        //interpolating function
        //retrun the next value in the transition
        public abstract T Pump(T currentValue, float TimeSinceLastFrame);
        //check if the transition has finished 
        public abstract bool IsDone(T currentValue);
    }
}
