using UnityEngine;

namespace Code
{
    public class Meteorite : MonoBehaviour
    {
        private IDeltaPosition _deltaPosition;
        private int _damage;
        
        public void Initialize(IDeltaPosition deltaPosition, int damage)
        {
            _deltaPosition = deltaPosition;
            _damage = damage;
        }

        private void Update()
        {
            transform.position += _deltaPosition.Evaluate();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(_damage);
                DestroySelf();
            }
        }
        
        private void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}