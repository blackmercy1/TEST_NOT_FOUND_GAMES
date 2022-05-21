using Plugins.Inputs_master.Inputs_master.Unity.Keys;
using UnityEngine;

namespace Code
{
    public class Gun : MonoBehaviour, IDamageable
    {
        [SerializeField] private AnimationCurve _curve;
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Camera _camera;
        
        [SerializeField] private float _fireForce;
        [SerializeField] private int _healthPoints = 10;
        [SerializeField] private GameObject _gameOverView; //так нельзя если что деоаить
        
        private IKey _fireKey;
        private Health _health;

        private void Awake()
        {
            _fireKey = new KeyDown(KeyCode.Mouse0);
            _health = new Health(_healthPoints);
            _health.Died += OnGunDied;
        }
        
        private void Update()
        {
            if (_fireKey.HasInput())
                Fire();
        }

        private void Fire()
        {
            var position = transform.position;
            var projectile = Instantiate(_projectilePrefab, position, Quaternion.identity);

            var mousePosition = Input.mousePosition;
            var viewportPoint = _camera.ScreenToWorldPoint(mousePosition);

            var delta = viewportPoint - position;
            var result = new Vector3(delta.x, 0, delta.z);
            
            projectile.Initialize(
                new ApplyPositionComposite(
                    new IDeltaPosition[]
                    {
                        new YDeltaPositionFromValue(
                            new CurveDeltaPosition(_curve, new UnityDeltaTime())),
                        new ConstantMultiplyDeltaPosition(
                            new FluidMultiplyDeltaPosition(new ConstantDeltaPosition(result), new UnityDeltaTime()),
                            _fireForce)
                    }));
        }
        
        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }
        
        private void OnGunDied()
        {
            _gameOverView.SetActive(true);
            Time.timeScale = 0f;// так тоже нельзя
        }
    }
}