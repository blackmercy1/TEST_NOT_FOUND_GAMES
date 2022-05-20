using System;
using Plugins.Inputs_master.Inputs_master.Unity.Axis.Decorators;
using Plugins.Inputs_master.Inputs_master.Unity.Axis.Keyboards;
using UnityEngine;

namespace Plugins.Inputs_master.Inputs_master.Unity.Direction.Decorator
{
    public class FluidClampDirection : DirectionDecorator<Vector2>
    {
        private readonly IRange<IValue<float>> _numbers;

        public FluidClampDirection(IDirection<Vector2> child, IRange<IValue<float>> numbers) : base(child)
        {
            _numbers = numbers;
        }

        public override Vector2 Direction()
        {
            var value = Child.Direction();

            var max = _numbers.Max().Evaluate();
            var min = _numbers.Min().Evaluate();
            
            var x = Math.Min(Math.Max(value.x, max), min);
            var y = Math.Min(Math.Max(value.y, max), min);
            
            return new Vector2(x, y);
        }
    }
}