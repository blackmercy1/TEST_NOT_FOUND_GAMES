using UnityEngine;

namespace Plugins.Inputs_master.Inputs_master.Unity.Direction
{
    public class ConstantDirection : IDirection<Vector2>
    {
        private readonly Vector2 _value;

        public ConstantDirection(Vector2 value)
        {
            _value = value;
        }

        public Vector2 Direction()
        {
            return _value;
        }
    }
}