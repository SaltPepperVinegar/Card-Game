using UnityEngine.Events;
using UnityEngine.Serialization;

namespace CardHouse
{
    public class DragDetector : Toggleable
    {
        // used to check if drag is allowed 
        public GateCollection<NoParams> DragGates;
        //used to serialize the unity events that will call when the drag starts in editor
        public UnityEvent OnDragStart;

        [FormerlySerializedAs("DropGates")]
        //control whether the card can be dropped into a specific group 
        public GateCollection<DropParams> GroupDropGates;
        //control whether the dragged card can target another card
        public GateCollection<TargetCardParams> TargetCardGates;
        //used to serialize the unity events that will call when the drag ends, in editor
        public UnityEvent OnDragEnd;


        //requires collider2D
        void OnMouseDown()
        {   

            if (!IsActive || !DragGates.AllUnlocked(null))
                return;

            OnDragStart.Invoke();
        }

        void OnMouseUp()
        {
            if (!IsActive || !DragGates.AllUnlocked(null))
                return;

            OnDragEnd.Invoke();
        }
    }
}
