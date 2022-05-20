using Plugins.Inputs_master.Inputs_master.Unity.Axis.Keyboards;
using UnityEngine;

namespace Code
{
    public interface IDeltaPosition : IValue<Vector3>
    {
        new Vector3 Evaluate();
    }
}