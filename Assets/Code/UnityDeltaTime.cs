using Plugins.Inputs_master.Inputs_master.Unity.Axis.Keyboards;
using UnityEngine;

namespace Code
{
    public class UnityDeltaTime : IValue<float>
    {
        public float Evaluate()
        {
            return Time.deltaTime;
        }
    }
}