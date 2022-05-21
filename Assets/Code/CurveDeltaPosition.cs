using Plugins.Inputs_master.Inputs_master.Unity.Axis.Keyboards;
using UnityEngine;

namespace Code
{
    public class CurveDeltaPosition : IValue<float>
    {
        private readonly AnimationCurve _curve;
        private readonly IValue<float> _deltaTime;
        
        private float _progress;

        public CurveDeltaPosition(AnimationCurve curve, IValue<float> deltaTime)
        {
            _curve = curve;
            _deltaTime = deltaTime;
        }

        public float Evaluate()
        {
            var previousCurveValue = _curve.Evaluate(_progress);
            _progress += _deltaTime.Evaluate();
            var currentCurveValue = _curve.Evaluate(_progress);

            var y = currentCurveValue - previousCurveValue;

            return y;
        }
    }
}