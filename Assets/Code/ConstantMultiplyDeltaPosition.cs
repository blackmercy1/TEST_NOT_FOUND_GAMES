using UnityEngine;

namespace Code
{
    public class ConstantMultiplyDeltaPosition : DeltaPositionDecorator
    {
        private float _factor;

        public ConstantMultiplyDeltaPosition(IDeltaPosition childDeltaPosition,float factor) : base(childDeltaPosition)
        {
            _factor = factor;
        }

        public override Vector3 Evaluate()
        {
            var childDelta = ChildDeltaPosition.Evaluate();
            return childDelta * _factor;
        }
    }
}