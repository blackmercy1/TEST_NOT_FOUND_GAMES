using UnityEngine;

namespace Code
{
    public abstract class DeltaPositionDecorator : IDeltaPosition
    {
        protected readonly IDeltaPosition ChildDeltaPosition;

        protected DeltaPositionDecorator(IDeltaPosition childDeltaPosition)
        {
            ChildDeltaPosition = childDeltaPosition;
        }

        public abstract Vector3 Evaluate();
    }
}