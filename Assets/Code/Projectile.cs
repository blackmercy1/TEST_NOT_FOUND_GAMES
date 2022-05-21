using UnityEngine;

namespace Code
{
    public class Projectile : MonoBehaviour, IDamageable
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

        public void TakeDamage(int damage)
        {
            
        }
    }
}