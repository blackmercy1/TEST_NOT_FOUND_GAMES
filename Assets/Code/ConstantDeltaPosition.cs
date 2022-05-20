using UnityEngine;

namespace Code
{
    public class ConstantDeltaPosition : IDeltaPosition
    {
        private Vector3 _delta;
        
        public ConstantDeltaPosition(Vector3 delta)
        {
            _delta = delta;
        }

        public Vector3 Evaluate()
        {
            return _delta;
        }
    }
}