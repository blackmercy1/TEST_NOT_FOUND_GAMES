using UnityEngine;

namespace Plugins.Inputs_master.Inputs_master.Unity.Direction.Mouse
{
    public class MouseDirection : IDirection<Vector2>
    {
        private Vector3 _lastMousePosition;

        public MouseDirection()
        {
            _lastMousePosition = Input.mousePosition;
        }

        public Vector2 Direction()
        {
            var currentMousePosition = Input.mousePosition;
            var direction = currentMousePosition - _lastMousePosition;

            _lastMousePosition = currentMousePosition;

            return direction;
        }
    }
}