using UnityEngine;
using Random = UnityEngine.Random;

namespace Code
{
    public class MeteoriteSpawner : MonoBehaviour
    {
        [SerializeField] private Meteorite _meteoritePrefab;
        [SerializeField] private Transform _gunTransform;
        [SerializeField] private FloatRange _spawnRate;
        
        [SerializeField] private float _meteoriteSpeed; // это тоже не должно быть тут))  
        [SerializeField] private int _damage; // и это)

        private RandomLoopTimer _timer;

        private float _radius = 5f;

        private void Awake()
        {
            Initialize(new RandomLoopTimer(_spawnRate));
        }

        private void Initialize(RandomLoopTimer timer)
        {
            _timer = timer;
            _timer.Resume();
            _timer.TimeIsUp += OnTimeIsUp; 
        }

        private void OnTimeIsUp()
        {
            var enemyPosition= EvaluateEnemyPosition();
            var meteorite = Instantiate(_meteoritePrefab);
            
            meteorite.transform.position = enemyPosition;
            meteorite.Initialize(new ConstantMultiplyDeltaPosition(
                new FluidMultiplyDeltaPosition(new ConstantDeltaPosition(_gunTransform.position - enemyPosition), new UnityDeltaTime()),
                _meteoriteSpeed), _damage);
        }

        private void Update()
        {
            _timer.Update(Time.deltaTime);
        }

        private Vector3 EvaluateEnemyPosition()
        {
            var randomAngle = Random.Range(0, 360);
            var position = _gunTransform.position;
            var x = position.x + Mathf.Cos(randomAngle * Mathf.Deg2Rad) * _radius;
            var z = position.z + Mathf.Sin(randomAngle * Mathf.Deg2Rad) * _radius;

            return new Vector3(x, 0f, z);
        }
    }
}