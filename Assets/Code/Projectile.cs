using UnityEngine;

namespace Code
{
    public class Projectile : MonoBehaviour
    {
        private IDeltaPosition _deltaPosition;

        public void Initialize(IDeltaPosition deltaPosition)
        {
            _deltaPosition = deltaPosition;
        }

        private void Update()
        {
            transform.position += _deltaPosition.Evaluate();
        }
    }
}