using Plugins.Inputs_master.Inputs_master.Unity.Axis.Keyboards;
using UnityEngine;

namespace Code
{
    public class YDeltaPositionFromValue : IDeltaPosition
    {
        private IValue<float> _value;

        public YDeltaPositionFromValue(IValue<float> value)
        {
            _value = value;
        }

        public Vector3 Evaluate()
        {
            var y = _value.Evaluate();
            return new Vector3(0, y, 0);
        }
    }
}