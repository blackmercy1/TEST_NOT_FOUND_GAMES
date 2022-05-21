using Plugins.Inputs_master.Inputs_master.Unity.Axis.Keyboards;
using UnityEngine;

namespace Code
{
    public class FluidMultiplyDeltaPosition : DeltaPositionDecorator
    {
        private readonly IValue<float> _factor;

        public FluidMultiplyDeltaPosition(IDeltaPosition childDeltaPosition, IValue<float> factor) : base(childDeltaPosition)
        {
            _factor = factor;
        }

        public override Vector3 Evaluate()
        {
            var childDelta = ChildDeltaPosition.Evaluate();
            return childDelta * _factor.Evaluate();
        }
    }
}