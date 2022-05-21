using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code
{
    [Serializable]
    public struct FloatRange
    {
        [SerializeField] private float _min;
        [SerializeField] private float _max;

        public float GetRandomValue()
        {
            return Random.Range(_min, _max);
        }
    }
}