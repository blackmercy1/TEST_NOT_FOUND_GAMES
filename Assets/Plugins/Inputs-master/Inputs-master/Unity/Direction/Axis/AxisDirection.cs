using Plugins.Inputs_master.Inputs_master.Unity.Axis;
using Plugins.Inputs_master.Inputs_master.Unity.Axis.Keyboards;
using Plugins.Inputs_master.Inputs_master.Unity.Keys;
using UnityEngine;

namespace Plugins.Inputs_master.Inputs_master.Unity.Direction.Axis
{
    public class AxisDirection : IDirection<Vector2>
    {
        private readonly IAxis _xAxis;
        private readonly IAxis _yAxis;

        public AxisDirection() : this(
            KeyCode.A, KeyCode.D,
            KeyCode.S, KeyCode.W)
        {
        }

        public AxisDirection(KeyCode xNegative, KeyCode xPositive, KeyCode yNegative, KeyCode yPositive) : this(
            new ConstantRawKeyAxis(new Key(xNegative), new Key(xPositive)),
            new ConstantRawKeyAxis(new Key(yNegative), new Key(yPositive)))
        {
        }

        public AxisDirection(IAxis xAxis, IAxis yAxis)
        {
            _xAxis = xAxis;
            _yAxis = yAxis;
        }

        public Vector2 Direction()
        {
            var xDirection = _xAxis.Input();
            var yDirection = _yAxis.Input();

            return new Vector2(xDirection, yDirection);
        }
    }
}